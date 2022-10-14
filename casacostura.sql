-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 25-Out-2021 às 21:23
-- Versão do servidor: 10.4.20-MariaDB
-- versão do PHP: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `casacostura`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `atendimento`
--

CREATE TABLE `atendimento` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Telefone` varchar(15) DEFAULT NULL,
  `Mensagem` varchar(400) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `atendimento`
--

INSERT INTO `atendimento` (`Id`, `Nome`, `Email`, `Telefone`, `Mensagem`) VALUES
(1, 'maria', 'mari', '999999999', 'ola'),
(3, 'vanessa', 'nessie', '999999999', 'oie'),
(6, 'ana', 'ana', '999999999', 'oioioi');

-- --------------------------------------------------------

--
-- Estrutura da tabela `carrinho`
--

CREATE TABLE `carrinho` (
  `Id` int(4) NOT NULL,
  `Usuario` int(4) DEFAULT NULL,
  `Produto` varchar(50) DEFAULT NULL,
  `Quantidade` int(9) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `carrinho`
--

INSERT INTO `carrinho` (`Id`, `Usuario`, `Produto`, `Quantidade`) VALUES
(1, 3, 'Tecido Tricoline Liso', 1),
(2, 3, 'Botão 2 Furos Cor', 1),
(29, 3, 'Tecido Tricoline Liso', 1),
(30, 3, 'Cortina 2,00x2,00m', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(50) DEFAULT NULL,
  `Quantidade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Quantidade`) VALUES
(1, 'Tecido Tricoline Liso', 5),
(2, 'Tecido Jacquard Floral', 5),
(3, 'Plástico Térmico Xadrez', 10),
(4, 'Botão 2 Furos Cor', 144),
(5, 'Botão 4 Furos Transparente', 144),
(6, 'Botão 4 Furos Perolado', 144),
(7, 'Linha de Costura', 10),
(8, 'Linha Pesponto', 10),
(9, 'Linha de Crochê', 3),
(10, 'Cortina 2,00x2,00m', 3),
(11, 'Conjunto 6 capas de Cadeiras', 3),
(12, 'Pano de Prato Pintado a Mão', 5),
(13, 'Toalha de Banho Bordada', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Senha` varchar(15) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL,
  `Telefone` varchar(15) DEFAULT NULL,
  `Cep` varchar(9) DEFAULT NULL,
  `Endereco` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Email`, `Senha`, `DataNascimento`, `Telefone`, `Cep`, `Endereco`) VALUES
(1, 'maria', 'mari', '123', '0001-01-01 00:00:00', NULL, NULL, NULL),
(2, 'joana', 'jo', '123', '0001-01-01 00:00:00', NULL, NULL, NULL),
(3, 'vanessa', 'nessie', '123', '0001-01-01 00:00:00', '1111', '23242', NULL),
(4, 'ana', 'ana', '123', '0001-01-01 00:00:00', NULL, NULL, NULL);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `atendimento`
--
ALTER TABLE `atendimento`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `atendimento`
--
ALTER TABLE `atendimento`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `carrinho`
--
ALTER TABLE `carrinho`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD CONSTRAINT `carrinho_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
