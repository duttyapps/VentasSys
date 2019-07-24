CREATE DATABASE  IF NOT EXISTS `ventassys` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ventassys`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: ventassys
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `almacen_cab`
--

DROP TABLE IF EXISTS `almacen_cab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `almacen_cab` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo_almacen` char(1) DEFAULT NULL,
  `tienda` char(2) DEFAULT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `fecha_salida` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `almacen_cab`
--


--
-- Table structure for table `almacen_det`
--

DROP TABLE IF EXISTS `almacen_det`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `almacen_det` (
  `ID_CAB` int(11) NOT NULL,
  `ID_PRODUCTO` int(11) NOT NULL,
  `DESC_PRODUCTO` varchar(250) NOT NULL,
  `CANTIDAD` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `almacen_det`
--


--
-- Table structure for table `cotizacion_cab`
--

DROP TABLE IF EXISTS `cotizacion_cab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cotizacion_cab` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COD_TIENDA` char(2) NOT NULL,
  `FECHA_EMISION` date NOT NULL,
  `CANTIDAD` int(11) NOT NULL,
  `MONTO_TOTAL` double NOT NULL,
  `CLIENTE_DOC` varchar(45) NOT NULL,
  `USUARIO` varchar(45) NOT NULL,
  `DENOMINACION` varchar(250) DEFAULT NULL,
  `TIPO_COTIZACION` char(2) NOT NULL,
  `DIAS_ALQUILER` int(11) DEFAULT '0',
  PRIMARY KEY (`ID`,`TIPO_COTIZACION`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cotizacion_cab`
--
-- Table structure for table `cotizacion_det`
--

DROP TABLE IF EXISTS `cotizacion_det`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cotizacion_det` (
  `ID_CAB` int(11) NOT NULL,
  `ID_PRODUCTO` int(11) NOT NULL,
  `DESC_PRODUCTO` varchar(250) NOT NULL,
  `CANTIDAD` int(11) NOT NULL DEFAULT '1',
  `PRECIO_UNIT` float NOT NULL DEFAULT '0',
  `MONTO_TOTAL` float NOT NULL DEFAULT '0',
  `COSTO_UNIT` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cotizacion_det`
--

--
-- Table structure for table `documento_cab`
--

DROP TABLE IF EXISTS `documento_cab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `documento_cab` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NUMERO_DOC` int(11) NOT NULL,
  `COD_TIENDA` char(2) NOT NULL,
  `TIPO_VENTA` char(2) NOT NULL,
  `FORMA_PAGO` char(2) NOT NULL,
  `FECHA_EMISION` date NOT NULL,
  `CANTIDAD` int(11) NOT NULL,
  `MONTO_TOTAL` double NOT NULL,
  `MONTO_RECIBIDO` double NOT NULL,
  `MONTO_VUELTO` double NOT NULL,
  `ESTADO_CREDITO` char(1) DEFAULT NULL,
  `CLIENTE_DOC` varchar(45) NOT NULL,
  `USUARIO` varchar(45) NOT NULL,
  `ANULADO` char(1) NOT NULL DEFAULT '0',
  `USUARIO_ANUL` varchar(45) DEFAULT NULL,
  `FECHA_ANUL` date DEFAULT NULL,
  `MOTIVO_ANUL` varchar(250) DEFAULT NULL,
  `NUMERO_GUIA` varchar(45) DEFAULT NULL,
  `ALQUILER_INICIO` date DEFAULT NULL,
  `ALQUILER_ENTREGA` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_DOC_CAB` (`NUMERO_DOC`),
  KEY `IDX_TIENDA` (`COD_TIENDA`),
  KEY `IDX_TIPO_VENTA` (`TIPO_VENTA`),
  KEY `FK_FORMA_PAGO_idx` (`FORMA_PAGO`),
  KEY `IDX_ID` (`ID`),
  CONSTRAINT `FK_COD_TIENDA` FOREIGN KEY (`COD_TIENDA`) REFERENCES `sys_tienda` (`COD_TIENDA`),
  CONSTRAINT `FK_FORMA_PAGO` FOREIGN KEY (`FORMA_PAGO`) REFERENCES `sys_forma_pago` (`COD_FORMA_PAGO`),
  CONSTRAINT `FK_TIPO_VENTA` FOREIGN KEY (`TIPO_VENTA`) REFERENCES `sys_tipo_venta` (`CODIGO`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documento_cab`
--

--
-- Table structure for table `documento_det`
--

DROP TABLE IF EXISTS `documento_det`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `documento_det` (
  `ID_CAB` int(11) NOT NULL,
  `NUMERO_CAB` int(11) NOT NULL,
  `ID_PRODUCTO` int(11) NOT NULL,
  `DESC_PRODUCTO` varchar(250) NOT NULL,
  `CANTIDAD` int(11) NOT NULL DEFAULT '1',
  `PRECIO_UNIT` float NOT NULL DEFAULT '0',
  `MONTO_TOTAL` float NOT NULL DEFAULT '0',
  `COSTO_UNIT` double NOT NULL,
  KEY `IDX_DOC_CAB` (`NUMERO_CAB`),
  KEY `FK_PROD_ID_idx` (`ID_PRODUCTO`),
  KEY `IDX_ID_CAB` (`ID_CAB`),
  CONSTRAINT `FK_ID_CAB` FOREIGN KEY (`ID_CAB`) REFERENCES `documento_cab` (`ID`),
  CONSTRAINT `FK_NUMERO_CAB` FOREIGN KEY (`NUMERO_CAB`) REFERENCES `documento_cab` (`NUMERO_DOC`),
  CONSTRAINT `FK_PROD_ID` FOREIGN KEY (`ID_PRODUCTO`) REFERENCES `sys_productos` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documento_det`
--

--
-- Table structure for table `segt_configuracion`
--

DROP TABLE IF EXISTS `segt_configuracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `segt_configuracion` (
  `RUC` varchar(16) NOT NULL,
  `RAZON_SOCIAL` varchar(45) NOT NULL,
  `DIRECCION` varchar(150) DEFAULT NULL,
  `TELEFONO` varchar(15) DEFAULT NULL,
  `IGV` float NOT NULL DEFAULT '0.18',
  `TIPO_CAMBIO` float NOT NULL DEFAULT '3.25',
  `TIENDA` char(2) NOT NULL,
  PRIMARY KEY (`RUC`),
  UNIQUE KEY `RUC_UNIQUE` (`RUC`),
  UNIQUE KEY `TIENDA_UNIQUE` (`TIENDA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `segt_configuracion`
--

LOCK TABLES `segt_configuracion` WRITE;
/*!40000 ALTER TABLE `segt_configuracion` DISABLE KEYS */;
INSERT INTO `segt_configuracion` VALUES ('20136704631','Osmosis Perú','Avenida Tienda 123 Santa Anita','2358585',0.18,3.25,'01');
/*!40000 ALTER TABLE `segt_configuracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `segt_usuarios`
--

DROP TABLE IF EXISTS `segt_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `segt_usuarios` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NRO_DOC` varchar(45) NOT NULL,
  `USERNAME` varchar(45) NOT NULL,
  `PASSWORD` varchar(45) NOT NULL,
  `NOMBRES` varchar(80) NOT NULL,
  `SEXO` char(1) NOT NULL,
  `FECHA_NAC` date NOT NULL,
  `EMAIL` varchar(45) DEFAULT NULL,
  `TELEFONO` varchar(45) DEFAULT NULL,
  `FECHA_REG` date NOT NULL,
  `RANGO` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `segt_usuarios`
--

LOCK TABLES `segt_usuarios` WRITE;
/*!40000 ALTER TABLE `segt_usuarios` DISABLE KEYS */;
INSERT INTO `segt_usuarios` VALUES (3,'76187871','76187871','1234','oscar','','1995-03-18','ohuingo.19@hotmailcom','09182099','2019-07-01','A'),(4,'76287871','76287871','123456','pollon','','2019-07-04','pollon@gmal.com','2543253','2019-07-04','A'),(5,'22353453','admin','admin','carce','M','2019-01-02','carce@cineplanet.com.pe','2543532','2019-07-05','A');
/*!40000 ALTER TABLE `segt_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_abonos`
--

DROP TABLE IF EXISTS `sys_abonos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_abonos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_CAB` int(11) NOT NULL,
  `NRO_DOCUMENTO` int(11) NOT NULL,
  `COD_TIENDA` char(2) NOT NULL,
  `FECHA_REG` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `USUARIO` varchar(45) NOT NULL,
  `MONTO` double(5,2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `FK_COD_TIENDA_idx` (`COD_TIENDA`),
  KEY `FK_AB_COD_TIENDA_idx` (`COD_TIENDA`),
  KEY `FK_AB_NRO_DOC_idx` (`NRO_DOCUMENTO`),
  KEY `FK_AB_ID_CAB` (`ID_CAB`),
  CONSTRAINT `FK_AB_COD_TIENDA` FOREIGN KEY (`COD_TIENDA`) REFERENCES `sys_tienda` (`COD_TIENDA`),
  CONSTRAINT `FK_AB_ID_CAB` FOREIGN KEY (`ID_CAB`) REFERENCES `documento_cab` (`ID`),
  CONSTRAINT `FK_AB_NRO_DOC` FOREIGN KEY (`NRO_DOCUMENTO`) REFERENCES `documento_cab` (`NUMERO_DOC`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_abonos`
--


--
-- Table structure for table `sys_alquiler`
--

DROP TABLE IF EXISTS `sys_alquiler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_alquiler` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `FECHA_ENT` date NOT NULL,
  `HORA_ENT` time NOT NULL,
  `FECHA_DEV` date NOT NULL,
  `HORA_DEV` time NOT NULL,
  `CLIENTE` varchar(450) NOT NULL,
  `DETALLE` varchar(4500) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_alquiler`
--


--
-- Table structure for table `sys_bancos`
--

DROP TABLE IF EXISTS `sys_bancos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_bancos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(45) NOT NULL,
  `FECHA_REG` date NOT NULL,
  `ACTIVO` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_SYS_BANCOS` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_bancos`
--

LOCK TABLES `sys_bancos` WRITE;
/*!40000 ALTER TABLE `sys_bancos` DISABLE KEYS */;
INSERT INTO `sys_bancos` VALUES (1,'Interbank','2017-10-15','1'),(2,'BBVA Continental','2017-10-15','1');
/*!40000 ALTER TABLE `sys_bancos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_cat_productos`
--

DROP TABLE IF EXISTS `sys_cat_productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_cat_productos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(45) NOT NULL,
  `ACTIVO` char(1) NOT NULL DEFAULT '1',
  `FECHA_REGISTRO` date NOT NULL,
  `ELIMINADO` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_CAT_PROD` (`ID`,`NOMBRE`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_cat_productos`
--

--
-- Table structure for table `sys_clientes`
--

DROP TABLE IF EXISTS `sys_clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_clientes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRES` varchar(80) NOT NULL,
  `APELLIDOS` varchar(145) DEFAULT NULL,
  `DNI` varchar(12) NOT NULL,
  `DIRECCION` varchar(100) NOT NULL,
  `TELEFONO` varchar(15) DEFAULT NULL,
  `EMAIL` varchar(80) DEFAULT NULL,
  `FECHA_REG` date DEFAULT NULL,
  `TIPO` char(1) NOT NULL COMMENT 'N=Natural, E=Empresa',
  `POSIBLE_CLIENTE` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `DNI_UNIQUE` (`DNI`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_clientes`
--


--
-- Table structure for table `sys_correlativo_venta`
--

DROP TABLE IF EXISTS `sys_correlativo_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_correlativo_venta` (
  `TIPO_VENTA` varchar(2) NOT NULL,
  `CORRELATIVO` varchar(10) NOT NULL,
  PRIMARY KEY (`TIPO_VENTA`),
  UNIQUE KEY `TIPO_VENTA_UNIQUE` (`TIPO_VENTA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_correlativo_venta`
--

LOCK TABLES `sys_correlativo_venta` WRITE;
/*!40000 ALTER TABLE `sys_correlativo_venta` DISABLE KEYS */;
INSERT INTO `sys_correlativo_venta` VALUES ('BO','0'),('FA','0'),('GR','0'),('NC','0');
/*!40000 ALTER TABLE `sys_correlativo_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_depositos`
--

DROP TABLE IF EXISTS `sys_depositos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_depositos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_BANCO` int(11) NOT NULL,
  `FECHA_EMISION` date NOT NULL,
  `USUARIO` varchar(45) NOT NULL,
  `MONTO` double(8,2) NOT NULL,
  `FECHA_HORA` datetime NOT NULL,
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_SYS_DEPOSITOS` (`ID`,`ID_BANCO`,`FECHA_EMISION`,`USUARIO`),
  KEY `FK_ID_BANCO_idx` (`ID_BANCO`),
  CONSTRAINT `FK_ID_BANCO` FOREIGN KEY (`ID_BANCO`) REFERENCES `sys_bancos` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_depositos`
--


--
-- Table structure for table `sys_distribucion`
--

DROP TABLE IF EXISTS `sys_distribucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_distribucion` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FECHA` date NOT NULL,
  `HORA` time NOT NULL,
  `DESTINO` varchar(450) DEFAULT NULL,
  `ENCARGADO` varchar(450) DEFAULT NULL,
  `DETALLE` varchar(650) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `id_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_distribucion`
--


--
-- Table structure for table `sys_forma_pago`
--

DROP TABLE IF EXISTS `sys_forma_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_forma_pago` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COD_FORMA_PAGO` char(2) NOT NULL,
  `DES_FORMA_PAGO` varchar(45) NOT NULL,
  `ESTADO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID`,`COD_FORMA_PAGO`),
  UNIQUE KEY `COD_FORMA_PAGO_UNIQUE` (`COD_FORMA_PAGO`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_FORMA_PAGO` (`COD_FORMA_PAGO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_forma_pago`
--

LOCK TABLES `sys_forma_pago` WRITE;
/*!40000 ALTER TABLE `sys_forma_pago` DISABLE KEYS */;
INSERT INTO `sys_forma_pago` VALUES (1,'CO','Contado','1'),(2,'CR','Crédito','0'),(3,'AL','Alquiler','1');
/*!40000 ALTER TABLE `sys_forma_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_guia_remision`
--

DROP TABLE IF EXISTS `sys_guia_remision`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_guia_remision` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NUMERO_GUIA` int(11) NOT NULL,
  `COD_TIENDA` char(2) NOT NULL,
  `FECHA_EMISION` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `FECHA_TRASLADO` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CANTIDAD` int(11) NOT NULL,
  `CLIENTE_DOC` varchar(45) NOT NULL,
  `TIPO_DOC_REF` char(2) NOT NULL,
  `NUMERO_DOC_REF` int(11) NOT NULL,
  `COD_MOTIVO` char(2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_guia_remision`
--


--
-- Table structure for table `sys_mantenimiento`
--

DROP TABLE IF EXISTS `sys_mantenimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_mantenimiento` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FECHA` date DEFAULT NULL,
  `CLIENTE` varchar(450) DEFAULT NULL,
  `PRODUCTO` int(11) DEFAULT NULL,
  `FECHA_6M` date DEFAULT NULL,
  `FECHA_12M` date DEFAULT NULL,
  `FECHA_24M` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `id_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_mantenimiento`
--

--
-- Table structure for table `sys_medios_contacto`
--

DROP TABLE IF EXISTS `sys_medios_contacto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_medios_contacto` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(450) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_medios_contacto`
--

LOCK TABLES `sys_medios_contacto` WRITE;
/*!40000 ALTER TABLE `sys_medios_contacto` DISABLE KEYS */;
INSERT INTO `sys_medios_contacto` VALUES (1,'Teléfono'),(2,'Facebook'),(3,'Whatsapp'),(4,'Página Web'),(5,'Recomendación');
/*!40000 ALTER TABLE `sys_medios_contacto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_motivos_guia`
--

DROP TABLE IF EXISTS `sys_motivos_guia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_motivos_guia` (
  `COD_MOTIVO` char(2) NOT NULL,
  `MOTIVO_DES` varchar(145) NOT NULL,
  PRIMARY KEY (`COD_MOTIVO`),
  UNIQUE KEY `COD_MOTIVO_UNIQUE` (`COD_MOTIVO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_motivos_guia`
--

LOCK TABLES `sys_motivos_guia` WRITE;
/*!40000 ALTER TABLE `sys_motivos_guia` DISABLE KEYS */;
INSERT INTO `sys_motivos_guia` VALUES ('00','Otros'),('01','Venta'),('02','Venta sujeta a confirmación del comprador'),('03','Compra'),('04','Consignación'),('05','Devolución'),('06','Traslado entre establecimiento de una misma empresa'),('07','Traslado de bienes para transformación'),('08','Recojo de bienes transformados'),('09','Traslado por emisor itinerante de comprobante de pago'),('10','Traslado de zona primaria'),('11','Importación'),('12','Exportación');
/*!40000 ALTER TABLE `sys_motivos_guia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_pagos_proveedores`
--

DROP TABLE IF EXISTS `sys_pagos_proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_pagos_proveedores` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PROVEEDOR` int(11) NOT NULL,
  `FECHA_EMISION` date NOT NULL,
  `NRO_FACTURA` int(11) NOT NULL,
  `USUARIO` varchar(45) NOT NULL,
  `MONTO` double(8,2) NOT NULL,
  `FECHA_HORA` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `IDX_PAGOS_PROVEEDORES` (`ID`,`ID_PROVEEDOR`,`FECHA_EMISION`,`NRO_FACTURA`),
  CONSTRAINT `FK_ID_PROVEEDOR` FOREIGN KEY (`ID`) REFERENCES `sys_proveedores` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_pagos_proveedores`
--


--
-- Table structure for table `sys_productos`
--

DROP TABLE IF EXISTS `sys_productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_productos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CODIGO` varchar(50) DEFAULT NULL,
  `ID_CAT` int(11) DEFAULT NULL,
  `ID_PROVEEDOR` int(11) DEFAULT NULL,
  `NOMBRE` varchar(45) DEFAULT NULL,
  `COSTO` float DEFAULT NULL,
  `PRECIO` float DEFAULT NULL,
  `USUARIO` varchar(45) DEFAULT NULL,
  `FECHA_REG` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ACTIVO` char(1) DEFAULT '1',
  `ELIMINADO` char(1) DEFAULT '0',
  `MEDIDA` float DEFAULT NULL,
  `PESO` float DEFAULT NULL,
  `ALQUILER` char(1) DEFAULT NULL,
  `MONTO_ALQUILER` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `CODIGO_UNIQUE` (`CODIGO`),
  KEY `IDX_PRODUCTOS` (`ID`,`NOMBRE`),
  KEY `FK_CAT_PROD` (`ID_CAT`),
  KEY `IDX_CAT` (`ID_CAT`),
  KEY `IDX_ID_PROVEEDOR` (`ID_PROVEEDOR`),
  CONSTRAINT `FK_CAT_PROD` FOREIGN KEY (`ID_CAT`) REFERENCES `sys_cat_productos` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_productos`
--


--
-- Table structure for table `sys_programacion_mantenimiento_cab`
--

DROP TABLE IF EXISTS `sys_programacion_mantenimiento_cab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_programacion_mantenimiento_cab` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NUM_DOC` int(11) DEFAULT NULL,
  `TIENDA` char(2) DEFAULT NULL,
  `TIPO_PERSONA` char(1) DEFAULT NULL,
  `CLIENTE` varchar(45) DEFAULT NULL,
  `USUARIO` varchar(45) DEFAULT NULL,
  `FECHA_REGISTRO` datetime DEFAULT NULL,
  `ESTADO` char(2) DEFAULT NULL,
  `FECHA_SALIDA` date DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_programacion_mantenimiento_cab`
--


--
-- Table structure for table `sys_programacion_mantenimiento_det`
--

DROP TABLE IF EXISTS `sys_programacion_mantenimiento_det`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_programacion_mantenimiento_det` (
  `ID_CAB` int(11) NOT NULL,
  `TIPO_MANTENIMIENTO` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_programacion_mantenimiento_det`
--

--
-- Table structure for table `sys_proveedores`
--

DROP TABLE IF EXISTS `sys_proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_proveedores` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(45) NOT NULL,
  `DIRECCION` varchar(45) DEFAULT NULL,
  `TELEFONO` varchar(15) DEFAULT NULL,
  `ACTIVO` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_proveedores`
--

--
-- Table structure for table `sys_stock_producto`
--

DROP TABLE IF EXISTS `sys_stock_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_stock_producto` (
  `PRODUCTO_ID` int(11) NOT NULL,
  `CANTIDAD` int(11) NOT NULL,
  `TIENDA` char(2) NOT NULL DEFAULT '01',
  KEY `IDX_TIENDA` (`TIENDA`),
  KEY `IDX_PRODUCTO` (`PRODUCTO_ID`),
  CONSTRAINT `FK_PRODUCTO_ID` FOREIGN KEY (`PRODUCTO_ID`) REFERENCES `sys_productos` (`ID`),
  CONSTRAINT `FK_TIENDA_ID` FOREIGN KEY (`TIENDA`) REFERENCES `sys_tienda` (`COD_TIENDA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_stock_producto`
--

--
-- Table structure for table `sys_tienda`
--

DROP TABLE IF EXISTS `sys_tienda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_tienda` (
  `COD_TIENDA` char(2) NOT NULL,
  `NOMBRE_TIENDA` varchar(45) NOT NULL,
  `DIRECCION` varchar(145) NOT NULL,
  `DISTRITO` varchar(45) NOT NULL,
  `PROVINCIA` varchar(45) NOT NULL,
  `DEPARTAMENTO` varchar(45) NOT NULL,
  `ACTIVO` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`COD_TIENDA`),
  UNIQUE KEY `COD_TIENDA_UNIQUE` (`COD_TIENDA`),
  KEY `IDX_COD_TIENDA` (`COD_TIENDA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_tienda`
--

LOCK TABLES `sys_tienda` WRITE;
/*!40000 ALTER TABLE `sys_tienda` DISABLE KEYS */;
INSERT INTO `sys_tienda` VALUES ('01','Almacen Principal','Dirección 344','Surco','Lima','Lima','1'),('02','Almacen Barcelona','Calle 3','Cercado','Lima','Lima','1'),('03','Taller','Avenida 442','La Molina','Lima','Lima','1'),('04','Distribuidores','Avenida 432','Lima','Lima','Lima','1');
/*!40000 ALTER TABLE `sys_tienda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_tipo_mantenimiento`
--

DROP TABLE IF EXISTS `sys_tipo_mantenimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_tipo_mantenimiento` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(150) DEFAULT NULL,
  `ESTADO` char(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_tipo_mantenimiento`
--

LOCK TABLES `sys_tipo_mantenimiento` WRITE;
/*!40000 ALTER TABLE `sys_tipo_mantenimiento` DISABLE KEYS */;
INSERT INTO `sys_tipo_mantenimiento` VALUES (1,'MANTENIMIENTO ROA1-1','1'),(2,'MANTENIMIENTO ROA1-2','1'),(3,'MANTENIMIENTO ROA1-3','1'),(4,'MANTENIMIENTO RO400-1','1'),(5,'MANTENIMIENTO RO400-2','1'),(6,'MANTENIMIENTO RO400-3','1'),(7,'FILTRO ROA1-2','1'),(8,'FILTRO ROA1-3','1'),(9,'FILTRO RO400-2','1'),(10,'FILTRO RO400-3','1'),(11,'MANTENIMIENTO DISPENSADORES','1');
/*!40000 ALTER TABLE `sys_tipo_mantenimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_tipo_moneda`
--

DROP TABLE IF EXISTS `sys_tipo_moneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_tipo_moneda` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(45) NOT NULL,
  `SIMBOLO` varchar(5) NOT NULL,
  `TIPO_CAMBIO` float NOT NULL DEFAULT '0',
  `ACTIVO` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_tipo_moneda`
--

LOCK TABLES `sys_tipo_moneda` WRITE;
/*!40000 ALTER TABLE `sys_tipo_moneda` DISABLE KEYS */;
INSERT INTO `sys_tipo_moneda` VALUES (1,'Nuevo Sol','S/.',1,'1'),(2,'Dolar','$',3.2,'0'),(3,'Euro','€',3.8,'0');
/*!40000 ALTER TABLE `sys_tipo_moneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_tipo_venta`
--

DROP TABLE IF EXISTS `sys_tipo_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_tipo_venta` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CODIGO` char(2) NOT NULL,
  `DESCRIPCION` varchar(45) NOT NULL,
  `ACTIVO` char(1) DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `CODIGO_UNIQUE` (`CODIGO`),
  UNIQUE KEY `DESCRIPCION_UNIQUE` (`DESCRIPCION`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_tipo_venta`
--

LOCK TABLES `sys_tipo_venta` WRITE;
/*!40000 ALTER TABLE `sys_tipo_venta` DISABLE KEYS */;
INSERT INTO `sys_tipo_venta` VALUES (1,'BO','Boleta de Venta','1'),(2,'FA','Factura','1'),(3,'NC','Nota de Crédito','0');
/*!40000 ALTER TABLE `sys_tipo_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'ventassys'
--
/*!50003 DROP FUNCTION IF EXISTS `GET_CORRELATIVO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GET_CORRELATIVO`(PSTR_TIPO_VENTA CHAR(2)) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
DECLARE CORRELATIVO INT;

    SET CORRELATIVO = (SELECT v.CORRELATIVO FROM sys_correlativo_venta v WHERE V.TIPO_VENTA = PSTR_TIPO_VENTA);
    RETURN CORRELATIVO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_get_alerta_cotizacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_alerta_cotizacion`()
BEGIN

select DATE_FORMAT(c.fecha_emision, "%d/%m/%Y") as fecha_emision, c.cliente_doc, concat(s.nombres, ' ', s.apellidos) as nombres, s.telefono, case c.tipo_cotizacion when 'AL' then 'ALQUILER' else 'COMPRA' end as tipo_cotizacion, c.dias_alquiler, c.cantidad, c.monto_total from cotizacion_cab c left join sys_clientes s on c.cliente_doc = s.dni;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_get_Almacen_productos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_Almacen_productos`(in pstr_codigo varchar(50), in pstr_producto varchar(50))
BEGIN

		select sp.id, sp.codigo, sp.nombre, sp.fecha_reg, dc.cod_tienda, dc.fecha_emision, ssp.cantidad, 'venta'  From  documento_cab  dc 
			inner join documento_det dd on dc.numero_doc = dd.numero_cab
			inner join sys_productos sp on dd.id_producto = sp.id
			inner join sys_stock_producto ssp on ssp.producto_id = sp.id
			where
				forma_pago = 'CO'
                and (ifnull(sp.codigo,'') like concat('%', ifnull(pstr_codigo, ''), '%')
				or sp.nombre like concat('%', ifnull(pstr_producto, ''), '%'))
			union    
		select sp.id, sp.codigo, sp.nombre, sp.fecha_reg, dc.tienda, dc.fecha_ingreso, dd.cantidad, case when dc.tipo_almacen = 'M' then 'Mantenimiento' else 'Taller' end  From  almacen_cab  dc 
			inner join almacen_det dd on dc.id = dd.id_cab
			inner join sys_productos sp on dd.id_producto = sp.id           
            where 
                 (ifnull(sp.codigo,'') like concat('%', ifnull(pstr_codigo, ''), '%')
				or sp.nombre like concat('%', ifnull(pstr_producto, ''), '%'));


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_GET_GUIA_REMISION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_GET_GUIA_REMISION`(IN PSTR_TIPO_DOC CHAR(2), IN PSTR_NRO_DOC INT, IN PSTR_TIENDA CHAR(2))
BEGIN
  select c.*,
	r.FECHA_EMISION,
    r.FECHA_TRASLADO,
    r.NUMERO_GUIA,
    g.MOTIVO_DES,
    t.NOMBRES,
    t.APELLIDOS,
    t.DIRECCION
 from documento_Cab c 
	INNER JOIN sys_guia_remision r 
		on r.NUMERO_DOC_REF = c.numero_doc and 
			c.tipo_venta = r.TIPO_DOC_REF and 
            c.cod_tienda = r.cod_tienda
	left join sys_motivos_guia g
		on g.COD_MOTIVO = r.COD_MOTIVO
	left join sys_clientes t
		on t.DNI = c.cliente_doc
	where c.numero_doc = PSTR_NRO_DOC
    and c.tipo_venta = PSTR_TIPO_DOC
    and c.cod_tienda = PSTR_TIENDA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_get_producto_Alerta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_producto_Alerta`()
BEGIN
	select p.id, p.nombre, p.costo, p.precio, s.cantidad from SYS_PRODUCTOS p 
		inner join SYS_STOCK_PRODUCTO s on p.id = s.producto_id
		where s.cantidad<50;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_GET_TIPO_MONEDA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_GET_TIPO_MONEDA`()
BEGIN
SELECT ID, SIMBOLO, DESCRIPCION, TIPO_CAMBIO FROM SYS_TIPO_MONEDA WHERE ACTIVO = '1' ORDER BY ID ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SEGT_GET_CONFIGURACION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SEGT_GET_CONFIGURACION`()
BEGIN
SELECT * FROM SEGT_CONFIGURACION;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SEGT_LOGIN_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SEGT_LOGIN_USUARIO`(IN `USER` VARCHAR(45), IN `PASS` VARCHAR(50))
BEGIN
SELECT 
    NOMBRES, RANGO
FROM
    SEGT_USUARIOS
WHERE
    USERNAME = USER AND PASSWORD = PASS;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_EMITIR_GUIA_REMISION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_EMITIR_GUIA_REMISION`(OUT `RETVAL` VARCHAR(250), IN PSTR_NRO_GUIA VARCHAR(20), IN PSTR_COD_TIENDA CHAR(2), IN PSTR_FECHA_TRASLADO VARCHAR(20), IN PTR_CANTIDAD INT, IN PSTR_CLIENTE VARCHAR(50), IN PSTR_TIPO_DOC_REF CHAR(2), IN PSTR_NRO_DOC_REF VARCHAR(20), IN PSTR_MOTIVO CHAR(2))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO `sys_guia_remision` (
 `NUMERO_GUIA`, 
 `COD_TIENDA`, 
 `FECHA_EMISION`, 
 `FECHA_TRASLADO`, 
 `CANTIDAD`, 
 `CLIENTE_DOC`, 
 `TIPO_DOC_REF`, 
 `NUMERO_DOC_REF`, 
 `COD_MOTIVO`
 ) 
 VALUES (
 PSTR_NRO_GUIA, 
 PSTR_COD_TIENDA, 
 NOW(), 
 PSTR_FECHA_TRASLADO, 
 PTR_CANTIDAD, 
 PSTR_CLIENTE, 
 PSTR_TIPO_DOC_REF, 
 PSTR_NRO_DOC_REF, 
 PSTR_MOTIVO
 );
 
UPDATE `documento_cab` 
SET 
    `NUMERO_GUIA` = PSTR_NRO_GUIA
WHERE
    `TIPO_VENTA` = PSTR_TIPO_DOC_REF
        AND NUMERO_DOC = PSTR_NRO_DOC_REF
        AND COD_TIENDA = PSTR_COD_TIENDA;

CALL SP_SYS_SET_CORRELATIVO_VENTA("GR");

SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARALMACEN_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARALMACEN_CAB`(OUT `RETVAL` VARCHAR(250), OUT `RETID` INT, IN `PSTR_TIENDA` CHAR(2), IN `PSTR_CANTIDAD` INT, IN `PSTR_USUARIO` VARCHAR(50), IN `PSTR_TIPO_ALMACEN` CHAR(1), IN PSTR_FECHA_FIN VARCHAR(20))
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
	
INSERT INTO ALMACEN_CAB(
		TIPO_ALMACEN,
        TIENDA,
        USUARIO,
        CANTIDAD,
        FECHA_INGRESO,
        FECHA_SALIDA
		)
	VALUES(
		PSTR_TIPO_ALMACEN,
        PSTR_TIENDA,
        PSTR_USUARIO,
        PSTR_CANTIDAD,
        CURDATE(),
        str_to_date(PSTR_FECHA_FIN, '%d/%m/%Y')
        );

SELECT '1' INTO RETVAL;
SELECT LAST_INSERT_ID() INTO RETID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARALMACEN_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARALMACEN_DET`(OUT `RETVAL` VARCHAR(250), IN `PSTR_ID_CAB` INT, IN `PSTR_ID_PRODUCTO` INT, IN `PSTR_DESC_PRODUCTO` VARCHAR(500), IN `PSTR_CANTIDAD` INT)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO almacen_det
 VALUES (
 PSTR_ID_CAB,
 PSTR_ID_PRODUCTO,
 PSTR_DESC_PRODUCTO,
 PSTR_CANTIDAD
 );

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARCOTIZACION_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARCOTIZACION_CAB`(OUT `RETVAL` VARCHAR(250), OUT `RETID` INT, IN `PSTR_TIENDA` CHAR(2), IN `PSTR_CANTIDAD` INT, IN `PSTR_MONTO_TOTAL` DOUBLE, IN `PSTR_CLIENTE` VARCHAR(15), IN `PSTR_USUARIO` VARCHAR(50), IN `PSTR_TIPO_COTIZACION` CHAR(2), IN `PSTR_DIAS_ALQUILER` INT,  IN `PSTR_DENOMINACION` VARCHAR(250))
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
INSERT INTO `cotizacion_cab`
(`COD_TIENDA`,
`FECHA_EMISION`,
`CANTIDAD`,
`MONTO_TOTAL`,
`CLIENTE_DOC`,
`USUARIO`,
`TIPO_COTIZACION`,
DIAS_ALQUILER,
DENOMINACION)
VALUES
(PSTR_TIENDA,
curdate(),
PSTR_CANTIDAD,
PSTR_MONTO_TOTAL,
PSTR_CLIENTE,
PSTR_USUARIO,
PSTR_TIPO_COTIZACION,
PSTR_DIAS_ALQUILER,
PSTR_DENOMINACION);

SELECT '1' INTO RETVAL;
SELECT LAST_INSERT_ID() INTO RETID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARCOTIZACION_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARCOTIZACION_DET`(OUT `RETVAL` VARCHAR(250), IN `PSTR_ID_CAB` INT, IN `PSTR_ID_PRODUCTO` INT, IN `PSTR_DESC_PRODUCTO` VARCHAR(500), IN `PSTR_CANTIDAD` INT, IN `PSTR_PRECIO_UNIT` DOUBLE, IN `PSTR_MONTO_TOTAL` DOUBLE, IN PSTR_CLIENTE INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO cotizacion_det
 VALUES (
 PSTR_ID_CAB,
 PSTR_ID_PRODUCTO,
 PSTR_DESC_PRODUCTO,
 PSTR_CANTIDAD,
 ROUND(PSTR_PRECIO_UNIT, 2),
 ROUND(PSTR_MONTO_TOTAL, 2),
 ROUND((SELECT COSTO FROM SYS_PRODUCTOS WHERE ID = PSTR_ID_PRODUCTO), 2)
 );

SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARPROG_MANTENIMIENTO_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARPROG_MANTENIMIENTO_CAB`(OUT `RETVAL` VARCHAR(250), OUT `RETID` INT, IN PSTR_NUM_DOC INT, IN PSTR_TIENDA CHAR(2), IN PSTR_TIPO_PERSONA CHAR(1),  IN PSTR_CLIENTE VARCHAR(20), IN PSTR_USUARIO VARCHAR(20), IN PSTR_ESTADO CHAR(2), IN PSTR_FECHA_SALIDA VARCHAR(20))
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
	
	INSERT INTO `sys_programacion_mantenimiento_cab`
						(`NUM_DOC`,
                        `TIENDA`,
						`TIPO_PERSONA`,
						`CLIENTE`,
						`USUARIO`,
						`FECHA_REGISTRO`,
						`ESTADO`,
                        FECHA_SALIDA)
						VALUES
						(PSTR_NUM_DOC,
                        PSTR_TIENDA,
						PSTR_TIPO_PERSONA,
						PSTR_CLIENTE,
						PSTR_USUARIO,
						CURDATE(),
						PSTR_ESTADO,
                        STR_TO_DATE(PSTR_FECHA_SALIDA, "%d/%m/%Y"));

SELECT '1' INTO RETVAL;
SELECT LAST_INSERT_ID() INTO RETID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARPROG_MANTENIMIENTO_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARPROG_MANTENIMIENTO_DET`(OUT `RETVAL` VARCHAR(250), IN PSTR_NUM_DOC INT(11), IN PSTR_TIPO_MANTENIMIENTO INT(11))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;

INSERT INTO `sys_programacion_mantenimiento_det`
(`ID_CAB`,
`TIPO_MANTENIMIENTO`)
VALUES
(PSTR_NUM_DOC,
PSTR_TIPO_MANTENIMIENTO);


SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARVENTA_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARVENTA_CAB`(OUT `RETVAL` VARCHAR(250), OUT `RETID` INT, IN `PSTR_NUMERO_DOC` INT, IN `PSTR_COD_TIENDA` CHAR(2), IN `PSTR_TIPO_VENTA` VARCHAR(3), IN `PSTR_FORMA_PAGO` VARCHAR(3), IN `PSTR_CANTIDAD` INT, IN `PSTR_MONTO_TOTAL` DOUBLE, IN `PSTR_MONTO_RECIBIDO` DOUBLE, IN `PSTR_MONTO_VUELTO` DOUBLE, IN `PSTR_CLIENTE` VARCHAR(15), IN `PSTR_USUARIO` VARCHAR(50), IN `PSTR_ALQUILER_INICIO` VARCHAR(50), IN `PSTR_ALQUILER_ENTREGA` VARCHAR(50))
BEGIN
DECLARE V_VUELTO double;
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 IF PSTR_FORMA_PAGO = 'CR' THEN
 SET V_VUELTO = 0;
 else
 SET V_VUELTO = PSTR_MONTO_VUELTO;
 END IF;
 
 INSERT INTO DOCUMENTO_CAB
 (
 NUMERO_DOC,
 COD_TIENDA,
 TIPO_VENTA,
 FORMA_PAGO,
 FECHA_EMISION,
 CANTIDAD,
 MONTO_TOTAL,
 MONTO_RECIBIDO,
 MONTO_VUELTO,
 CLIENTE_DOC,
 USUARIO,
 ALQUILER_INICIO,
 ALQUILER_ENTREGA
 )
 VALUES
 (
 PSTR_NUMERO_DOC,
 PSTR_COD_TIENDA,
 PSTR_TIPO_VENTA,
 PSTR_FORMA_PAGO,
 NOW(),
 PSTR_CANTIDAD,
 ROUND(PSTR_MONTO_TOTAL,2),
 ROUND(PSTR_MONTO_RECIBIDO,2),
 ROUND(V_VUELTO,2),
 PSTR_CLIENTE,
 PSTR_USUARIO,
 str_to_date(  PSTR_ALQUILER_INICIO, '%d/%m/%Y'),
 str_to_date(  PSTR_ALQUILER_ENTREGA, '%d/%m/%Y')
 );
 
 UPDATE sys_clientes SET POSIBLE_CLIENTE = 1 WHERE DNI = PSTR_USUARIO;
 
 CALL SP_SYS_SET_CORRELATIVO_VENTA(PSTR_TIPO_VENTA);
 
SELECT '1' INTO RETVAL;
SELECT LAST_INSERT_ID() INTO RETID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SET_GUARDARVENTA_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SET_GUARDARVENTA_DET`(OUT `RETVAL` VARCHAR(250), IN `PSTR_ID_CAB` INT, IN `PSTR_NUMBERO_CAB` INT, IN `PSTR_ID_PRODUCTO` INT, IN `PSTR_DESC_PRODUCTO` VARCHAR(500), IN `PSTR_CANTIDAD` INT, IN `PSTR_PRECIO_UNIT` DOUBLE, IN `PSTR_MONTO_TOTAL` DOUBLE, IN PSTR_CLIENTE INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO DOCUMENTO_DET
 VALUES (
 PSTR_ID_CAB,
 PSTR_NUMBERO_CAB,
 PSTR_ID_PRODUCTO,
 PSTR_DESC_PRODUCTO,
 PSTR_CANTIDAD,
 ROUND(PSTR_PRECIO_UNIT, 2),
 ROUND(PSTR_MONTO_TOTAL, 2),
 ROUND((SELECT COSTO FROM SYS_PRODUCTOS WHERE ID = PSTR_ID_PRODUCTO), 2)
 );
 
UPDATE SYS_STOCK_PRODUCTO 
SET 
    CANTIDAD = CANTIDAD - PSTR_CANTIDAD
WHERE
    PRODUCTO_ID = PSTR_ID_PRODUCTO;
 
 INSERT INTO SYS_MANTENIMIENTO(FECHA, CLIENTE, PRODUCTO, FECHA_6M, FECHA_12M, FECHA_24M)
	VALUES(curdate(), PSTR_CLIENTE, PSTR_ID_PRODUCTO, date_add(curdate(), INTERVAL 6 month), date_add(curdate(), INTERVAL 12 month),date_add(curdate(), INTERVAL 24 month));
 
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_ANULAR_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_ANULAR_VENTA`(OUT `RETVAL` VARCHAR(250), IN `PSTR_TIENDA_COD` CHAR(2), IN `PSTR_ID_CAB` INT, IN `PSTR_USUARIO` VARCHAR(50), IN `PSTR_MOTIVO` VARCHAR(250))
BEGIN
DECLARE V_ID_PRODUCTO INT;
DECLARE V_CANTIDAD INT;

DECLARE done INT DEFAULT FALSE;
DECLARE CUR_DET CURSOR FOR 
SELECT ID_PRODUCTO, CANTIDAD FROM DOCUMENTO_DET WHERE ID_CAB = PSTR_ID_CAB;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;

UPDATE DOCUMENTO_CAB 
SET 
    ANULADO = '1',
    USUARIO_ANUL = PSTR_USUARIO,
    FECHA_ANUL = NOW(),
    MOTIVO_ANUL = PSTR_MOTIVO
WHERE
    ID = PSTR_ID_CAB;
    
    OPEN CUR_DET;
    
read_loop: LOOP

     FETCH CUR_DET INTO V_ID_PRODUCTO, V_CANTIDAD;
     
     IF done THEN
      LEAVE read_loop;
    END IF;
     
UPDATE SYS_STOCK_PRODUCTO 
SET 
    CANTIDAD = CANTIDAD + V_CANTIDAD
WHERE
    PRODUCTO_ID = V_ID_PRODUCTO
        AND TIENDA = PSTR_TIENDA_COD;
     
     END LOOP;
     
    CLOSE CUR_DET;
    
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_CIERRE_CAJA_DEPOSITO_CUENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_CIERRE_CAJA_DEPOSITO_CUENTA`(IN PSTR_FECHA VARCHAR(15))
BEGIN
  select b.id, b.NOMBRE, sum(d.monto) as monto
from sys_depositos d 
	inner join sys_bancos b on b.ID = d.ID_BANCO
		where date_format(d.FECHA_EMISION,'%d/%m/%Y') = PSTR_FECHA
        group by b.ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_CIERRE_CAJA_PAGO_CREDITO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_CIERRE_CAJA_PAGO_CREDITO`(IN PSTR_FECHA VARCHAR(15), IN PSTR_TIENDA CHAR(2))
BEGIN
  select distinct
	(select count(*) from sys_abonos b 
	left join documento_cab c on c.NUMERO_DOC = b.NRO_DOCUMENTO and c.id = b.ID_CAB and b.COD_TIENDA = c.cod_tienda
		where anulado = '0' and  date_format(b.FECHA_REG,'%d/%m/%Y') = date_format(a.FECHA_REG,'%d/%m/%Y') and c.tipo_venta = 'BO' group by date_format(b.FECHA_REG,'%d/%m/%Y')) as  trx_boleta,
	(select sum(b.monto) from sys_abonos b 
	left join documento_cab c on c.NUMERO_DOC = b.NRO_DOCUMENTO and c.id = b.ID_CAB and b.COD_TIENDA = c.cod_tienda
		where anulado = '0' and  date_format(b.FECHA_REG,'%d/%m/%Y') = date_format(a.FECHA_REG,'%d/%m/%Y') and c.tipo_venta = 'BO' group by date_format(b.FECHA_REG,'%d/%m/%Y')) as  boleta,
    (select count(*) from sys_abonos b 
	left join documento_cab c on c.NUMERO_DOC = b.NRO_DOCUMENTO and c.id = b.ID_CAB and b.COD_TIENDA = c.cod_tienda
		where anulado = '0' and  date_format(b.FECHA_REG,'%d/%m/%Y') = date_format(a.FECHA_REG,'%d/%m/%Y') and c.tipo_venta = 'FA' group by date_format(b.FECHA_REG,'%d/%m/%Y')) as  trx_factura,
    (select sum(b.monto) from sys_abonos b 
	left join documento_cab c on c.NUMERO_DOC = b.NRO_DOCUMENTO and c.id = b.ID_CAB and b.COD_TIENDA = c.cod_tienda
		where anulado = '0' and  date_format(b.FECHA_REG,'%d/%m/%Y') = date_format(a.FECHA_REG,'%d/%m/%Y') and c.tipo_venta = 'FA' group by date_format(b.FECHA_REG,'%d/%m/%Y')) as  factura
from sys_abonos a
		where date_format(a.FECHA_REG,'%d/%m/%Y') = PSTR_FECHA
        AND  A.COD_TIENDA = PSTR_TIENDA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_CIERRE_CAJA_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_CIERRE_CAJA_PAGO_PROVEEDOR`(IN PSTR_FECHA VARCHAR(15))
BEGIN
  select s.ID, s.NOMBRE, sum(p.MONTO) as MONTO
from sys_pagos_proveedores p
	inner join sys_proveedores s on s.ID = p.ID_PROVEEDOR
		where date_format(p.FECHA_EMISION,'%d/%m/%Y') = PSTR_FECHA
        group by  s.ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_CIERRE_CAJA_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_CIERRE_CAJA_VENTAS`(IN PSTR_FECHA VARCHAR(15), IN PSTR_TIENDA CHAR(2))
BEGIN
select 
		(select count(*) 
			from documento_cab d where anulado = '0' and date_format(d.fecha_emision,'%d/%m/%Y') = date_format(c.FECHA_EMISION,'%d/%m/%Y') and d.FORMA_PAGO = 'CO' group by date_format(d.FECHA_EMISION,'%d/%m/%Y')) as trx_contado,
		convert((select sum(monto_total) 
			from documento_cab d where anulado = '0' and  date_format(d.fecha_emision,'%d/%m/%Y') = date_format(c.FECHA_EMISION,'%d/%m/%Y') and d.FORMA_PAGO = 'CO' group by date_format(d.FECHA_EMISION,'%d/%m/%Y')), decimal(10,2)) as contado,
        (select count(*) 
			from documento_cab d where anulado = '0' and  date_format(d.fecha_emision,'%d/%m/%Y') = date_format(c.FECHA_EMISION,'%d/%m/%Y') and d.FORMA_PAGO = 'CR' group by date_format(d.FECHA_EMISION,'%d/%m/%Y')) as trx_credito,
        convert((select sum(monto_total) 
			from documento_cab d where anulado = '0' and  date_format(d.fecha_emision,'%d/%m/%Y') = date_format(c.FECHA_EMISION,'%d/%m/%Y') and d.FORMA_PAGO = 'CR' group by date_format(d.FECHA_EMISION,'%d/%m/%Y')), decimal(10,2)) as credito
 from documento_cab c
	where date_format(c.FECHA_EMISION,'%d/%m/%Y') = PSTR_FECHA
    AND C.COD_TIENDA = PSTR_TIENDA
    group by date_format(c.FECHA_EMISION,'%d/%m/%Y');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_DEL_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_DEL_PAGO_PROVEEDOR`(OUT `RETVAL` VARCHAR(250),IN PSTR_ID INT)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	UPDATE SYS_PAGOS_PROVEEDORES SET  ACTIVO = '0'
		WHERE ID = PSTR_ID;
        
SET SQL_SAFE_UPDATES=0;
	UPDATE
    SYS_STOCK_PRODUCTO TABLA1,
    (
        SELECT (P.CANTIDAD - D.CANTIDAD) AS TOTAL_DIF, D.ID_PRODUCTO  FROM SYS_PAGOS_PROVEEDORES_DET D 
			INNER JOIN SYS_STOCK_PRODUCTO P ON D.ID_PRODUCTO = P.PRODUCTO_ID
				WHERE D.NUMERO_PAGO = PSTR_ID
    ) TABLA2
	SET
		TABLA1.CANTIDAD = TABLA2.TOTAL_DIF
	WHERE 
		TABLA1.PRODUCTO_ID = TABLA2.ID_PRODUCTO;
SET SQL_SAFE_UPDATES=1;

SELECT '1' INTO RETVAL;
                          
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_DEL_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_DEL_PROVEEDOR`(OUT `RETVAL` VARCHAR(250), 
													IN PSTR_ID INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
	UPDATE sys_proveedores SET ACTIVO = '0'
                    WHERE ID = PSTR_ID; 

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_DEL_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_DEL_USUARIO`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `PSTR_ID` INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
DELETE FROM SEGT_USUARIOS
WHERE
    ID = PSTR_ID;

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_FINALIZAR_CREDITO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_FINALIZAR_CREDITO`(OUT RETVAL VARCHAR(150),
IN PSTR_ID_CAB INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
UPDATE DOCUMENTO_CAB 
SET 
    ESTADO_CREDITO = 'C'
WHERE
    ID = PSTR_ID_CAB AND FORMA_PAGO = 'CR'
        AND ANULADO = '0';
        
        SET RETVAL = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_ABONOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_ABONOS`(IN `PSTR_ID_CAB` INT, IN `PSTR_NRO_DOC` INT)
BEGIN
SELECT * FROM SYS_ABONOS
WHERE ID_CAB = PSTR_ID_CAB
AND NRO_DOCUMENTO = PSTR_NRO_DOC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_BANCOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_BANCOS`()
BEGIN
SELECT * FROM SYS_BANCOS
WHERE ACTIVO = '1'
ORDER BY NOMBRE ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CABECERA_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CABECERA_VENTA`(IN PSTR_ID INT)
BEGIN
SELECT 
    C.*,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = C.COD_TIENDA) AS DES_TIENDA,
    (SELECT 
            DESCRIPCION
        FROM
            SYS_TIPO_VENTA TV
        WHERE
            TV.CODIGO = C.TIPO_VENTA) AS TIPO_VENTA_DES,
    (SELECT 
            DES_FORMA_PAGO
        FROM
            SYS_FORMA_PAGO FP
        WHERE
            FP.COD_FORMA_PAGO = C.FORMA_PAGO) AS FORMA_PAGO_DES,
    IFNULL((IF(CL.APELLIDOS IS NULL,
                CL.NOMBRES,
                CONCAT(CL.APELLIDOS, CONCAT(', ', CL.NOMBRES)))),
            'SIN NOMBRE') AS CLIENTE_DES,
    CL.TELEFONO,
    CL.DIRECCION,
    CL.TIPO AS CLIENTE_TIPO
FROM
    DOCUMENTO_CAB C,
    SYS_CLIENTES CL
WHERE
    C.ID = PSTR_ID
        AND CL.DNI = C.CLIENTE_DOC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CATEGORIAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CATEGORIAS`(IN PSTR_CATEGORIA VARCHAR(150), IN PSTR_ACTIVO CHAR(1))
BEGIN
SELECT 
    ID, LPAD(ID, 6, '0') AS CODIGO, NOMBRE, DATE_FORMAT(FECHA_REGISTRO, '%e/%m/%Y') AS FECHA_REGISTRO, ACTIVO
FROM
    SYS_CAT_PRODUCTOS
WHERE
	NOMBRE LIKE CONCAT('%', CONCAT(PSTR_CATEGORIA, '%'))
    AND ACTIVO = IFNULL(PSTR_ACTIVO, ACTIVO)
    AND ELIMINADO = '0'
ORDER BY NOMBRE ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CIERRE_CAJA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CIERRE_CAJA`(IN PSTR_FECHA CHAR(15))
BEGIN
	SELECT * FROM SYS_CAJA WHERE DATE_FORMAT(FECHA, '%d%m%y') = PSTR_FECHA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CLIENTE`(IN `PSTR_COD_CLIENTE` VARCHAR(15))
BEGIN
SELECT 
    *
FROM
    SYS_CLIENTES C
WHERE
    DNI = PSTR_COD_CLIENTE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CLIENTES_REGISTRADOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CLIENTES_REGISTRADOS`(IN PSTR_DNI VARCHAR(15),
																			  IN PSTR_NOMBRE VARCHAR(50))
BEGIN
SELECT 
    ID, NOMBRES, APELLIDOS, DNI, DIRECCION, TELEFONO, EMAIL, DATE_FORMAT(FECHA_REG, '%e/%m/%Y') AS FECHA_REG, TIPO
FROM
    SYS_CLIENTES
WHERE
    DNI LIKE CONCAT(PSTR_DNI, '%')
    AND (NOMBRES LIKE CONCAT('%', PSTR_NOMBRE, '%') OR APELLIDOS LIKE CONCAT('%', PSTR_NOMBRE, '%'))
    ORDER BY NOMBRES ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CLIENTES_X_DNI` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CLIENTES_X_DNI`(IN `PSTR_DNI` VARCHAR(10), IN `PSTR_TIPO` CHAR(1))
BEGIN
	SELECT 
    *
FROM
    SYS_CLIENTES
WHERE
    DNI LIKE CONCAT(PSTR_DNI, '%')
        AND TIPO = PSTR_TIPO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CLIENTES_X_NOMBRE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CLIENTES_X_NOMBRE`(IN `PSTR_NOMBRE` VARCHAR(50), IN `PSTR_TIPO` CHAR(1))
BEGIN
	SELECT 
    *
FROM
    SYS_CLIENTES
WHERE
    CONCAT(NOMBRES, CONCAT(' ', APELLIDOS)) LIKE CONCAT('%', PSTR_NOMBRE, '%')
        AND TIPO = PSTR_TIPO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_COMPLEJOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_COMPLEJOS`(IN `PSTR_COD_TIENDA` CHAR(2))
BEGIN
SELECT COD_TIENDA, NOMBRE_TIENDA, DIRECCION, DISTRITO, PROVINCIA, DEPARTAMENTO
FROM SYS_TIENDA
WHERE COD_TIENDA LIKE CONCAT(PSTR_COD_TIENDA, '%')
AND ACTIVO = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CONSULTA_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CONSULTA_VENTAS`(IN `PSTR_TIENDA_COD` CHAR(2),
																		 IN `PSTR_NRO_DOC` VARCHAR(10),
                                                                         IN `PSTR_TIPO_VENTA` CHAR(2),
                                                                         IN PSTR_FORMA_PAGO CHAR(2),
                                                                         IN PSTR_FECHA VARCHAR(15),
                                                                         IN PSTR_ANULADO CHAR(1))
BEGIN
SELECT 
    ID,
    C.TIPO_VENTA,
    CONCAT('001-', LPAD(C.NUMERO_DOC, 6, '0')) AS NRO_DOC,
    C.CLIENTE_DOC,
    IFNULL((SELECT 
                    IF(APELLIDOS IS NULL,
                            NOMBRES,
                            CONCAT(APELLIDOS, ', ', NOMBRES))
                FROM
                    SYS_CLIENTES CL
                WHERE
                    CL.DNI = C.CLIENTE_DOC),
            'SIN NOMBRE') AS CLIENTE_DES,
    DATE_FORMAT(C.FECHA_EMISION, '%d/%m/%Y') AS FECHA_EMISION,
    CASE C.ANULADO
        WHEN '1' THEN 'SI'
        ELSE 'NO'
    END AS ANULADO,
    TRUNCATE(C.MONTO_TOTAL, 2) AS MONTO_TOTAL
FROM
    DOCUMENTO_CAB C
WHERE
    C.COD_TIENDA = PSTR_TIENDA_COD
        AND CONCAT('001-', LPAD(C.NUMERO_DOC, 6, '0')) = IFNULL(PSTR_NRO_DOC,
            CONCAT('001-', LPAD(C.NUMERO_DOC, 6, '0')))
        AND C.FORMA_PAGO = IFNULL(PSTR_FORMA_PAGO, C.FORMA_PAGO)
        AND C.TIPO_VENTA = IFNULL(PSTR_TIPO_VENTA, C.TIPO_VENTA)
        AND DATE_FORMAT(C.FECHA_EMISION, '%e/%m/%Y') = IFNULL(PSTR_FECHA,
            DATE_FORMAT(CURDATE(), '%e/%m/%Y'))
        AND C.ANULADO = IFNULL(PSTR_ANULADO, C.ANULADO);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CONTIZACION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CONTIZACION`(IN `PSTR_TIENDA_COD` CHAR(2), IN `PSTR_NRO_DOC` INT, IN `PSTR_TIPO` CHAR(1))
BEGIN
	
    SELECT C.*,
		IFNULL((SELECT 
                    IF(APELLIDOS IS NULL,
                            NOMBRES,
                            CONCAT(APELLIDOS, CONCAT(', ', NOMBRES)))
                FROM
                    SYS_CLIENTES CL
                WHERE
                    CL.DNI = C.CLIENTE_DOC),
            'SIN NOMBRE') AS CLIENTE_DES
	FROM COTIZACION_CAB C
		WHERE
		C.COD_TIENDA = PSTR_TIENDA_COD
			AND C.CLIENTE_DOC = IFNULL(PSTR_NRO_DOC, C.CLIENTE_DOC)
			AND C.TIPO_COTIZACION LIKE IFNULL(PSTR_TIPO, C.TIPO_COTIZACION);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CORRELATIVO_MANTENIMIENTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CORRELATIVO_MANTENIMIENTO`(OUT `RETVAL` INT(11))
BEGIN
	SELECT (max(num_doc) + 1) INTO RETVAL FROM sys_programacion_mantenimiento_cab;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_CORRELATIVO_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_CORRELATIVO_VENTA`(IN `PSTR_TIPO_VENTA` VARCHAR(2), OUT `RETVAL` VARCHAR(10))
BEGIN
SELECT LPAD(CORRELATIVO, 6, '0') INTO RETVAL FROM SYS_CORRELATIVO_VENTA WHERE TIPO_VENTA = PSTR_TIPO_VENTA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_DEPOSITOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_DEPOSITOS`(IN PSTR_FECHA VARCHAR(10))
BEGIN
SELECT 
    CONCAT('DC', LPAD(ID, 6, '0')) AS CODIGO,
    DATE_FORMAT(FECHA_EMISION, '%e/%m/%Y') AS FECHA_EMISION,
    (SELECT 
            NOMBRE
        FROM
            SYS_BANCOS
        WHERE
            ID = ID_BANCO) AS BANCO,
    USUARIO,
    TRUNCATE(MONTO, 2) AS MONTO
FROM
    SYS_DEPOSITOS
WHERE
    DATE_FORMAT(FECHA_EMISION, '%e/%m/%Y') = PSTR_FECHA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_DETALLE_COTIZACION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_DETALLE_COTIZACION`(IN `PSTR_ID_CAB` INT)
BEGIN
	SELECT D.*, P.MEDIDA, P.PESO, P.CODIGO as CODIGO_PRODUCTO FROM COTIZACION_DET D , SYS_PRODUCTOS P
	WHERE D.ID_CAB = PSTR_ID_CAB
	AND P.ID = D.ID_PRODUCTO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_DETALLE_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_DETALLE_VENTA`(IN `PSTR_ID_CAB` INT)
BEGIN
SELECT D.*, P.MEDIDA, P.PESO, P.CODIGO as CODIGO_PRODUCTO FROM DOCUMENTO_DET D , SYS_PRODUCTOS P
WHERE D.ID_CAB = PSTR_ID_CAB
AND P.ID = D.ID_PRODUCTO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_DETALLE_VENTA_ELEC` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_DETALLE_VENTA_ELEC`(IN PSTR_NUMERO_DOC INT, IN PSTR_TIPO_VENTA CHAR(2), IN PSTR_ID_TIENDA CHAR(2))
BEGIN

	if PSTR_TIPO_VENTA = 'NC' then
	  select P.ID,
      D.CANTIDAD, 
		M.NOMBRE AS 'UNIDAD_MEDIDA', 
		P.NOMBRE AS 'DESCRIPCION', 
		convert((P.PRECIO), decimal(10,2)) AS 'PRECIO_UNITARIO', 
		'0.00' AS 'DESCUENTO', 
		convert(D.MONTO_TOTAL, decimal(10,2)) AS 'IMPORTE',
        p.peso as 'PESO'
		from DOCUMENTO_DET D 
			LEFT JOIN DOCUMENTO_CAB C ON D.NUMERO_CAB = C.NUMERO_DOC and d.id_Cab = c.id
			LEFT JOIN SYS_PRODUCTOS P ON D.ID_PRODUCTO = P.ID
			LEFT JOIN SYS_UNIDAD_MEDIDA M ON M.ID = P.MEDIDA 
		WHERE 
			((C.NUMERO_DOC = PSTR_NUMERO_DOC AND 
			C.TIPO_VENTA = PSTR_TIPO_VENTA) or
			(PSTR_TIPO_VENTA = 'GR' AND
			C.NUMERO_GUIA = PSTR_NUMERO_DOC))       
			AND 
			C.COD_TIENDA = PSTR_ID_TIENDA;
	else
		select P.ID,
			D.CANTIDAD, 
			M.NOMBRE AS 'UNIDAD_MEDIDA', 
			P.NOMBRE AS 'DESCRIPCION', 
			convert((P.PRECIO / 1.18), decimal(10,2)) AS 'PRECIO_UNITARIO', 
			'0.00' AS 'DESCUENTO', 
			convert(D.MONTO_TOTAL, decimal(10,2)) AS 'IMPORTE',
            p.peso as 'PESO'
			from DOCUMENTO_DET D 
				LEFT JOIN DOCUMENTO_CAB C ON D.NUMERO_CAB = C.NUMERO_DOC and d.id_Cab = c.id
				LEFT JOIN SYS_PRODUCTOS P ON D.ID_PRODUCTO = P.ID
				LEFT JOIN SYS_UNIDAD_MEDIDA M ON M.ID = P.MEDIDA 
			WHERE 
				((C.NUMERO_DOC = PSTR_NUMERO_DOC AND 
				C.TIPO_VENTA = PSTR_TIPO_VENTA) or
				(PSTR_TIPO_VENTA = 'GR' AND
				C.NUMERO_GUIA = PSTR_NUMERO_DOC))       
				AND 
				C.COD_TIENDA = PSTR_ID_TIENDA;    
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_FORMA_PAGO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_FORMA_PAGO`()
BEGIN
SELECT * FROM SYS_FORMA_PAGO where estado = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_MANTENIMIENTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_MANTENIMIENTO`(IN `PSTR_NRO_DOC` varchar(50), IN `PSTR_NOMBRE` varchar(50))
BEGIN

    SELECT C.*,
		IFNULL((SELECT 
                    IF(APELLIDOS IS NULL,
                            NOMBRES,
                            CONCAT(APELLIDOS, CONCAT(', ', NOMBRES)))
                FROM
                    SYS_CLIENTES CL
                WHERE
                    CL.DNI = C.CLIENTE),
            'SIN NOMBRE') AS CLIENTE_DES
	FROM sys_programacion_mantenimiento_cab C
		WHERE
			C.CLIENTE = IFNULL(PSTR_NOMBRE, C.CLIENTE)
			AND C.NUM_DOC = IFNULL(PSTR_NRO_DOC, C.NUM_DOC);
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_MANTENIMIENTO_DETALLE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_MANTENIMIENTO_DETALLE`(IN PSTR_ID INT)
BEGIN
	select M.DESCRIPCION from sys_programacion_mantenimiento_det D
		INNER JOIN sys_tipo_mantenimiento M ON D.TIPO_MANTENIMIENTO = M.ID
		WHERE ID_CAB = PSTR_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_MEDIOS_CONTACTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_MEDIOS_CONTACTO`()
BEGIN
SELECT * FROM sys_medios_contacto
ORDER BY ID ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_MOTIVOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_MOTIVOS`()
BEGIN
SELECT * FROM SYS_MOTIVOS_GUIA ORDER BY (COD_MOTIVO = '00'), COD_MOTIVO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PAGO_PROVEEDOR`(IN PSTR_FECHA VARCHAR(10))
BEGIN
SELECT 
    CONCAT('PP', LPAD(ID, 6, '0')) AS CODIGO,
    DATE_FORMAT(FECHA_EMISION, '%e/%m/%Y') AS FECHA_EMISION,
    (SELECT 
            NOMBRE
        FROM
            SYS_PROVEEDORES
        WHERE
            ID = ID_PROVEEDOR) AS PROVEEDOR,
    USUARIO,
    TRUNCATE(MONTO, 2) AS MONTO
FROM
    SYS_PAGOS_PROVEEDORES
WHERE
    DATE_FORMAT(FECHA_EMISION, '%e/%m/%Y') = PSTR_FECHA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PAGO_PROVEEDOR_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PAGO_PROVEEDOR_CAB`(IN PSTR_ID INT)
BEGIN

	SELECT  
			ID,
			ID_PROVEEDOR,
            FECHA_EMISION,
            NRO_FACTURA,
            MONTO,
            FECHA_HORA,
            TIENDA,
            TIPO_DOCUMENTO,
            CANTIDAD
    FROM SYS_PAGOS_PROVEEDORES 
                    WHERE ID = PSTR_ID;    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PAGO_PROVEEDOR_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PAGO_PROVEEDOR_DET`(IN PSTR_ID INT)
BEGIN

	SELECT s.ID_PRODUCTO,
		s.DESC_PRODUCTO,
        s.CANTIDAD,
        s.PRECIO_UNITARIO,
        s.MONTO_TOTAL,
        p.ID_CAT
        FROM sys_pagos_proveedores_det s
    inner join sys_productos p on p.ID = s.ID_PRODUCTO
                    WHERE s.NUMERO_PAGO = PSTR_ID;  

                          
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PRODUCTO`(IN `PSTR_ID` INT, IN `PSTR_TIENDA_COD` CHAR(2))
BEGIN
SELECT 
    P.ID, P.ID_CAT,
    P.CODIGO,
    P.NOMBRE,
    ROUND(P.COSTO, 2) AS COSTO,
    ROUND(P.PRECIO, 2) AS PRECIO,
    S.CANTIDAD AS STOCK,
    S.TIENDA AS TIENDA_COD,
    P.FECHA_REG,
    (SELECT ID FROM SYS_PROVEEDORES WHERE ID = P.ID_PROVEEDOR) AS PROVEEDOR,
    P.ACTIVO,
    P.ALQUILER,
    ROUND(IFNULL(P.MONTO_ALQUILER,'0'), 2) AS MONTO_ALQUILER
FROM
    SYS_PRODUCTOS P, SYS_STOCK_PRODUCTO S
WHERE
    P.ID = PSTR_ID
    AND S.PRODUCTO_ID = P.ID
    AND S.TIENDA = PSTR_TIENDA_COD;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PRODUCTOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PRODUCTOS`(IN `PSTR_CATEGORIA` INT, IN `PSTR_CODIGO` VARCHAR(50), IN `PSTR_NOMBRE` VARCHAR(50), IN `PSTR_TIENDA` CHAR(2), IN `PSTR_ESTADO` CHAR(1), IN `PSTR_ALQUILER` CHAR(1))
BEGIN
SELECT 
    P.ID,
    P.CODIGO,
    P.ID_CAT,
    P.NOMBRE,
    case when PSTR_ALQUILER = '1' then ROUND(ifnull(P.MONTO_ALQUILER,'0'), 2) else ROUND(ifnull(P.PRECIO,'0'), 2) end AS PRECIO,
    S.CANTIDAD AS STOCK,
    S.TIENDA AS TIENDA_COD,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = S.TIENDA) AS TIENDA_DES
FROM
    SYS_PRODUCTOS P,
    SYS_STOCK_PRODUCTO S
WHERE
    S.PRODUCTO_ID = P.ID AND S.CANTIDAD > 0
        AND S.TIENDA LIKE CONCAT(PSTR_TIENDA, '%')
        AND P.ID_CAT = IFNULL(PSTR_CATEGORIA, ID_CAT)
        AND P.CODIGO LIKE CONCAT('%', PSTR_CODIGO, '%')
        AND P.NOMBRE LIKE CONCAT('%', PSTR_NOMBRE, '%')
        AND P.ACTIVO = PSTR_ESTADO
        AND P.ELIMINADO = 0
        AND CASE WHEN PSTR_ALQUILER = '1' THEN P.ALQUILER = '1' ELSE S.PRODUCTO_ID = S.PRODUCTO_ID END 
ORDER BY 2 ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PRODUCTO_PRECIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PRODUCTO_PRECIO`(OUT `RETVAL` FLOAT, IN `PSTR_PROD_ID` INT)
BEGIN
SELECT ROUND(PRECIO, 2) INTO RETVAL 
FROM SYS_PRODUCTOS
WHERE ID = PSTR_PROD_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PRODUCTO_X_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PRODUCTO_X_CATEGORIA`(IN PSTR_CATEGORIA VARCHAR(10))
BEGIN
	SELECT ID, NOMBRE,COSTO
		FROM SYS_PRODUCTOS
			WHERE ID_CAT = PSTR_CATEGORIA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_PROVEEDORES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_PROVEEDORES`(IN PSTR_PROVEEDOR VARCHAR(100))
BEGIN
SELECT 
    ID, NOMBRE, DIRECCION, TELEFONO, ACTIVO
FROM
    SYS_PROVEEDORES
    where NOMBRE like concat( '%', IFNULL(PSTR_PROVEEDOR, ''), '%')
ORDER BY 2 ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_REPORTE_STOCK_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_REPORTE_STOCK_PRODUCTO`(IN PSTR_ID_CAT INT, IN PSTR_ACTIVO CHAR(1), IN PSTR_ID_TIENDA CHAR(2))
BEGIN
SELECT 
    CONCAT(B.TIENDA,
            LPAD(C.ID, 2, '0'),
            LPAD(A.ID, 6, '0')) AS CODIGO,
    UPPER(C.NOMBRE) AS CATEGORIA_DES,
    A.NOMBRE AS NOMBRE_PROD,
    ROUND(A.COSTO, 2) AS COSTO,
    ROUND(A.PRECIO, 2) AS PRECIO,
    CASE A.ACTIVO
        WHEN '1' THEN 'Activo'
        ELSE 'Anulado'
    END AS ESTADO,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            sys_tienda
        WHERE
            COD_TIENDA = B.TIENDA) AS TIENDA,
    B.CANTIDAD AS STOCK
FROM
    sys_productos A
        INNER JOIN
    sys_stock_producto B ON B.PRODUCTO_ID = A.ID
        INNER JOIN
    sys_cat_productos C ON C.ID = A.ID_CAT
        AND C.ID = IFNULL(PSTR_ID_CAT, C.ID)
        AND A.ACTIVO = IFNULL(PSTR_ACTIVO, A.ACTIVO)
        AND B.TIENDA = IFNULL(PSTR_ID_TIENDA, B.TIENDA)
ORDER BY A.NOMBRE ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_REPORTE_VENTAS_X_FECHA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_REPORTE_VENTAS_X_FECHA`(IN PSTR_FECHA_INI VARCHAR(15),
													  IN PSTR_FECHA_FIN VARCHAR(15),
													  IN PSTR_MES VARCHAR(10),
													  IN PSTR_TIPO_VENTA CHAR(2),
													  IN PSTR_COD_TIENDA CHAR(2),
                                                      IN PSTR_ANULADO CHAR(1))
BEGIN
DECLARE
VAR_FECHA_PATTERN VARCHAR(10);                                                                                

IF SUBSTRING_INDEX(PSTR_MES, '/', 1) = '' THEN
SET VAR_FECHA_PATTERN = '/%Y';
ELSE
SET VAR_FECHA_PATTERN = '%m/%Y';
END IF;

SELECT 
    ELT(DATE_FORMAT(A.FECHA_EMISION, '%m'),
            'ENERO',
            'FEBRERO',
            'MARZO',
            'ABRIL',
            'MAYO',
            'JUNIO',
            'JULIO',
            'AGOSTO',
            'SEPTIEMBRE',
            'OCTUBRE',
            'NOVIEMBRE',
            'DICIEMBRE') AS MES,
    DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') AS FECHA,
    A.TIPO_VENTA,
    CONCAT('001-', LPAD(A.NUMERO_DOC, 8, 0)) AS DOCUMENTO,
    CASE ANULADO
        WHEN '1' THEN 'SI'
        ELSE 'NO'
    END AS ANULADO,
    (SELECT 
            T.NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = A.COD_TIENDA) AS TIENDA,
    ROUND(SUM(A.MONTO_TOTAL), 2) AS MONTO_TOTAL
FROM
    DOCUMENTO_CAB A
WHERE
    (DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') >= PSTR_FECHA_INI
        AND DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') <= PSTR_FECHA_FIN)
        OR DATE_FORMAT(A.FECHA_EMISION, VAR_FECHA_PATTERN) = PSTR_MES
        AND A.TIPO_VENTA = IFNULL(PSTR_TIPO_VENTA, A.TIPO_VENTA)
        AND A.COD_TIENDA = IFNULL(PSTR_COD_TIENDA, A.COD_TIENDA)
        AND A.ANULADO = IFNULL(PSTR_ANULADO, A.ANULADO)
GROUP BY DATE_FORMAT(A.FECHA_EMISION, '%m'), A.FECHA_EMISION, A.TIPO_VENTA, A.NUMERO_DOC
ORDER BY DATE_FORMAT(A.FECHA_EMISION, '%m') , A.FECHA_EMISION ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_REPORTE_VENTA_CREDITO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_REPORTE_VENTA_CREDITO`(IN PSTR_MES VARCHAR(15),IN PSTR_ID_TIENDA INT, IN PSTR_TIPO_DOC CHAR(2),IN PSTR_ANULADO CHAR(1))
BEGIN
DECLARE
VAR_FECHA_PATTERN VARCHAR(10);                                                                                

IF SUBSTRING_INDEX(PSTR_MES, '/', 1) = '' THEN
SET VAR_FECHA_PATTERN = '/%Y';
ELSE
SET VAR_FECHA_PATTERN = '%m/%Y';
END IF;
  SELECT 
		ELT(DATE_FORMAT(A.FECHA_EMISION, '%m'),
            'ENERO',
            'FEBRERO',
            'MARZO',
            'ABRIL',
            'MAYO',
            'JUNIO',
            'JULIO',
            'AGOSTO',
            'SEPTIEMBRE',
            'OCTUBRE',
            'NOVIEMBRE',
            'DICIEMBRE') AS MES,
		DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') AS FECHA,
        A.TIPO_VENTA,
        CONCAT('001-',LPAD(A.NUMERO_DOC, 6, '0')) as NUMERO_DOC,
        CASE A.ANULADO
        WHEN '1' THEN 'SI'
        ELSE 'NO'
		END AS ANULADO,
        (select NOMBRE_TIENDA FROM SYS_TIENDA T 
			WHERE T.COD_TIENDA = A.COD_TIENDA) AS COD_TIENDA,
        CASE A.ESTADO_CREDITO
        WHEN 'C' THEN 'CANCELADO'
        ELSE 'PENDIENTE'
        END AS ESTADO_CREDITO,
        
        CASE A.ANULADO
        WHEN '1' THEN CONVERT(A.MONTO_TOTAL, DECIMAL(10,2)) * -1
        ELSE CONVERT(A.MONTO_TOTAL, DECIMAL(10,2))
        END AS MONTO_TOTAL,
        
        CASE A.ANULADO
        WHEN '1' THEN IFNULL(CONVERT((select sum(monto) from sys_abonos s 
			where s.id_cab = a.id and s.nro_documento = a.numero_doc), DECIMAL(10,2)), 0.00) * -1
        ELSE IFNULL(CONVERT((select sum(monto) from sys_abonos s 
			where s.id_cab = a.id and s.nro_documento = a.numero_doc), DECIMAL(10,2)), 0.00)
		END AS RECIBIDO,
        
        CASE A.ANULADO
        WHEN '1' THEN CONVERT((A.MONTO_TOTAL - (select IFNULL(sum(monto), '0') from sys_abonos s 
			where s.id_cab = a.id and s.nro_documento = a.numero_doc)), decimal(10,2))* -1
        ELSE CONVERT((A.MONTO_TOTAL - (select IFNULL(sum(monto), '0') from sys_abonos s 
			where s.id_cab = a.id and s.nro_documento = a.numero_doc)), decimal(10,2))
		END AS SALDO
		
	FROM
		DOCUMENTO_CAB A
	WHERE
	 DATE_FORMAT(A.FECHA_EMISION, VAR_FECHA_PATTERN) = PSTR_MES
			AND A.COD_TIENDA = IFNULL(PSTR_ID_TIENDA, A.COD_TIENDA)
			AND A.TIPO_VENTA = IFNULL(PSTR_TIPO_DOC, A.TIPO_VENTA)
			AND A.FORMA_PAGO = 'CR'
            AND (A.ANULADO = '0' OR A.ANULADO = IFNULL(PSTR_ANULADO,'0')) 
	GROUP BY DATE_FORMAT(A.FECHA_EMISION, '%m'), A.FECHA_EMISION,A.TIPO_VENTA, A.NUMERO_DOC
	ORDER BY DATE_FORMAT(A.FECHA_EMISION, '%m') , A.FECHA_EMISION ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_REPORTE_VENTA_GENERAL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_REPORTE_VENTA_GENERAL`()
BEGIN
SELECT 
    DATE_FORMAT(A.FECHA_EMISION, '%M') AS MES,
    DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') AS FECHA,
    A.TIPO_VENTA,
    COUNT(A.TIPO_VENTA) AS CANTIDAD_TIPO_VTA,
    ROUND(SUM(A.MONTO_TOTAL) / 1.18, 2) AS SUBTOTAL,
    ROUND(SUM(A.MONTO_TOTAL) - (SUM(A.MONTO_TOTAL) / 1.18), 2) AS IGV,
    ROUND(SUM(A.MONTO_TOTAL), 2) AS TOTAL
FROM
    DOCUMENTO_CAB A
GROUP BY DATE_FORMAT(A.FECHA_EMISION, '%M') , DATE_FORMAT(A.FECHA_EMISION, '%d/%m/%Y') , A.TIPO_VENTA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_REPORTE_VENTA_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_REPORTE_VENTA_PRODUCTO`(IN PSTR_FECHA VARCHAR(15),
																				IN PSTR_MES VARCHAR(15),
                                                                                IN PSTR_ID_CAT INT,
                                                                                IN PSTR_ID_TIENDA CHAR(2))
BEGIN
DECLARE
VAR_FECHA_PATTERN VARCHAR(10);                                                                                

IF SUBSTRING_INDEX(PSTR_MES, '/', 1) = '' THEN
SET VAR_FECHA_PATTERN = '/%Y';
ELSE
SET VAR_FECHA_PATTERN = '%m/%Y';
END IF;

SELECT 
    CONCAT(Z.COD_TIENDA,
            LPAD(C.ID, 2, '0'),
            LPAD(B.ID, 5, '0')) AS CODIGO,
    ELT(DATE_FORMAT(Z.FECHA_EMISION, '%m'),
            'ENERO',
            'FEBRERO',
            'MARZO',
            'ABRIL',
            'MAYO',
            'JUNIO',
            'JULIO',
            'AGOSTO',
            'SEPTIEMBRE',
            'OCTUBRE',
            'NOVIEMBRE',
            'DICIEMBRE') AS MES,
    B.NOMBRE AS PRODUCTO,
    C.NOMBRE AS CATEGORIA,
    SUM(A.CANTIDAD) AS CANTIDAD,
    ROUND(SUM(A.MONTO_TOTAL), 2) AS MONTO_TOTAL,
    ROUND(((SUM(A.PRECIO_UNIT) - SUM(A.COSTO_UNIT)) * A.CANTIDAD),
            2) AS UTILIDAD
FROM
    DOCUMENTO_DET A
        INNER JOIN
    SYS_PRODUCTOS B ON B.ID = A.ID_PRODUCTO
        AND B.ELIMINADO = '0'
        INNER JOIN
    SYS_CAT_PRODUCTOS C ON C.ID = IFNULL(PSTR_ID_CAT, B.ID_CAT)
        AND B.ID_CAT = C.ID
        AND C.ELIMINADO = '0'
        INNER JOIN
    DOCUMENTO_CAB Z ON Z.ID = A.ID_CAB AND Z.ANULADO = '0'
        AND (DATE_FORMAT(Z.FECHA_EMISION, VAR_FECHA_PATTERN) = PSTR_MES
        OR DATE_FORMAT(Z.FECHA_EMISION, '%e/%m/%Y') = PSTR_FECHA)
        AND Z.COD_TIENDA = IFNULL(PSTR_ID_TIENDA, Z.COD_TIENDA)
GROUP BY DATE_FORMAT(Z.FECHA_EMISION, '%m') , A.DESC_PRODUCTO
ORDER BY Z.FECHA_EMISION , B.NOMBRE ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_STOCK_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_STOCK_PRODUCTO`(OUT `RETVAL` INT, IN `PSTR_PRODUCTO_ID` INT, IN `PSTR_TIENDA_COD` CHAR(2))
BEGIN
	SELECT IFNULL(CANTIDAD, 0) INTO RETVAL 
    FROM SYS_STOCK_PRODUCTO 
    WHERE PRODUCTO_ID = PSTR_PRODUCTO_ID
    AND TIENDA = IFNULL(PSTR_TIENDA_COD, TIENDA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_TIPOS_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_TIPOS_VENTAS`(IN `PSTR_CODIGO` VARCHAR(50))
BEGIN
IF PSTR_CODIGO IS NULL THEN
SELECT 
    ID, CODIGO, DESCRIPCION
FROM
    SYS_TIPO_VENTA
WHERE
    ACTIVO = '1'
ORDER BY 3 ASC;
ELSE
SELECT 
    ID, CODIGO, DESCRIPCION
FROM
    SYS_TIPO_VENTA
WHERE
    ACTIVO = '1' AND CODIGO = PSTR_CODIGO
ORDER BY 3 ASC;
END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_TIPO_MANTENIMIENTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_TIPO_MANTENIMIENTO`()
BEGIN
	SELECT * FROM SYS_TIPO_MANTENIMIENTO
		WHERE ESTADO = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_TIPO_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_TIPO_USUARIO`()
BEGIN
  SELECT * FROM SEGT_TIPO_USUARIO WHERE ACTIVO = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_UNIDAD_MEDIDA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_UNIDAD_MEDIDA`()
BEGIN
	SELECT ID, NOMBRE FROM SYS_UNIDAD_MEDIDA WHERE ACTIVO = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_USUARIO`(IN PSTR_ID INT)
BEGIN
SELECT 
    ID,
    LPAD(ID, 6, '0') AS CODIGO,
    NRO_DOC,
    NOMBRES,
    RANGO,
    CASE RANGO
        WHEN '1' THEN 'Administrador'
        ELSE 'Cajero'
    END AS RANGO_DES,
    DATE_FORMAT(FECHA_REG, '%d/%m/%Y') AS FECHA_REG,
    DATE_FORMAT(FECHA_NAC, '%d/%m/%Y') AS FECHA_NAC,
    EMAIL,
    SEXO,
    TELEFONO
FROM
    SEGT_USUARIOS
WHERE
    ID = PSTR_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_USUARIOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_USUARIOS`(IN PSTR_NRO_DOC VARCHAR(15), IN PSTR_RANGO CHAR(1))
BEGIN
SELECT 
    ID,
    LPAD(ID, 6, '0') AS CODIGO,
    NRO_DOC,
    NOMBRES,
    RANGO,
    CASE RANGO
        WHEN 'A' THEN 'Administrador'
        ELSE 'Cajero'
    END AS RANGO_DES,
    DATE_FORMAT(FECHA_REG, '%d/%m/%Y') AS FECHA_REG,
    DATE_FORMAT(FECHA_NAC, '%d/%m/%Y') AS FECHA_NAC,
    EMAIL,
    SEXO,
    TELEFONO
FROM
    SEGT_USUARIOS
WHERE
    NRO_DOC LIKE CONCAT(IFNULL(PSTR_NRO_DOC, '%'), '%')
        AND RANGO = IFNULL(PSTR_RANGO, RANGO)
ORDER BY ID ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_VENTAS`(IN `PSTR_TIENDA_COD` CHAR(2), IN `PSTR_NRO_DOC` INT, IN `PSTR_TIPO_VENTA` CHAR(2))
BEGIN
SELECT 
    C.*,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = C.COD_TIENDA) AS DES_TIENDA,
    (SELECT 
            DESCRIPCION
        FROM
            SYS_TIPO_VENTA TV
        WHERE
            TV.CODIGO = C.TIPO_VENTA) AS TIPO_VENTA_DES,
    (SELECT 
            DES_FORMA_PAGO
        FROM
            SYS_FORMA_PAGO FP
        WHERE
            FP.COD_FORMA_PAGO = C.FORMA_PAGO) AS FORMA_PAGO_DES,
    IFNULL((SELECT 
                    IF(APELLIDOS IS NULL,
                            NOMBRES,
                            CONCAT(APELLIDOS, CONCAT(', ', NOMBRES)))
                FROM
                    SYS_CLIENTES CL
                WHERE
                    CL.DNI = C.CLIENTE_DOC),
            'SIN NOMBRE') AS CLIENTE_DES
FROM
    DOCUMENTO_CAB C
WHERE
    C.COD_TIENDA = PSTR_TIENDA_COD
        AND C.NUMERO_DOC = IFNULL(PSTR_NRO_DOC, C.NUMERO_DOC)
        AND C.TIPO_VENTA LIKE CONCAT(PSTR_TIPO_VENTA, '%')
        AND C.ANULADO = '0';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_VENTAS_CREDITO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_VENTAS_CREDITO`(IN `PSTR_NRO_DOC` INT, IN `PSTR_COD_TIENDA` CHAR(2), IN `PSTR_TIPO_VENTA` CHAR(2), IN `PSTR_FECHA` VARCHAR(20))
BEGIN
SELECT 
    C.*,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = C.COD_TIENDA) AS DES_TIENDA,
    (SELECT 
            DESCRIPCION
        FROM
            SYS_TIPO_VENTA TV
        WHERE
            TV.CODIGO = C.TIPO_VENTA) AS TIPO_VENTA_DES,
    (SELECT 
            DES_FORMA_PAGO
        FROM
            SYS_FORMA_PAGO FP
        WHERE
            FP.COD_FORMA_PAGO = C.FORMA_PAGO) AS FORMA_PAGO_DES,
    IFNULL(IF(CL.APELLIDOS IS NULL,
                            CL.NOMBRES,
                            CONCAT(CL.APELLIDOS, CONCAT(', ', CL.NOMBRES))),
            'SIN NOMBRE') AS CLIENTE_DES,
            CL.EMAIL,
            CL.TELEFONO,
            CL.DIRECCION
FROM
    DOCUMENTO_CAB C, SYS_CLIENTES CL
WHERE
    C.COD_TIENDA = PSTR_COD_TIENDA
    AND CL.DNI = C.CLIENTE_DOC
        AND C.NUMERO_DOC = PSTR_NRO_DOC
        AND C.TIPO_VENTA = PSTR_TIPO_VENTA
        AND DATE_FORMAT(C.FECHA_EMISION,'%e/%m/%Y') = PSTR_FECHA
        AND C.FORMA_PAGO = 'CR'
        AND C.ANULADO = '0';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_GET_VENTAS_X_CLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_GET_VENTAS_X_CLIENTE`(IN PSTR_CLIENTE_DOC VARCHAR(15),
																		  IN PSTR_CLIENTE_NOMBRE VARCHAR(50),
                                                                          IN PSTR_FECHA VARCHAR(10))
BEGIN
SELECT 
    C.*,
    (SELECT 
            NOMBRE_TIENDA
        FROM
            SYS_TIENDA T
        WHERE
            T.COD_TIENDA = C.COD_TIENDA) AS DES_TIENDA,
    (SELECT 
            DESCRIPCION
        FROM
            SYS_TIPO_VENTA TV
        WHERE
            TV.CODIGO = C.TIPO_VENTA) AS TIPO_VENTA_DES,
    (SELECT 
            DES_FORMA_PAGO
        FROM
            SYS_FORMA_PAGO FP
        WHERE
            FP.COD_FORMA_PAGO = C.FORMA_PAGO) AS FORMA_PAGO_DES,
    IFNULL((IF(CL.APELLIDOS IS NULL,
                CL.NOMBRES,
                CONCAT(CL.APELLIDOS, CONCAT(', ', CL.NOMBRES)))),
            'SIN NOMBRE') AS CLIENTE_DES,
    CL.TELEFONO,
    CL.DIRECCION,
    CL.TIPO AS CLIENTE_TIPO,
    CASE C.ANULADO
        WHEN '1' THEN 'SI'
        ELSE 'NO'
    END AS ANULADO_DES
FROM
    DOCUMENTO_CAB C,
    SYS_CLIENTES CL
WHERE
    (CONCAT(CL.NOMBRES, ' ', APELLIDOS) LIKE CONCAT('%', PSTR_CLIENTE_NOMBRE, '%')
        AND C.CLIENTE_DOC = CL.DNI)
        AND C.CLIENTE_DOC = IFNULL(PSTR_CLIENTE_DOC, C.CLIENTE_DOC)
        AND DATE_FORMAT(C.FECHA_EMISION, '%e/%m/%Y') = IFNULL(PSTR_FECHA,
            DATE_FORMAT(C.FECHA_EMISION, '%e/%m/%Y'))
ORDER BY C.FECHA_EMISION DESC
LIMIT 20;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_ABONO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_ABONO`(OUT `RETVAL` VARCHAR(250),
IN `PSTR_ID` INT, 
IN `PSTR_ID_CAB` INT, 
IN `PSTR_COD_TIENDA` CHAR(2), 
IN `PSTR_USUARIO` VARCHAR(15), 
IN `PSTR_MONTO` DOUBLE)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
INSERT INTO SYS_ABONOS
(ID_CAB, NRO_DOCUMENTO, COD_TIENDA, USUARIO, MONTO)
VALUES (PSTR_ID, PSTR_ID_CAB, PSTR_COD_TIENDA, PSTR_USUARIO, ROUND(PSTR_MONTO, 2));

SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_ALQUILER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_ALQUILER`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `FECHA_ENT` VARCHAR(50),
                                                                 IN HORA_ENT VARCHAR(50),
                                                                 IN `FECHA_DEV` VARCHAR(50),
                                                                 IN HORA_DEV VARCHAR(50),
                                                                 IN CLIENTE VARCHAR(500),
                                                                 IN DETALLE VARCHAR(1500))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
INSERT INTO sys_distribucion
(FECHA_ENT, HORA_ENT, FECHA_DEV, HORA_DEV, CLIENTE, DETALLE)
VALUES (STR_TO_DATE(FECHA_ENT, '%d/%m/%Y'), HORA_ENT, STR_TO_DATE(FECHA_DEV, '%d/%m/%Y'), HORA_DEV, CLIENTE, DETALLE);

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_CATEGORIA`(OUT RETVAL VARCHAR(50),
										 IN PSTR_NOMBRE VARCHAR(50),
                                         IN PSTR_ACTIVO CHAR(1))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO sys_cat_productos (`NOMBRE`, `ACTIVO`, `FECHA_REGISTRO`)
 VALUES (PSTR_NOMBRE, PSTR_ACTIVO, CURDATE());

 SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_CIERRE_CAJA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_CIERRE_CAJA`(OUT `RETVAL` VARCHAR(250), 
									     IN PSTR_FECHA CHAR(2),
										 IN PSTR_TOTAL_CAJA VARCHAR(15),
                                         IN PSTR_TOTAL_VENTA VARCHAR(15),
                                         IN PSTR_TOTAL_CREDITO VARCHAR(15),
                                         IN PSTR_DEPOSITO VARCHAR(15),
                                         IN PSTR_GASTO_ADMIN VARCHAR(15),
                                         IN PSTR_PROVEEDOR VARCHAR(15),
                                         IN PSTR_TRX_CONTADO VARCHAR(15),
                                         IN PSTR_TRX_CREDITO VARCHAR(15),
                                         IN PSTR_MONTO_CONTADO VARCHAR(15),
                                         IN PSTR_MONTO_CREDITO VARCHAR(15),
                                         IN PSTR_TRX_BOLETA VARCHAR(15),
                                         IN PSTR_TRX_FACTURA VARCHAR(15),
                                         IN PSTR_MONTO_BOLETA VARCHAR(15),
                                         IN PSTR_MONTO_FACTURA VARCHAR(15),
                                         IN PSTR_USUARIO VARCHAR(15),
                                         IN PSTR_TIENDA CHAR(2))
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO sys_caja(
	`FECHA`,
	`TOTAL_CAJAS`,
	`TOTAL_VENTAS`,
	`TOTAL_PAGOS_CREDITO`,
	`TOTAL_DEPOSITOS_CTA`,
	`TOTAL_GASTOS_ADM`,
	`TOTAL_PAGO_PROVEEDOR`,
	`TOT_VTAS_TRX_CONTADO`,
	`TOT_VTAS_TRX_CREDITO`,
	`TOT_VTAS_MONTO_CONTADO`,
	`TOT_VTAS_MONTO_CREDITO`,
	`TOT_CR_TRX_BOLETA`,
	`TOT_CR_TRX_FACTURA`,
	`TOT_CR_MONTO_BOLETA`,
	`TOT_CR_MONTO_FACTURA`,
	`USUARIO`,
	`FECHA_HORA`,
	`TIENDA`    
 ) 
 VALUES(
	PSTR_FECHA,
    PSTR_TOTAL_CAJA,
    PSTR_TOTAL_VENTA,
    PSTR_TOTAL_CREDITO,
    PSTR_DEPOSITO,
    PSTR_GASTO_ADMIN,
    PSTR_PROVEEDOR,
    PSTR_TRX_CONTADO,
    PSTR_TRX_CREDITO,
    PSTR_MONTO_CONTADO,
    PSTR_MONTO_CREDITO,
    PSTR_TRX_BOLETA,
    PSTR_TRX_FACTURA,
    PSTR_MONTO_BOLETA ,
    PSTR_MONTO_FACTURA,
    PSTR_USUARIO,
    NOW(),
    PSTR_TIENDA);
 
 SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_CLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_CLIENTE`(OUT `RETVAL` VARCHAR(250), IN `PSTR_DNI` VARCHAR(15), IN `PSTR_NOMBRES` VARCHAR(50), IN `PSTR_APELLIDOS` VARCHAR(50), IN `PSTR_DIRECCION` VARCHAR(100), IN `PSTR_TELEFONO` VARCHAR(15), IN `PSTR_EMAIL` VARCHAR(80), IN `PSTR_TIPO` CHAR(2), IN `PSTR_POSIBLE` CHAR(2))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
INSERT INTO SYS_CLIENTES
(
NOMBRES,
APELLIDOS,
DNI,
DIRECCION,
TELEFONO,
EMAIL,
FECHA_REG,
TIPO,
POSIBLE_CLIENTE
)
VALUES
(
PSTR_NOMBRES,
PSTR_APELLIDOS,
PSTR_DNI,
PSTR_DIRECCION,
PSTR_TELEFONO,
PSTR_EMAIL,
CURDATE(),
PSTR_TIPO,
PSTR_POSIBLE
);

SELECT '1' INTO RETVAL;
 
 COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_CORRELATIVO_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_CORRELATIVO_VENTA`(IN `PSTR_TIPO_VENTA` VARCHAR(2))
BEGIN
UPDATE SYS_CORRELATIVO_VENTA 
SET CORRELATIVO = CORRELATIVO + 1
WHERE TIPO_VENTA = PSTR_TIPO_VENTA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_DEPOSITO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_DEPOSITO`(OUT `RETVAL` VARCHAR(250),
																  IN PSTR_ID_BANCO INT,
                                                                  IN PSTR_USUARIO VARCHAR(50),
                                                                  IN PSTR_MONTO DOUBLE)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO SYS_DEPOSITOS (ID_BANCO, FECHA_EMISION, USUARIO, MONTO, FECHA_HORA)
 VALUES (
 PSTR_ID_BANCO,
 CURDATE(),
 PSTR_USUARIO,
 ROUND(PSTR_MONTO, 2),
 NOW()
 );
 
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_DISTRIBUCION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_DISTRIBUCION`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `FECHA` VARCHAR(50),
                                                                 IN HORA VARCHAR(50),
                                                                 IN DESTINO VARCHAR(500),
                                                                 IN ENCARGADO VARCHAR(500),
                                                                 IN DETALLE VARCHAR(1500))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
INSERT INTO sys_distribucion
(`FECHA`,
`HORA`,
`DESTINO`,
`ENCARGADO`,
`DETALLE`)
VALUES (STR_TO_DATE(FECHA, '%d/%m/%Y'), HORA, DESTINO, ENCARGADO, DETALLE);

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_MANTENIMIENTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_MANTENIMIENTO`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `FECHA` VARCHAR(50),
                                                                 IN TIEMPO INT,
                                                                 IN CLIENTE VARCHAR(500),
                                                                 IN ENCARGADO VARCHAR(500),
                                                                 IN DETALLE VARCHAR(1500))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
INSERT INTO sys_mantenimiento
(`FECHA`,
`TIEMPO`,
`CLIENTE`,
`ENCARGADO`,
`DETALLE`)
VALUES (STR_TO_DATE(FECHA, '%d/%m/%Y'), TIEMPO, CLIENTE, ENCARGADO, DETALLE);

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_PAGO_PROVEEDOR`(OUT `RETVAL` VARCHAR(250),
											  IN PSTR_ID_PROVEEDOR INT,
                                              IN PSTR_NRO_FACTURA INT,
                                              IN PSTR_USUARIO VARCHAR(50),
                                              IN PSTR_MONTO DOUBLE)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO SYS_PAGOS_PROVEEDORES (ID_PROVEEDOR, FECHA_EMISION, NRO_FACTURA, USUARIO, MONTO, FECHA_HORA)
 VALUES (
 PSTR_ID_PROVEEDOR,
 CURDATE(),
 PSTR_NRO_FACTURA,
 PSTR_USUARIO,
 ROUND(PSTR_MONTO, 2),
 NOW()
 );
 
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_PAGO_PROVEEDOR_CAB` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_PAGO_PROVEEDOR_CAB`(OUT `RETVAL` VARCHAR(250), OUT `RETID` INT,
																		  IN PSTR_ID_PROVEEDOR INT,
																		  IN PSTR_NRO_FACTURA VARCHAR(25),
																		  IN PSTR_USUARIO VARCHAR(50),
																		  IN PSTR_MONTO DOUBLE,
																		  IN PSTR_NOMBRE_PROVEEDOR VARCHAR(100),
																		  IN PSTR_FECHA_ENTREGA VARCHAR(100),
																		  IN PSTR_TIENDA CHAR(2),
																		  IN PSTR_TIPO_DOCUMENTO CHAR(2),
																		  IN PSTR_CANTIDAD INT)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	INSERT INTO sys_pagos_proveedores
					(`ID_PROVEEDOR`,
					`FECHA_EMISION`,
					`NRO_FACTURA`,
					`USUARIO`,
					`MONTO`,
					`FECHA_HORA`,
					`TIENDA`,
					`TIPO_DOCUMENTO`,
					`CANTIDAD`,
					`ACTIVO`)
					VALUES
					(PSTR_ID_PROVEEDOR,
					NOW(),
					PSTR_NRO_FACTURA,
					PSTR_USUARIO,
					PSTR_MONTO,
					PSTR_FECHA_ENTREGA,
					PSTR_TIENDA,
					PSTR_TIPO_DOCUMENTO,
					PSTR_CANTIDAD,
					'1');
	 
SELECT '1' INTO RETVAL;
SELECT LAST_INSERT_ID() INTO RETID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_PAGO_PROVEEDOR_DET` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_PAGO_PROVEEDOR_DET`(OUT `RETVAL` VARCHAR(250), 
																			IN `PSTR_ID_CAB` INT,  
                                                                            IN `PSTR_ID_PRODUCTO` INT, 
                                                                            IN `PSTR_DESC_PRODUCTO` VARCHAR(500), 
                                                                            IN `PSTR_CANTIDAD` INT, 
                                                                            IN `PSTR_PRECIO_UNIT` DOUBLE, 
                                                                            IN `PSTR_MONTO_TOTAL` DOUBLE)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	INSERT INTO `sys_pagos_proveedores_det`
							(`NUMERO_PAGO`,
							`ID_PRODUCTO`,
							`DESC_PRODUCTO`,
							`CANTIDAD`,
							`PRECIO_UNITARIO`,
							`MONTO_TOTAL`)
							VALUES
							(PSTR_ID_CAB,
							PSTR_ID_PRODUCTO,
							PSTR_DESC_PRODUCTO,
							PSTR_CANTIDAD,
							PSTR_PRECIO_UNIT,
							PSTR_MONTO_TOTAL);

UPDATE SYS_STOCK_PRODUCTO 
	SET 
		CANTIDAD = CANTIDAD + PSTR_CANTIDAD
	WHERE
		PRODUCTO_ID = PSTR_ID_PRODUCTO;
	
UPDATE SYS_PRODUCTOS 
	SET COSTO = PSTR_PRECIO_UNIT 
		WHERE ID = PSTR_ID_PRODUCTO;
    
SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_PRODUCTO`(OUT `RETVAL` VARCHAR(250), IN `PSTR_TIENDA_COD` CHAR(2), IN `PSTR_PROVEEDOR` CHAR(2), IN `PSTR_CAT_ID` INT, IN `PSTR_NOMBRE` VARCHAR(250), IN `PSTR_USUARIO` VARCHAR(250), IN `PSTR_COSTO` DOUBLE, IN `PSTR_PRECIO` DOUBLE, IN `PSTR_STOCK` INT, IN `PSTR_MEDIDA` DOUBLE, IN `PSTR_PESO` DOUBLE, IN `PSTR_ACTIVO` CHAR(1), IN PSTR_ALQUILER CHAR(1), IN `PSTR_PRECIO_ALQUILER` DOUBLE, IN `PSTR_CODIGO` VARCHAR(50))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 INSERT INTO SYS_PRODUCTOS (ID_CAT, CODIGO, ID_PROVEEDOR, NOMBRE, COSTO, PRECIO, MEDIDA, PESO, ACTIVO, ALQUILER, USUARIO, FECHA_REG, MONTO_ALQUILER)
 VALUES (PSTR_CAT_ID, PSTR_CODIGO, PSTR_PROVEEDOR, PSTR_NOMBRE, ROUND(PSTR_COSTO, 2), ROUND(PSTR_PRECIO,2), ROUND(PSTR_MEDIDA,2), ROUND(PSTR_PESO,2), PSTR_ACTIVO, PSTR_ALQUILER,PSTR_USUARIO, curdate(), PSTR_PRECIO_ALQUILER);
 
 INSERT INTO SYS_STOCK_PRODUCTO
 VALUES (LAST_INSERT_ID(),
		 PSTR_STOCK,
         PSTR_TIENDA_COD);
 
SELECT '1' INTO RETVAL;
 
 COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_PROVEEDORES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_PROVEEDORES`(OUT `RETVAL` VARCHAR(250), 
													IN PSTR_PROVEEDOR VARCHAR(100),
                                                    IN PSTR_DIRECCION VARCHAR(250),
                                                    IN PSTR_TELEFONO VARCHAR(15))
BEGIN


	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	INSERT INTO SYS_PROVEEDORES(NOMBRE,
								DIRECCION,
                                TELEFONO,
                                ACTIVO)
		VALUES(PSTR_PROVEEDOR,
			PSTR_DIRECCION,
            PSTR_TELEFONO,
            '1');
        
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_SET_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_SET_USUARIO`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `PSTR_NRO_DOC` VARCHAR(15),
                                                                 IN PSTR_PASSWORD VARCHAR(10),
                                                                 IN PSTR_NOMBRES VARCHAR(50),
                                                                 IN PSTR_SEXO CHAR(1),
                                                                 IN PSTR_FECHA_NAC VARCHAR(15),
                                                                 IN `PSTR_EMAIL` VARCHAR(250),
                                                                 IN `PSTR_TELEFONO` VARCHAR(250),
                                                                 IN PSTR_RANGO CHAR(1))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
INSERT INTO SEGT_USUARIOS
(NRO_DOC, USERNAME, PASSWORD, NOMBRES, SEXO, FECHA_NAC, EMAIL, TELEFONO, FECHA_REG, RANGO)
VALUES (PSTR_NRO_DOC, PSTR_NRO_DOC, PSTR_PASSWORD, PSTR_NOMBRES, PSTR_SEXO, STR_TO_DATE(PSTR_FECHA_NAC, '%d/%m/%Y'), PSTR_EMAIL, PSTR_TELEFONO, NOW(), PSTR_RANGO);

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_CATEGORIA`(OUT RETVAL VARCHAR(50),
																   IN PSTR_ID INT,
																   IN PSTR_NOMBRE VARCHAR(50),
                                                                   IN PSTR_ACTIVO CHAR(1))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 UPDATE sys_cat_productos SET NOMBRE = PSTR_NOMBRE, ACTIVO = PSTR_ACTIVO
 WHERE ID = PSTR_ID;

SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_CLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_CLIENTE`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `PSTR_ID` INT,
                                                                 IN `PSTR_NOMBRE` VARCHAR(250),
                                                                 IN `PSTR_APELLIDO` VARCHAR(250),
                                                                 IN `PSTR_DIRECCION` VARCHAR(250),
                                                                 IN `PSTR_EMAIL` VARCHAR(250),
                                                                 IN `PSTR_TELEFONO` VARCHAR(250),
                                                                 IN PSTR_TIPO CHAR(1))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
UPDATE SYS_CLIENTES
SET 
    NOMBRES = PSTR_NOMBRE,
    APELLIDOS = PSTR_APELLIDO,
    DIRECCION = PSTR_DIRECCION,
    EMAIL = PSTR_EMAIL,
    TELEFONO = PSTR_TELEFONO,
    TIPO = PSTR_TIPO
WHERE
    ID = PSTR_ID;

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_ELIMINAR_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_ELIMINAR_CATEGORIA`(OUT RETVAL VARCHAR(50),
																   IN PSTR_ID INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
 UPDATE sys_cat_productos SET ELIMINADO = 1
 WHERE ID = PSTR_ID;

SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_ELIMINAR_CLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_ELIMINAR_CLIENTE`(OUT `RETVAL` VARCHAR(250), IN `PSTR_ID` INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
DELETE FROM SYS_CLIENTES 
WHERE
    ID = PSTR_ID;
    
SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_ELIMINAR_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_ELIMINAR_PRODUCTO`(OUT `RETVAL` VARCHAR(250), IN `PSTR_PRODUCTO_ID` INT)
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
UPDATE SYS_PRODUCTOS 
SET 
    ELIMINADO = 1
WHERE
    ID = PSTR_PRODUCTO_ID;
    
    SELECT '1' INTO RETVAL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_PAGO_PROVEEDOR`(OUT `RETVAL` VARCHAR(250), 
																		  IN PSTR_ID INT,
																		  IN PSTR_ID_PROVEEDOR INT,
																		  IN PSTR_NRO_FACTURA VARCHAR(25),
																		  IN PSTR_MONTO DOUBLE,
                                                                          IN PSTR_USUARIO VARCHAR(100),
																		  IN PSTR_FECHA_ENTREGA VARCHAR(100),
																		  IN PSTR_TIENDA CHAR(2),
																		  IN PSTR_TIPO_DOCUMENTO CHAR(2),
																		  IN PSTR_CANTIDAD INT)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	UPDATE SYS_PAGOS_PROVEEDORES SET
			ID_PROVEEDOR = PSTR_ID_PROVEEDOR,
            NRO_FACTURA = PSTR_NRO_FACTURA,
            MONTO = PSTR_MONTO,
            USUARIO = PSTR_USUARIO,
            FECHA_HORA = PSTR_FECHA_ENTREGA,
            TIENDA = PSTR_TIENDA,
            TIPO_DOCUMENTO = PSTR_TIPO_DOCUMENTO,
            CANTIDAD = PSTR_CANTIDAD
                    WHERE ID = PSTR_ID;  
                    
SELECT '1' INTO RETVAL;
                    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_PRODUCTO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_PRODUCTO`(OUT `RETVAL` VARCHAR(250), IN `PSTR_TIENDA_COD` CHAR(2), IN `PSTR_ID` INT, IN `PSTR_CAT_ID` INT, IN `PSTR_NOMBRE` VARCHAR(250), IN `PSTR_COSTO` DOUBLE, IN `PSTR_PRECIO` DOUBLE, IN `PSTR_STOCK` INT, IN `PSTR_PROV_ID` INT, IN `PSTR_MEDIDA` DOUBLE, IN `PSTR_PESO` DOUBLE, IN `PSTR_ACTIVO` CHAR(1),  IN `PSTR_ALQUILER` CHAR(1), IN `PSTR_PRECIO_ALQUILER` DOUBLE,  IN `PSTR_CODIGO` VARCHAR(50))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
UPDATE SYS_PRODUCTOS 
SET 
    ID_CAT = PSTR_CAT_ID,
    CODIGO = PSTR_CODIGO,
    NOMBRE = PSTR_NOMBRE,
    COSTO = ROUND(PSTR_COSTO, 2),
    PRECIO = ROUND(PSTR_PRECIO, 2),
    ID_PROVEEDOR = PSTR_PROV_ID,
    MEDIDA = ROUND(PSTR_MEDIDA, 2),
    PESO = ROUND(PSTR_PESO, 2),
    ACTIVO = PSTR_ACTIVO,
    ALQUILER = PSTR_ALQUILER,
    MONTO_ALQUILER = PSTR_PRECIO_ALQUILER
WHERE
    ID = PSTR_ID;
 
UPDATE SYS_STOCK_PRODUCTO 
SET 
    CANTIDAD = PSTR_STOCK,
    TIENDA = PSTR_TIENDA_COD
WHERE
    PRODUCTO_ID = PSTR_ID
        AND TIENDA = PSTR_TIENDA_COD;
 
SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_PROVEEDOR`(OUT `RETVAL` VARCHAR(250), 
													IN PSTR_ID INT,
													IN PSTR_PROVEEDOR VARCHAR(100),
                                                    IN PSTR_TIPO_DOC CHAR(2),
													IN PSTR_NRO_DOC VARCHAR(15),
                                                    IN PSTR_DIRECCION VARCHAR(250),
                                                    IN PSTR_OBSERVACION VARCHAR(250),
                                                    IN PSTR_TELEFONO VARCHAR(15),
                                                    IN PSTR_TIENDA CHAR(2))
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
	UPDATE sys_proveedores SET NOMBRE = PSTR_PROVEEDOR,
                               DIRECCION =PSTR_DIRECCION,
                               TELEFONO =PSTR_TELEFONO,
							   TIENDA =PSTR_TIENDA,
                               TIPO_DOCUMENTO =PSTR_TIPO_DOC,
							   NRO_DOCUMENTO =PSTR_NRO_DOC,
                               OBSERVACION =PSTR_OBSERVACION
                    WHERE ID = PSTR_ID; 
                               
SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_USUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_USUARIO`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `PSTR_ID` INT,
                                                                 IN `PSTR_EMAIL` VARCHAR(250),
                                                                 IN `PSTR_TELEFONO` VARCHAR(250),
                                                                 IN PSTR_RANGO CHAR(1))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
UPDATE SEGT_USUARIOS
SET 
    EMAIL = PSTR_EMAIL,
    TELEFONO = PSTR_TELEFONO,
    RANGO = PSTR_RANGO
WHERE
    ID = PSTR_ID;

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_UPD_USUARIO_PWD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_UPD_USUARIO_PWD`(OUT `RETVAL` VARCHAR(250),
                                                                 IN `PSTR_ID` INT,
                                                                 IN `PSTR_PASSWORD` VARCHAR(10))
BEGIN
DECLARE EXIT HANDLER FOR SQLEXCEPTION 
 SELECT 'SQLException invoked' INTO RETVAL;
 
UPDATE SEGT_USUARIOS
SET 
    PASSWORD = PSTR_PASSWORD
WHERE
    ID = PSTR_ID;

SELECT '1' INTO RETVAL;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_VALIDAR_DELETE_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_VALIDAR_DELETE_CATEGORIA`(OUT RETVAL CHAR(1),IN ID INT)
BEGIN
  IF (SELECT COUNT(*) FROM sys_productos P WHERE P.ID_CAT = ID) > 0 THEN
	SELECT '1' INTO RETVAL;
  ELSE
	SELECT '0' INTO RETVAL;
  END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_VALIDAR_DEL_PROD_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_VALIDAR_DEL_PROD_PAGO_PROVEEDOR`(IN PSTR_ID_PAGO INT)
BEGIN
	SELECT DESC_PRODUCTO, (P.CANTIDAD - D.CANTIDAD) AS TOTAL_DIF FROM SYS_PAGOS_PROVEEDORES_DET D 
	INNER JOIN SYS_STOCK_PRODUCTO P ON D.ID_PRODUCTO = P.PRODUCTO_ID
		WHERE D.NUMERO_PAGO = PSTR_ID_PAGO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SYS_VALIDAR_PAGO_PROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_SYS_VALIDAR_PAGO_PROVEEDOR`(OUT CANT INT,
													  IN PSTR_NRO_FACTURA VARCHAR(25))
BEGIN
SELECT COUNT(*) INTO CANT
		FROM SYS_PAGOS_PROVEEDORES WHERE NRO_FACTURA = PSTR_NRO_FACTURA AND ACTIVO = '1';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-12 19:12:14
