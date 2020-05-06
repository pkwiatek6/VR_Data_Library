-- MySQL dump 10.13  Distrib 5.7.29, for Linux (x86_64)
--
-- Host: localhost    Database: VR_DATA
-- ------------------------------------------------------
-- Server version	5.7.29-0ubuntu0.18.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Test_Administrators`
--

DROP TABLE IF EXISTS `Test_Administrators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Test_Administrators` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Test_Administrators`
--

LOCK TABLES `Test_Administrators` WRITE;
/*!40000 ALTER TABLE `Test_Administrators` DISABLE KEYS */;
INSERT INTO `Test_Administrators` VALUES (1,'Proctor1'),(2,'Proctpr2'),(3,'Proctor3'),(4,'Proctor4'),(5,'Proctor5'),(6,'Doe, John');
/*!40000 ALTER TABLE `Test_Administrators` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Test_Events`
--

DROP TABLE IF EXISTS `Test_Events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Test_Events` (
  `Test_Id` int(10) NOT NULL AUTO_INCREMENT,
  `Subject_Id` int(10) NOT NULL,
  `Admin_Id` int(10) NOT NULL,
  `Game_Id` int(10) NOT NULL,
  `TimeTag` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Test_Data` json DEFAULT NULL,
  PRIMARY KEY (`Test_Id`),
  KEY `fk_Test_Events_1_idx` (`Admin_Id`),
  KEY `SubjectId_idx` (`Subject_Id`),
  KEY `GameId_idx` (`Game_Id`),
  CONSTRAINT `AdminId` FOREIGN KEY (`Admin_Id`) REFERENCES `Test_Administrators` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `GameId` FOREIGN KEY (`Game_Id`) REFERENCES `Test_Games` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `SubjectId` FOREIGN KEY (`Subject_Id`) REFERENCES `Test_Subjects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Test_Events`
--

LOCK TABLES `Test_Events` WRITE;
/*!40000 ALTER TABLE `Test_Events` DISABLE KEYS */;
/*!40000 ALTER TABLE `Test_Events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Test_Games`
--

DROP TABLE IF EXISTS `Test_Games`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Test_Games` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Test_Games`
--

LOCK TABLES `Test_Games` WRITE;
/*!40000 ALTER TABLE `Test_Games` DISABLE KEYS */;
INSERT INTO `Test_Games` VALUES (3,'Memory Game'),(2,'Ring-and-Wire'),(1,'Whack-a-Mole');
/*!40000 ALTER TABLE `Test_Games` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Test_Subjects`
--

DROP TABLE IF EXISTS `Test_Subjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Test_Subjects` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Test_Subjects`
--

LOCK TABLES `Test_Subjects` WRITE;
/*!40000 ALTER TABLE `Test_Subjects` DISABLE KEYS */;
INSERT INTO `Test_Subjects` VALUES (1,'Patient1'),(2,'Patient2'),(3,'Patient3'),(4,'Patient4'),(5,'Patient6'),(6,'Doe, Jane');
/*!40000 ALTER TABLE `Test_Subjects` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-04 22:08:29
