-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 22-Nov-2024 às 12:43
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `ensina_mais`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno`
--

CREATE TABLE `aluno` (
  `alunoId` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `rg` varchar(9) DEFAULT NULL,
  `data_mat` date DEFAULT NULL,
  `pfp` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aulas`
--

CREATE TABLE `aulas` (
  `aulaId` int(11) NOT NULL,
  `data_aula` date DEFAULT NULL,
  `horario` time DEFAULT NULL,
  `curso` varchar(30) DEFAULT NULL,
  `tema` varchar(50) DEFAULT NULL,
  `numero_aula` int(11) DEFAULT NULL,
  `prof1` varchar(50) DEFAULT NULL,
  `prof2` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cadastraaula`
--

CREATE TABLE `cadastraaula` (
  `fk_Usuario_userId` int(11) DEFAULT NULL,
  `fk_Aulas_aulaId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cadastraproduto`
--

CREATE TABLE `cadastraproduto` (
  `fk_Usuario_userId` int(11) DEFAULT NULL,
  `fk_Produtos_prodId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cadastrausuario`
--

CREATE TABLE `cadastrausuario` (
  `fk_Usuario_userId` int(11) DEFAULT NULL,
  `fk_Usuario_userId_` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `matricula`
--

CREATE TABLE `matricula` (
  `matId` int(11) NOT NULL,
  `data_mat` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `curso` varchar(30) DEFAULT NULL,
  `valor` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `matusuario`
--

CREATE TABLE `matusuario` (
  `fk_Usuario_userId` int(11) DEFAULT NULL,
  `fk_Matricula_matId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `mat_aluno`
--

CREATE TABLE `mat_aluno` (
  `fk_Aluno_alunoId` int(11) DEFAULT NULL,
  `fk_Matricula_matId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `produtos`
--

CREATE TABLE `produtos` (
  `prodId` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `descricao` text DEFAULT NULL,
  `preco` float DEFAULT NULL,
  `qtd` int(11) DEFAULT NULL,
  `data_aq` date DEFAULT NULL,
  `foto` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `respaluno`
--

CREATE TABLE `respaluno` (
  `fk_Aluno_alunoId` int(11) DEFAULT NULL,
  `fk_Responsavel_respId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `responsavel`
--

CREATE TABLE `responsavel` (
  `respId` int(11) NOT NULL,
  `nome1` varchar(50) DEFAULT NULL,
  `email1` varchar(100) DEFAULT NULL,
  `cpf1` varchar(11) DEFAULT NULL,
  `tel1` varchar(20) DEFAULT NULL,
  `tel2` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `userId` int(11) NOT NULL,
  `codFunc` varchar(6) DEFAULT NULL,
  `senha` varchar(30) DEFAULT NULL,
  `permissao` varchar(30) DEFAULT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `pagamento` float DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `rg` varchar(9) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `pfp` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`userId`, `codFunc`, `senha`, `permissao`, `nome`, `data_nasc`, `pagamento`, `cpf`, `rg`, `telefone`, `email`, `pfp`) VALUES
(1, '123456', 'amogus', 'adm', 'Miguel Zimmermann', '2008-03-06', 12.02, '54776951886', '757636457', '19992029217', 'migmig.zimmer@gmail.com', NULL);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`alunoId`);

--
-- Índices para tabela `aulas`
--
ALTER TABLE `aulas`
  ADD PRIMARY KEY (`aulaId`);

--
-- Índices para tabela `cadastraaula`
--
ALTER TABLE `cadastraaula`
  ADD KEY `FK_cadastraAula_1` (`fk_Usuario_userId`),
  ADD KEY `FK_cadastraAula_2` (`fk_Aulas_aulaId`);

--
-- Índices para tabela `cadastraproduto`
--
ALTER TABLE `cadastraproduto`
  ADD KEY `FK_cadastraProduto_1` (`fk_Usuario_userId`),
  ADD KEY `FK_cadastraProduto_2` (`fk_Produtos_prodId`);

--
-- Índices para tabela `cadastrausuario`
--
ALTER TABLE `cadastrausuario`
  ADD KEY `FK_cadastraUsuario_1` (`fk_Usuario_userId`),
  ADD KEY `FK_cadastraUsuario_2` (`fk_Usuario_userId_`);

--
-- Índices para tabela `matricula`
--
ALTER TABLE `matricula`
  ADD PRIMARY KEY (`matId`);

--
-- Índices para tabela `matusuario`
--
ALTER TABLE `matusuario`
  ADD KEY `FK_mat_usuario_1` (`fk_Usuario_userId`),
  ADD KEY `FK_mat_usuario_2` (`fk_Matricula_matId`);

--
-- Índices para tabela `mat_aluno`
--
ALTER TABLE `mat_aluno`
  ADD KEY `FK_mat_aluno_1` (`fk_Aluno_alunoId`),
  ADD KEY `FK_mat_aluno_2` (`fk_Matricula_matId`);

--
-- Índices para tabela `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`prodId`);

--
-- Índices para tabela `respaluno`
--
ALTER TABLE `respaluno`
  ADD KEY `FK_respAluno_1` (`fk_Aluno_alunoId`),
  ADD KEY `FK_respAluno_2` (`fk_Responsavel_respId`);

--
-- Índices para tabela `responsavel`
--
ALTER TABLE `responsavel`
  ADD PRIMARY KEY (`respId`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`userId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `aluno`
--
ALTER TABLE `aluno`
  MODIFY `alunoId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `aulas`
--
ALTER TABLE `aulas`
  MODIFY `aulaId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `matricula`
--
ALTER TABLE `matricula`
  MODIFY `matId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `produtos`
--
ALTER TABLE `produtos`
  MODIFY `prodId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `responsavel`
--
ALTER TABLE `responsavel`
  MODIFY `respId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `cadastraaula`
--
ALTER TABLE `cadastraaula`
  ADD CONSTRAINT `FK_cadastraAula_1` FOREIGN KEY (`fk_Usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_cadastraAula_2` FOREIGN KEY (`fk_Aulas_aulaId`) REFERENCES `aulas` (`aulaId`) ON DELETE SET NULL;

--
-- Limitadores para a tabela `cadastraproduto`
--
ALTER TABLE `cadastraproduto`
  ADD CONSTRAINT `FK_cadastraProduto_1` FOREIGN KEY (`fk_Usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_cadastraProduto_2` FOREIGN KEY (`fk_Produtos_prodId`) REFERENCES `produtos` (`prodId`) ON DELETE SET NULL;

--
-- Limitadores para a tabela `cadastrausuario`
--
ALTER TABLE `cadastrausuario`
  ADD CONSTRAINT `FK_cadastraUsuario_1` FOREIGN KEY (`fk_Usuario_userId`) REFERENCES `usuario` (`userId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_cadastraUsuario_2` FOREIGN KEY (`fk_Usuario_userId_`) REFERENCES `usuario` (`userId`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `matusuario`
--
ALTER TABLE `matusuario`
  ADD CONSTRAINT `FK_mat_usuario_1` FOREIGN KEY (`fk_Usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_mat_usuario_2` FOREIGN KEY (`fk_Matricula_matId`) REFERENCES `matricula` (`matId`) ON DELETE SET NULL;

--
-- Limitadores para a tabela `mat_aluno`
--
ALTER TABLE `mat_aluno`
  ADD CONSTRAINT `FK_mat_aluno_1` FOREIGN KEY (`fk_Aluno_alunoId`) REFERENCES `aluno` (`alunoId`),
  ADD CONSTRAINT `FK_mat_aluno_2` FOREIGN KEY (`fk_Matricula_matId`) REFERENCES `matricula` (`matId`);

--
-- Limitadores para a tabela `respaluno`
--
ALTER TABLE `respaluno`
  ADD CONSTRAINT `FK_respAluno_1` FOREIGN KEY (`fk_Aluno_alunoId`) REFERENCES `aluno` (`alunoId`),
  ADD CONSTRAINT `FK_respAluno_2` FOREIGN KEY (`fk_Responsavel_respId`) REFERENCES `responsavel` (`respId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
