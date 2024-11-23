CREATE TABLE responsavel (
    respId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    nome1 VARCHAR(50) NOT NULL,
    email1 VARCHAR(250) NOT NULL,
    cpf1 VARCHAR(15) NOT NULL,
    tel1 VARCHAR(20),
    tel2 VARCHAR(20)
);

CREATE TABLE usuario (
    userId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    codFunc VARCHAR(6),
    senha VARCHAR(30) NOT NULL,
    permissao VARCHAR(3),
    data_nasc DATE,
    email VARCHAR(50),
    cpf VARCHAR(11) NOT NULL,
    pfp TEXT,
    nome VARCHAR(50) NOT NULL,
    rg VARCHAR(9),
    pagamento FLOAT,
    telefone VARCHAR(20),
    FK_usuario_userId INT
);

CREATE TABLE aluno (
    alunoId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    data_nasc DATE NOT NULL,
    rg VARCHAR(13),
    data_mat DATE,
    pfp TEXT
);

CREATE TABLE matricula (
    matId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    data DATE NOT NULL,
    hora TIME NOT NULL,
    curso VARCHAR(30) NOT NULL,
    valor FLOAT
);

CREATE TABLE aulas (
    aulaId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    data_aula DATE NOT NULL,
    horario TIME NOT NULL,
    curso VARCHAR(30) NOT NULL,
    tema VARCHAR(50) NOT NULL,
    numero_aula INT NOT NULL,
    prof1 VARCHAR(50),
    prof2 VARCHAR(50)
);

CREATE TABLE produtos (
    prodId INT NOT NULL  AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    descr TEXT,
    preco FLOAT NOT NULL,
    qtd INT NOT NULL,
    data_aq DATE,
    foto TEXT
);

CREATE TABLE cadastraProduto (
    FK_usuario_userId INT NOT NULL,
    FK_produto_prodId INT NOT NULL
);

CREATE TABLE cadastroAula (
    FK_usuario_userId INT NOT NULL,
    FK_aula_aulaId INT NOT NULL
);

CREATE TABLE mat_Usuario (
    FK_usuario_userId INT NOT NULL,
    FK_matricula_matId INT NOT NULL
);

CREATE TABLE mat_Aluno (
    FK_aluno_alunoId INT NOT NULL,
    FK_matricula_matId INT NOT NULL
);

CREATE TABLE respAluno (
    FK_responsavel_respId INT NOT NULL,
    FK_aluno_alunoId INT NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT FK_usuario_1
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId);

ALTER TABLE cadastraProduto ADD CONSTRAINT FK_cadastraProduto_0
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE cadastraProduto ADD CONSTRAINT FK_cadastraProduto_1
    FOREIGN KEY (FK_produto_prodId)
    REFERENCES produtos (prodId)
    ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE cadastroAula ADD CONSTRAINT FK_cadastroAula_0
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE cadastroAula ADD CONSTRAINT FK_cadastroAula_1
    FOREIGN KEY (FK_aula_aulaId)
    REFERENCES aulas (aulaId)
    ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE mat_Usuario ADD CONSTRAINT FK_mat_Usuario_0
    FOREIGN KEY (FK_usuario_userId)
    REFERENCES usuario (userId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE mat_Usuario ADD CONSTRAINT FK_mat_Usuario_1
    FOREIGN KEY (FK_matricula_matId)
    REFERENCES matricula (matId)
    ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE mat_Aluno ADD CONSTRAINT FK_mat_Aluno_0
    FOREIGN KEY (FK_aluno_alunoId)
    REFERENCES aluno (alunoId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE mat_Aluno ADD CONSTRAINT FK_mat_Aluno_1
    FOREIGN KEY (FK_matricula_matId)
    REFERENCES matricula (matId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE respAluno ADD CONSTRAINT FK_respAluno_0
    FOREIGN KEY (FK_responsavel_respId)
    REFERENCES responsavel (respId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE respAluno ADD CONSTRAINT FK_respAluno_1
    FOREIGN KEY (FK_aluno_alunoId)
    REFERENCES aluno (alunoId)
    ON DELETE RESTRICT ON UPDATE RESTRICT;
