import sys
from db_connector import get_connection

def extract_table_create(table_name: str):
    try:
        with get_connection() as conn:
            cursor = conn.cursor()
            table_name_upper = table_name.upper()
            
            # Query para buscar detalhes das colunas
            query_cols = """
            SELECT 
                RF.RDB$FIELD_NAME AS FIELD_NAME,
                CASE F.RDB$FIELD_TYPE
                    WHEN 7 THEN 'SMALLINT'
                    WHEN 8 THEN 'INTEGER'
                    WHEN 10 THEN 'FLOAT'
                    WHEN 12 THEN 'DATE'
                    WHEN 13 THEN 'TIME'
                    WHEN 14 THEN 'CHAR'
                    WHEN 16 THEN 'BIGINT'
                    WHEN 27 THEN 'DOUBLE PRECISION'
                    WHEN 35 THEN 'TIMESTAMP'
                    WHEN 37 THEN 'VARCHAR'
                    WHEN 261 THEN 'BLOB'
                    ELSE 'UNKNOWN'
                END AS FIELD_TYPE,
                F.RDB$FIELD_LENGTH AS FIELD_LENGTH,
                RF.RDB$NULL_FLAG AS NULL_FLAG
            FROM RDB$RELATION_FIELDS RF
            JOIN RDB$FIELDS F ON RF.RDB$FIELD_SOURCE = F.RDB$FIELD_NAME
            WHERE RF.RDB$RELATION_NAME = ?
            ORDER BY RF.RDB$FIELD_POSITION;
            """
            
            cursor.execute(query_cols, (table_name_upper,))
            columns_data = cursor.fetchall()
            
            if not columns_data:
                print(f"Erro: Tabela '{table_name_upper}' não encontrada ou não possui colunas.")
                return None
            
            columns_ddl = []
            for row in columns_data:
                name = row[0].strip()
                dtype = row[1].strip()
                length = row[2]
                nullable = row[3] == 0 or row[3] is None
                
                col_def = f"    {name} {dtype}"
                if dtype in ['VARCHAR', 'CHAR']:
                    col_def += f"({length})"
                
                if not nullable:
                    col_def += " NOT NULL"
                
                columns_ddl.append(col_def)
            
            ddl = f"CREATE TABLE {table_name_upper} (\n"
            ddl += ",\n".join(columns_ddl)
            ddl += "\n);"
            
            # Query para buscar a Chave Primária
            query_pk = """
            SELECT 
                ISIG.RDB$FIELD_NAME AS FIELD_NAME,
                CON.RDB$CONSTRAINT_NAME AS CONSTRAINT_NAME
            FROM RDB$RELATION_CONSTRAINTS CON
            JOIN RDB$INDEX_SEGMENTS ISIG ON CON.RDB$INDEX_NAME = ISIG.RDB$INDEX_NAME
            WHERE CON.RDB$RELATION_NAME = ? AND CON.RDB$CONSTRAINT_TYPE = 'PRIMARY KEY'
            ORDER BY ISIG.RDB$FIELD_POSITION;
            """
            
            cursor.execute(query_pk, (table_name_upper,))
            pk_data = cursor.fetchall()
            
            if pk_data:
                pk_name = pk_data[0][1].strip()
                pk_fields = ", ".join([row[0].strip() for row in pk_data])
                ddl += f"\n\nALTER TABLE {table_name_upper} ADD CONSTRAINT {pk_name} PRIMARY KEY ({pk_fields});"

            # Query para buscar Chaves Estrangeiras
            query_fk = """
            SELECT 
                RC.RDB$CONSTRAINT_NAME AS CONSTRAINT_NAME,
                IX.RDB$FIELD_NAME AS FIELD_NAME,
                REF_RC.RDB$RELATION_NAME AS REF_TABLE,
                REF_IX.RDB$FIELD_NAME AS REF_FIELD
            FROM RDB$RELATION_CONSTRAINTS RC
            JOIN RDB$REF_CONSTRAINTS RF ON RC.RDB$CONSTRAINT_NAME = RF.RDB$CONSTRAINT_NAME
            JOIN RDB$INDEX_SEGMENTS IX ON RC.RDB$INDEX_NAME = IX.RDB$INDEX_NAME
            JOIN RDB$RELATION_CONSTRAINTS REF_RC ON RF.RDB$CONST_NAME_UQ = REF_RC.RDB$CONSTRAINT_NAME
            JOIN RDB$INDEX_SEGMENTS REF_IX ON REF_RC.RDB$INDEX_NAME = REF_IX.RDB$INDEX_NAME
            WHERE RC.RDB$RELATION_NAME = ? AND RC.RDB$CONSTRAINT_TYPE = 'FOREIGN KEY'
            ORDER BY RC.RDB$CONSTRAINT_NAME, IX.RDB$FIELD_POSITION;
            """
            
            cursor.execute(query_fk, (table_name_upper,))
            fk_data = cursor.fetchall()
            
            if fk_data:
                fks = {}
                for row in fk_data:
                    fk_name = row[0].strip()
                    field = row[1].strip()
                    ref_table = row[2].strip()
                    ref_field = row[3].strip()
                    
                    if fk_name not in fks:
                        fks[fk_name] = {'fields': [], 'ref_table': ref_table, 'ref_fields': []}
                    fks[fk_name]['fields'].append(field)
                    fks[fk_name]['ref_fields'].append(ref_field)
                
                for fk_name, info in fks.items():
                    fields = ", ".join(info['fields'])
                    ref_fields = ", ".join(info['ref_fields'])
                    ddl += f"\nALTER TABLE {table_name_upper} ADD CONSTRAINT {fk_name} FOREIGN KEY ({fields}) REFERENCES {info['ref_table']} ({ref_fields});"
            
            return ddl
    except Exception as e:
        print(f"Erro ao extrair metadados: {e}")
        return None

def list_user_tables():
    try:
        with get_connection() as conn:
            cursor = conn.cursor()
            query_tables = """
            SELECT TRIM(RDB$RELATION_NAME) AS TABLE_NAME
            FROM RDB$RELATIONS
            WHERE COALESCE(RDB$SYSTEM_FLAG, 0) = 0
              AND RDB$VIEW_BLR IS NULL
              AND RDB$RELATION_NAME NOT STARTING WITH 'RDB$'
              AND RDB$RELATION_NAME NOT STARTING WITH 'MON$'
              AND RDB$RELATION_NAME NOT STARTING WITH 'SEC$'
            ORDER BY RDB$RELATION_NAME;
            """
            cursor.execute(query_tables)
            return [row[0].strip() for row in cursor.fetchall()]
    except Exception as e:
        print(f"Erro ao listar tabelas: {e}")
        return []

if __name__ == "__main__":
    if len(sys.argv) > 1:
        target_table = sys.argv[1]
        print(f"Extraindo CREATE TABLE para: {target_table}...")
        ddl = extract_table_create(target_table)

        if ddl:
            print("\n--- DDL EXTRAÍDO ---")
            print(ddl)

            filename = f"create_{target_table.lower()}.sql"
            with open(filename, "w") as f:
                f.write(ddl)
            print(f"\nDDL salvo em: {filename}")
    else:
        tables = list_user_tables()
        if not tables:
            print("Nenhuma tabela de usuário encontrada.")
            sys.exit(1)

        print(f"Extraindo CREATE TABLE para {len(tables)} tabelas...")
        ddls = []
        for table in tables:
            ddl = extract_table_create(table)
            if ddl:
                ddls.append(ddl)
                table_filename = f"create_{table.lower()}.sql"
                with open(table_filename, "w") as f:
                    f.write(ddl)
                print(f"DDL da tabela {table} salvo em: {table_filename}")
            else:
                print(f"Aviso: não foi possível extrair DDL da tabela {table}.")

        if ddls:
            full_ddl = "\n\n".join(ddls)
            print("\n--- DDL EXTRAÍDO (TODAS AS TABELAS) ---")
            print(full_ddl)

            filename = "create_all_tables.sql"
            with open(filename, "w") as f:
                f.write(full_ddl)
            print(f"\nDDL salvo em: {filename}")
