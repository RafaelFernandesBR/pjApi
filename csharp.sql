CREATE USER 'user'@'localhost' IDENTIFIED BY 'senha';
GRANT ALL PRIVILEGES ON * . * TO 'user'@'localhost';
FLUSH PRIVILEGES;

CREATE database apps;
CREATE TABLE aplicativos (
id INT auto_increment PRIMARY KEY,
nome text,
descricao text,
disponivel_ate date );

INSERT INTO aplicativos (nome, descricao, disponivel_ate ) VALUES ('android para cegos', 'um app do android para cegos', '23 de janeiro');
