CREATE USER 'user'@'localhost' IDENTIFIED BY 'senha';
GRANT ALL PRIVILEGES ON * . * TO 'user'@'localhost';
FLUSH PRIVILEGES;

CREATE database apps;
use apps;
CREATE TABLE aplicativos (
id INT auto_increment PRIMARY KEY,
nome text,
descricao text,
disponivel_ate date,
url VARCHAR(75) );

INSERT INTO aplicativos (nome, descricao, disponivel_ate, url ) VALUES ('android para cegos2', 'um app do android para cegos2','2022-02-02', 'www.androidparacegos.com.br');
