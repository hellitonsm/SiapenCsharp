import configparser
from firebird.driver import connect, Connection

def get_db_config(config_file='connections.ini', section='SISAP'):
    config = configparser.ConfigParser()
    config.read(config_file)
    
    if section not in config:
        raise ValueError(f"Section [{section}] not found in {config_file}")
        
    db_config = {}
    db_path = config.get(section, 'database')
    
    if ':' in db_path:
        db_config['host'], db_config['database'] = db_path.split(':', 1)
    else:
        db_config['host'] = 'localhost'
        db_config['database'] = db_path
        
    db_config['user'] = config.get(section, 'user_name')
    db_config['password'] = config.get(section, 'password')
    db_config['charset'] = config.get(section, 'charset', fallback='UTF8')
    
    return db_config

def get_connection() -> Connection:
    db_config = get_db_config()
    # No firebird-driver v2.0+, a string de conexão deve ser 'host:database'
    connection_str = f"{db_config['host']}:{db_config['database']}"
    return connect(
        connection_str,
        user=db_config['user'],
        password=db_config['password'],
        charset=db_config['charset']
    )

if __name__ == "__main__":
    try:
        conn = get_connection()
        print("Conexão estabelecida com sucesso!")
        conn.close()
    except Exception as e:
        print(f"Erro ao conectar: {e}")
