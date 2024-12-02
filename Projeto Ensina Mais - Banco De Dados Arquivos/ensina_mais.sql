/* EnsinaMaisLógico: */

CREATE TABLE responsavel (
    respId INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome1 VARCHAR(250),
    email1 VARCHAR(250),
    cpf1 VARCHAR(20),
    tel1 VARCHAR(20),
    tel2 VARCHAR(20)
);

CREATE TABLE aluno (
    alunoId INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(250),
    data_nasc DATE,
    rg VARCHAR(20),
    data_mat DATE,
    pfp TEXT
);

CREATE TABLE matricula (
    matId INTEGER AUTO_INCREMENT PRIMARY KEY,
    data_mat DATE,
    hora TIME,
    valor FLOAT(10,2),
    FK_aluno_alunoId INTEGER,
    FK_usuario_userId INTEGER,
    FK_curso_cursoId INTEGER
);

CREATE TABLE usuario (
    userId INTEGER AUTO_INCREMENT PRIMARY KEY,
    codFunc VARCHAR(20),
    nome VARCHAR(250),
    rg VARCHAR(20),
    cpf VARCHAR(20),
    pagamento FLOAT(10,2),
    telefone VARCHAR(20),
    email VARCHAR(250),
    senha VARCHAR(250),
    permissao VARCHAR(3),
    data_nasc DATE,
    pfp BLOB
);

CREATE TABLE aula (
    aulaId INTEGER AUTO_INCREMENT PRIMARY KEY,
    data_aula DATE,
    horario TIME,
    tema VARCHAR(400),
    numero_aula INT,
    prof1 VARCHAR(250),
    prof2 VARCHAR(250),
    FK_usuario_userId INTEGER,
    FK_curso_cursoId INTEGER
);

CREATE TABLE produto (
    prodId INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(250),
    `desc` VARCHAR(500),
    preco FLOAT(10,2),
    qtd INT,
    data_aq DATE,
    foto BLOB,
    FK_usuario_userId INTEGER
);

CREATE TABLE curso (
    cursoId INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(200)
);

CREATE TABLE respaluno (
    FK_responsavel_respId INTEGER,
    FK_aluno_alunoId INTEGER
);
 
ALTER TABLE matricula ADD CONSTRAINT FK_matricula_1
    FOREIGN KEY (FK_aluno_alunoId)
    REFERENCES aluno (alunoId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE matricula ADD CONSTRAINT FK_matricula_2
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE matricula ADD CONSTRAINT FK_matricula_3
    FOREIGN KEY (FK_curso_cursoId)
    REFERENCES curso (cursoId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE aula ADD CONSTRAINT FK_aula_1
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE aula ADD CONSTRAINT FK_aula_2
    FOREIGN KEY (FK_curso_cursoId)
    REFERENCES curso (cursoId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE produto ADD CONSTRAINT FK_produto_1
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE respaluno ADD CONSTRAINT FK_respaluno_0
    FOREIGN KEY (FK_responsavel_respId)
    REFERENCES responsavel (respId)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE respaluno ADD CONSTRAINT FK_respaluno_1
    FOREIGN KEY (FK_aluno_alunoId)
    REFERENCES aluno (alunoId)
    ON DELETE CASCADE ON UPDATE CASCADE;

INSERT INTO `usuario` (`userId`, `codFunc`, `nome`, `rg`, `cpf`, `pagamento`, `telefone`, `email`, `senha`, `permissao`, `data_nasc`, `pfp`) VALUES (NULL, 'adm', 'adm', 'rg', 'cpf', '0000', '(11)99999-9999', 'email@gmail.com', '123', 'adm', '2000-01-01', NULL);

INSERT INTO curso(nome)
VALUES("Desenvolvimento de Sistemas"),
("Administracao"),
("Eletronica"),
("Automacao")