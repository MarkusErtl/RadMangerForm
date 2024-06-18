-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Erstellungszeit: 18. Jun 2024 um 09:20
-- Server-Version: 8.4.0
-- PHP-Version: 8.2.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `RadManager`
--
CREATE DATABASE IF NOT EXISTS `RadManager` DEFAULT CHARACTER SET utf16le COLLATE utf16le_general_ci;
USE `RadManager`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Belag`
--

CREATE TABLE `Belag` (
  `BelagID` int NOT NULL,
  `Name` int NOT NULL,
  `Zustand` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Bundesland`
--

CREATE TABLE `Bundesland` (
  `BundeslandID` int NOT NULL,
  `Name` varchar(30) NOT NULL,
  `PersonenID` int DEFAULT NULL,
  `StreckenID` int DEFAULT NULL,
  `Hauptstadt` varchar(30) DEFAULT NULL,
  `Einwohnerzahl` int DEFAULT NULL,
  `Fläche` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Fahrrad`
--

CREATE TABLE `Fahrrad` (
  `FahrradID` int NOT NULL,
  `Fahrradname` varchar(30) NOT NULL,
  `Hersteller` varchar(50) DEFAULT NULL,
  `Modeljahr` date DEFAULT NULL,
  `Preis` decimal(30,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Koordinaten`
--

CREATE TABLE `Koordinaten` (
  `KoordinatenID` int NOT NULL,
  `Breitengrad` int NOT NULL,
  `Längengrad` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Person`
--

CREATE TABLE `Person` (
  `PersonID` int NOT NULL,
  `Vorname` varchar(30) NOT NULL,
  `Nachname` varchar(30) CHARACTER SET utf16le COLLATE utf16le_general_ci DEFAULT NULL,
  `GebDatum` date DEFAULT NULL,
  `FahrradID` int NOT NULL,
  `Addresse` int DEFAULT NULL,
  `E-mail` varchar(30) CHARACTER SET utf16le COLLATE utf16le_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Strecken`
--

CREATE TABLE `Strecken` (
  `StreckenID` int NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Länge` int DEFAULT NULL,
  `Dauer` time DEFAULT NULL,
  `Schwierigkeitsgrad` int DEFAULT NULL,
  `TrinkbrunnenID` int DEFAULT NULL,
  `BelagID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Trinkbrunnen`
--

CREATE TABLE `Trinkbrunnen` (
  `TrinkbrunnenID` int NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Funktionsfähig` tinyint(1) DEFAULT NULL,
  `Bewertung` int DEFAULT NULL,
  `Zustand` varchar(30) DEFAULT NULL,
  `KoordinatenID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ZOT_Strecke_Trinkbrunnen`
--

CREATE TABLE `ZOT_Strecke_Trinkbrunnen` (
  `StreckenID` int NOT NULL,
  `TrinbrunnenID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16le;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `Belag`
--
ALTER TABLE `Belag`
  ADD PRIMARY KEY (`BelagID`);

--
-- Indizes für die Tabelle `Bundesland`
--
ALTER TABLE `Bundesland`
  ADD PRIMARY KEY (`BundeslandID`),
  ADD UNIQUE KEY `PersonenID` (`PersonenID`),
  ADD UNIQUE KEY `StreckenID` (`StreckenID`);

--
-- Indizes für die Tabelle `Fahrrad`
--
ALTER TABLE `Fahrrad`
  ADD PRIMARY KEY (`FahrradID`);

--
-- Indizes für die Tabelle `Koordinaten`
--
ALTER TABLE `Koordinaten`
  ADD PRIMARY KEY (`KoordinatenID`);

--
-- Indizes für die Tabelle `Person`
--
ALTER TABLE `Person`
  ADD PRIMARY KEY (`PersonID`),
  ADD UNIQUE KEY `Fahrradfk` (`FahrradID`) USING BTREE;

--
-- Indizes für die Tabelle `Strecken`
--
ALTER TABLE `Strecken`
  ADD PRIMARY KEY (`StreckenID`),
  ADD UNIQUE KEY `Belagfk` (`BelagID`),
  ADD UNIQUE KEY `Trinkbrunnenfk` (`TrinkbrunnenID`);

--
-- Indizes für die Tabelle `Trinkbrunnen`
--
ALTER TABLE `Trinkbrunnen`
  ADD PRIMARY KEY (`TrinkbrunnenID`),
  ADD UNIQUE KEY `Koordinatenfk` (`KoordinatenID`);

--
-- Indizes für die Tabelle `ZOT_Strecke_Trinkbrunnen`
--
ALTER TABLE `ZOT_Strecke_Trinkbrunnen`
  ADD UNIQUE KEY `StreckenBrunnenfk` (`StreckenID`,`TrinbrunnenID`),
  ADD KEY `TrinbrunnenID` (`TrinbrunnenID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `Belag`
--
ALTER TABLE `Belag`
  MODIFY `BelagID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `Fahrrad`
--
ALTER TABLE `Fahrrad`
  MODIFY `FahrradID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `Koordinaten`
--
ALTER TABLE `Koordinaten`
  MODIFY `KoordinatenID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `Person`
--
ALTER TABLE `Person`
  MODIFY `PersonID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `Strecken`
--
ALTER TABLE `Strecken`
  MODIFY `StreckenID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `Trinkbrunnen`
--
ALTER TABLE `Trinkbrunnen`
  MODIFY `TrinkbrunnenID` int NOT NULL AUTO_INCREMENT;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `Belag`
--
ALTER TABLE `Belag`
  ADD CONSTRAINT `Belag_ibfk_1` FOREIGN KEY (`BelagID`) REFERENCES `Strecken` (`BelagID`);

--
-- Constraints der Tabelle `Fahrrad`
--
ALTER TABLE `Fahrrad`
  ADD CONSTRAINT `Fahrrad_ibfk_1` FOREIGN KEY (`FahrradID`) REFERENCES `Person` (`FahrradID`);

--
-- Constraints der Tabelle `Koordinaten`
--
ALTER TABLE `Koordinaten`
  ADD CONSTRAINT `Koordinaten_ibfk_1` FOREIGN KEY (`KoordinatenID`) REFERENCES `Trinkbrunnen` (`KoordinatenID`);

--
-- Constraints der Tabelle `Person`
--
ALTER TABLE `Person`
  ADD CONSTRAINT `Person_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `Bundesland` (`PersonenID`);

--
-- Constraints der Tabelle `Strecken`
--
ALTER TABLE `Strecken`
  ADD CONSTRAINT `Strecken_ibfk_1` FOREIGN KEY (`StreckenID`) REFERENCES `Bundesland` (`StreckenID`);

--
-- Constraints der Tabelle `ZOT_Strecke_Trinkbrunnen`
--
ALTER TABLE `ZOT_Strecke_Trinkbrunnen`
  ADD CONSTRAINT `ZOT_Strecke_Trinkbrunnen_ibfk_1` FOREIGN KEY (`StreckenID`) REFERENCES `Strecken` (`StreckenID`),
  ADD CONSTRAINT `ZOT_Strecke_Trinkbrunnen_ibfk_2` FOREIGN KEY (`TrinbrunnenID`) REFERENCES `Trinkbrunnen` (`TrinkbrunnenID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
