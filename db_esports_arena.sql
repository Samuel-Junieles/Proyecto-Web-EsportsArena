-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-03-2026 a las 04:47:48
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_esports_arena`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `capitanes`
--

CREATE TABLE `capitanes` (
  `Id` int(11) NOT NULL,
  `NombreCompleto` varchar(150) DEFAULT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `UsuarioId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encuentros`
--

CREATE TABLE `encuentros` (
  `Id` int(11) NOT NULL,
  `Equipo1Id` int(11) NOT NULL,
  `Equipo2Id` int(11) NOT NULL,
  `FechaEncuentro` datetime NOT NULL,
  `Estado` varchar(20) DEFAULT 'Pendiente',
  `Resultado` varchar(50) DEFAULT 'Por jugar'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `encuentros`
--

INSERT INTO `encuentros` (`Id`, `Equipo1Id`, `Equipo2Id`, `FechaEncuentro`, `Estado`, `Resultado`) VALUES
(8, 5, 6, '2026-03-14 22:03:00', 'Victoria aplastante ', 'Por jugar'),
(10, 7, 8, '2026-03-23 23:08:00', 'Victoria aplastante ', 'Por jugar'),
(11, 7, 8, '2026-03-23 23:11:00', 'Ganó T2', 'Por jugar'),
(12, 7, 8, '2026-03-28 18:57:00', 'Empate Técnico', 'Por jugar'),
(13, 8, 7, '2026-03-28 18:57:00', 'Empate Técnico', 'Por jugar'),
(14, 7, 8, '2026-03-28 18:58:00', 'Empate Técnico', 'Por jugar'),
(15, 7, 9, '2026-03-28 18:59:00', 'Empate Técnico', 'Por jugar'),
(16, 9, 8, '2026-03-28 18:59:00', 'Ganó Wolf', 'Por jugar'),
(17, 7, 8, '2026-03-28 19:00:00', 'Ganó T2', 'Por jugar'),
(18, 8, 7, '2026-03-28 19:00:00', 'Empate Técnico', 'Por jugar'),
(19, 9, 7, '2026-03-28 19:00:00', 'Ganó Wolf', 'Por jugar'),
(20, 10, 11, '2026-03-28 20:50:00', 'Ganó Front-End', 'Por jugar'),
(21, 10, 11, '2026-03-28 20:52:00', 'Empate Técnico', 'Por jugar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `equipos`
--

CREATE TABLE `equipos` (
  `Id` int(11) NOT NULL,
  `NombreEquipo` varchar(100) NOT NULL,
  `JuegoPrincipal` varchar(50) NOT NULL,
  `CapitanId` int(11) NOT NULL,
  `Logo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `equipos`
--

INSERT INTO `equipos` (`Id`, `NombreEquipo`, `JuegoPrincipal`, `CapitanId`, `Logo`) VALUES
(5, 'WolVest', 'Valorant', 2, NULL),
(6, 'Papitas', 'Valorant', 2, NULL),
(7, 'Will Craft', 'Dota 2', 7, NULL),
(8, 'T1', 'League of Legends', 7, NULL),
(9, 'Wolf', 'League of Legends', 7, NULL),
(10, 'Back-End', 'Dota 2', 8, NULL),
(11, 'Front-End', 'Dota 2', 8, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `patrocinadores`
--

CREATE TABLE `patrocinadores` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Empresa` varchar(100) DEFAULT NULL,
  `MontoInversion` decimal(10,2) DEFAULT NULL,
  `EmailContacto` varchar(100) DEFAULT NULL,
  `Estado` varchar(20) DEFAULT 'Activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `patrocinadores`
--

INSERT INTO `patrocinadores` (`Id`, `Nombre`, `Empresa`, `MontoInversion`, `EmailContacto`, `Estado`) VALUES
(1, 'Red Bull Arena Edition', 'Red Bull GmbH', 1000000.00, 'sponsors@redbull.com', 'Activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `nombre_rol` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`id`, `nombre_rol`) VALUES
(1, 'ADMIN'),
(2, 'CAPITAN'),
(3, 'ORGANIZADOR');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `PasswordHash` char(64) NOT NULL,
  `RolId` int(11) DEFAULT 2,
  `FechaRegistro` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Username`, `Email`, `PasswordHash`, `RolId`, `FechaRegistro`) VALUES
(2, 'Brayan', 'brayan@gmail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 2, '2026-03-14 21:59:38'),
(7, 'Samuel', 'sjunieles@ucompensar.edu.co', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, '2026-03-23 22:45:36'),
(8, 'antonio', 'junielessam@gmial.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 2, '2026-03-28 20:39:47');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `capitanes`
--
ALTER TABLE `capitanes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UsuarioId` (`UsuarioId`);

--
-- Indices de la tabla `encuentros`
--
ALTER TABLE `encuentros`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Equipo1Id` (`Equipo1Id`),
  ADD KEY `Equipo2Id` (`Equipo2Id`);

--
-- Indices de la tabla `equipos`
--
ALTER TABLE `equipos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CapitanId` (`CapitanId`);

--
-- Indices de la tabla `patrocinadores`
--
ALTER TABLE `patrocinadores`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nombre_rol` (`nombre_rol`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `capitanes`
--
ALTER TABLE `capitanes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `encuentros`
--
ALTER TABLE `encuentros`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `equipos`
--
ALTER TABLE `equipos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `patrocinadores`
--
ALTER TABLE `patrocinadores`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `capitanes`
--
ALTER TABLE `capitanes`
  ADD CONSTRAINT `capitanes_ibfk_1` FOREIGN KEY (`UsuarioId`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `encuentros`
--
ALTER TABLE `encuentros`
  ADD CONSTRAINT `encuentros_ibfk_1` FOREIGN KEY (`Equipo1Id`) REFERENCES `equipos` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `encuentros_ibfk_2` FOREIGN KEY (`Equipo2Id`) REFERENCES `equipos` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `equipos`
--
ALTER TABLE `equipos`
  ADD CONSTRAINT `equipos_ibfk_1` FOREIGN KEY (`CapitanId`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
