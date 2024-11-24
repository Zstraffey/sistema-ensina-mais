-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 24/11/2024 às 15:38
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

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
-- Estrutura para tabela `aluno`
--

CREATE TABLE `aluno` (
  `alunoId` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `rg` varchar(20) DEFAULT NULL,
  `data_mat` date DEFAULT NULL,
  `pfp` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `aulas`
--

CREATE TABLE `aulas` (
  `aulaId` int(11) NOT NULL,
  `data_aula` date DEFAULT NULL,
  `horario` time DEFAULT NULL,
  `curso` varchar(100) DEFAULT NULL,
  `tema` varchar(50) DEFAULT NULL,
  `numero_aula` int(11) DEFAULT NULL,
  `prof1` varchar(50) DEFAULT NULL,
  `prof2` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `cadastraproduto`
--

CREATE TABLE `cadastraproduto` (
  `FK_usuario_userId` int(11) DEFAULT NULL,
  `FK_produto_prodId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `cadastroaula`
--

CREATE TABLE `cadastroaula` (
  `FK_usuario_userId` int(11) DEFAULT NULL,
  `FK_aula_aulaId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `matricula`
--

CREATE TABLE `matricula` (
  `matId` int(11) NOT NULL,
  `data_mat` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `curso` varchar(100) DEFAULT NULL,
  `valor` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `mat_aluno`
--

CREATE TABLE `mat_aluno` (
  `FK_aluno_alunoId` int(11) DEFAULT NULL,
  `FK_matricula_matId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `mat_usuario`
--

CREATE TABLE `mat_usuario` (
  `FK_usuario_userId` int(11) DEFAULT NULL,
  `FK_matricula_matId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `produtos`
--

CREATE TABLE `produtos` (
  `prodId` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `descricao` text DEFAULT NULL,
  `preco` float DEFAULT NULL,
  `qtd` int(11) DEFAULT NULL,
  `data_aq` date DEFAULT NULL,
  `foto` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `respaluno`
--

CREATE TABLE `respaluno` (
  `FK_responsavel_respId` int(11) DEFAULT NULL,
  `FK_aluno_alunoId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `responsavel`
--

CREATE TABLE `responsavel` (
  `respId` int(11) NOT NULL,
  `nome1` varchar(50) DEFAULT NULL,
  `email1` varchar(100) DEFAULT NULL,
  `cpf1` varchar(20) DEFAULT NULL,
  `tel1` varchar(20) DEFAULT NULL,
  `tel2` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
  `userId` int(11) NOT NULL,
  `codFunc` varchar(6) DEFAULT NULL,
  `senha` varchar(30) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `cpf` varchar(20) DEFAULT NULL,
  `pfp` text DEFAULT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `rg` varchar(20) DEFAULT NULL,
  `pagamento` float DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `FK_usuario_userId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`alunoId`);

--
-- Índices de tabela `aulas`
--
ALTER TABLE `aulas`
  ADD PRIMARY KEY (`aulaId`);

--
-- Índices de tabela `cadastraproduto`
--
ALTER TABLE `cadastraproduto`
  ADD KEY `FK_cadastraProduto_1` (`FK_usuario_userId`),
  ADD KEY `FK_cadastraProduto_2` (`FK_produto_prodId`);

--
-- Índices de tabela `cadastroaula`
--
ALTER TABLE `cadastroaula`
  ADD KEY `FK_cadastroAula_1` (`FK_usuario_userId`),
  ADD KEY `FK_cadastroAula_2` (`FK_aula_aulaId`);

--
-- Índices de tabela `matricula`
--
ALTER TABLE `matricula`
  ADD PRIMARY KEY (`matId`);

--
-- Índices de tabela `mat_aluno`
--
ALTER TABLE `mat_aluno`
  ADD KEY `FK_mat_Aluno_1` (`FK_aluno_alunoId`),
  ADD KEY `FK_mat_Aluno_2` (`FK_matricula_matId`);

--
-- Índices de tabela `mat_usuario`
--
ALTER TABLE `mat_usuario`
  ADD KEY `FK_mat_Usuario_1` (`FK_usuario_userId`),
  ADD KEY `FK_mat_Usuario_2` (`FK_matricula_matId`);

--
-- Índices de tabela `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`prodId`);

--
-- Índices de tabela `respaluno`
--
ALTER TABLE `respaluno`
  ADD KEY `FK_respAluno_1` (`FK_responsavel_respId`),
  ADD KEY `FK_respAluno_2` (`FK_aluno_alunoId`);

--
-- Índices de tabela `responsavel`
--
ALTER TABLE `responsavel`
  ADD PRIMARY KEY (`respId`);

--
-- Índices de tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`userId`),
  ADD KEY `FK_usuario_2` (`FK_usuario_userId`);

--
-- AUTO_INCREMENT para tabelas despejadas
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
  MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `cadastraproduto`
--
ALTER TABLE `cadastraproduto`
  ADD CONSTRAINT `FK_cadastraProduto_1` FOREIGN KEY (`FK_usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_cadastraProduto_2` FOREIGN KEY (`FK_produto_prodId`) REFERENCES `produtos` (`prodId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Restrições para tabelas `cadastroaula`
--
ALTER TABLE `cadastroaula`
  ADD CONSTRAINT `FK_cadastroAula_1` FOREIGN KEY (`FK_usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_cadastroAula_2` FOREIGN KEY (`FK_aula_aulaId`) REFERENCES `aulas` (`aulaId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Restrições para tabelas `mat_aluno`
--
ALTER TABLE `mat_aluno`
  ADD CONSTRAINT `FK_mat_Aluno_1` FOREIGN KEY (`FK_aluno_alunoId`) REFERENCES `aluno` (`alunoId`),
  ADD CONSTRAINT `FK_mat_Aluno_2` FOREIGN KEY (`FK_matricula_matId`) REFERENCES `matricula` (`matId`);

--
-- Restrições para tabelas `mat_usuario`
--
ALTER TABLE `mat_usuario`
  ADD CONSTRAINT `FK_mat_Usuario_1` FOREIGN KEY (`FK_usuario_userId`) REFERENCES `usuario` (`userId`),
  ADD CONSTRAINT `FK_mat_Usuario_2` FOREIGN KEY (`FK_matricula_matId`) REFERENCES `matricula` (`matId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Restrições para tabelas `respaluno`
--
ALTER TABLE `respaluno`
  ADD CONSTRAINT `FK_respAluno_1` FOREIGN KEY (`FK_responsavel_respId`) REFERENCES `responsavel` (`respId`),
  ADD CONSTRAINT `FK_respAluno_2` FOREIGN KEY (`FK_aluno_alunoId`) REFERENCES `aluno` (`alunoId`);

--
-- Restrições para tabelas `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `FK_usuario_2` FOREIGN KEY (`FK_usuario_userId`) REFERENCES `usuario` (`userId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
