CREATE DATABASE ims_db;
USE ims_db;

-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 23, 2022 at 09:46 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `ims_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblcart`
--

CREATE TABLE IF NOT EXISTS `tblcart` (
  `invoiceno` varchar(255) NOT NULL,
  `pcode` varchar(255) NOT NULL,
  `pname` varchar(255) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `qty` int(11) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `user` varchar(50) NOT NULL,
  `status` varchar(20) NOT NULL,
  `date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcart`
--

INSERT INTO `tblcart` (`invoiceno`, `pcode`, `pname`, `price`, `qty`, `total`, `user`, `status`, `date`) VALUES
('IVC20211228V85951', 'P-0655108', 'PEAK MILK REFILL', '500.00', 2, '1000.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-12415797', 'PEAK MILK TIN', '220.00', 2, '440.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-25252720', 'BAKING SODA', '180.00', 1, '180.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-42232199', 'LUX SOAP', '120.00', 2, '240.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-59447964', 'COCA COLA 50CL', '80.00', 2, '160.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-65948223', 'BLACK SOAP', '500.00', 3, '1500.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228V85951', 'P-98695671', '40 LEAVES NOTEBOOK', '60.00', 1, '60.00', 'Temidayo', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-35948504', 'PEPSI 50CL', '120.00', 5, '600.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-98695671', '40 LEAVES NOTEBOOK', '60.00', 5, '300.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-65948223', 'BLACK SOAP', '500.00', 3, '1500.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-59447964', 'COCA COLA 50CL', '80.00', 5, '400.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-42232199', 'LUX SOAP', '120.00', 3, '360.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-25252720', 'BAKING SODA', '180.00', 7, '1260.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-12415797', 'PEAK MILK TIN', '220.00', 2, '440.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228T76525', 'P-0655108', 'PEAK MILK REFILL', '500.00', 3, '1500.00', 'Pelumi', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-0655108', 'PEAK MILK REFILL', '500.00', 1, '500.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-12415797', 'PEAK MILK TIN', '220.00', 2, '440.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-25252720', 'BAKING SODA', '180.00', 5, '900.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-42232199', 'LUX SOAP', '120.00', 1, '120.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-59447964', 'COCA COLA 50CL', '80.00', 1, '80.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228N52056', 'P-65948223', 'BLACK SOAP', '500.00', 3, '1500.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228X92723', 'P-0655108', 'PEAK MILK REFILL', '500.00', 2, '1000.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228X92723', 'P-12415797', 'PEAK MILK TIN', '220.00', 3, '660.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228X92723', 'P-42232199', 'LUX SOAP', '120.00', 2, '240.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC20211228X92723', 'P-59447964', 'COCA COLA 50CL', '80.00', 2, '160.00', 'Cashier1', 'COMPLETED', '12/28/2021'),
('IVC2022113I35297', 'P-0655108', 'PEAK MILK REFILL', '600.00', 1, '600.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-25252720', 'BAKING SODA', '200.00', 5, '1000.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-42232199', 'LUX SOAP', '120.00', 5, '600.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-59447964', 'COCA COLA 50CL', '70.00', 2, '140.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-65948223', 'BLACK SOAP', '400.00', 2, '800.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-98695671', '40 LEAVES NOTEBOOK', '50.00', 10, '500.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-35948504', 'PEPSI 50CL', '100.00', 20, '2000.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022113I35297', 'P-12415797', 'PEAK MILK TIN', '250.00', 10, '2500.00', 'Temidayo', 'COMPLETED', '1/13/2022'),
('IVC2022114O57687', 'P-0655108', 'PEAK MILK REFILL', '600.00', 1, '600.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114O57687', 'P-25252720', 'BAKING SODA', '200.00', 2, '400.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114O57687', 'P-42232199', 'LUX SOAP', '120.00', 4, '480.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114O57687', 'P-59447964', 'COCA COLA 50CL', '70.00', 5, '350.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114O57687', 'P-65948223', 'BLACK SOAP', '400.00', 2, '800.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114D14665', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114D14665', 'P-25252720', 'BAKING SODA', '200.00', 1, '200.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022114D14665', 'P-59447964', 'COCA COLA 50CL', '70.00', 5, '350.00', 'Temidayo', 'COMPLETED', '1/14/2022'),
('IVC2022120W91369', 'P-0655108', 'PEAK MILK REFILL', '600.00', 1, '600.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120W91369', 'P-12415797', 'PEAK MILK TIN', '250.00', 1, '250.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120W91369', 'P-25252720', 'BAKING SODA', '200.00', 1, '200.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120W91369', 'P-42232199', 'LUX SOAP', '120.00', 1, '120.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-35948504', 'PEPSI 50CL', '100.00', 1, '100.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-98695671', '40 LEAVES NOTEBOOK', '50.00', 2, '100.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-65948223', 'BLACK SOAP', '400.00', 1, '400.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-59447964', 'COCA COLA 50CL', '70.00', 2, '140.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-42232199', 'LUX SOAP', '120.00', 3, '360.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-25252720', 'BAKING SODA', '200.00', 1, '200.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-12415797', 'PEAK MILK TIN', '250.00', 2, '500.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120I33089', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120A2693', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120A2693', 'P-12415797', 'PEAK MILK TIN', '250.00', 2, '500.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022120A2693', 'P-59447964', 'COCA COLA 50CL', '70.00', 5, '350.00', 'Temidayo', 'COMPLETED', '1/20/2022'),
('IVC2022214X95117', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Temidayo', 'COMPLETED', '2/14/2022'),
('IVC2022214X95117', 'P-12415797', 'PEAK MILK TIN', '250.00', 2, '500.00', 'Temidayo', 'COMPLETED', '2/14/2022'),
('IVC2022214X95117', 'P-25252720', 'BAKING SODA', '200.00', 1, '200.00', 'Temidayo', 'COMPLETED', '2/14/2022'),
('IVC2022214X95117', 'P-65948223', 'BLACK SOAP', '400.00', 2, '800.00', 'Temidayo', 'COMPLETED', '2/14/2022'),
('IVC2022214X95117', 'P-35948504', 'PEPSI 50CL', '100.00', 3, '300.00', 'Temidayo', 'COMPLETED', '2/14/2022'),
('IVC2022227P62560', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-12415797', 'PEAK MILK TIN', '250.00', 2, '500.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-25252720', 'BAKING SODA', '200.00', 2, '400.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-42232199', 'LUX SOAP', '120.00', 5, '600.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-59447964', 'COCA COLA 50CL', '70.00', 2, '140.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-65948223', 'BLACK SOAP', '400.00', 3, '1200.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-98695671', '40 LEAVES NOTEBOOK', '50.00', 4, '200.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227P62560', 'P-35948504', 'PEPSI 50CL', '100.00', 4, '400.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227I32583', 'P-35948504', 'PEPSI 50CL', '100.00', 5, '500.00', 'Temidayo', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-35948504', 'PEPSI 50CL', '100.00', 5, '500.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-0655108', 'PEAK MILK REFILL', '600.00', 2, '1200.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-12415797', 'PEAK MILK TIN', '250.00', 5, '1250.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-25252720', 'BAKING SODA', '200.00', 5, '1000.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-42232199', 'LUX SOAP', '120.00', 4, '480.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-59447964', 'COCA COLA 50CL', '70.00', 3, '210.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC2022227B6721', 'P-65948223', 'BLACK SOAP', '400.00', 3, '1200.00', 'Pelumi', 'COMPLETED', '2/27/2022'),
('IVC202237D15601', 'P-0655108', 'PEAK MILK REFILL', '600.00', 4, '2400.00', 'Temidayo', 'COMPLETED', '3/7/2022'),
('IVC202237D15601', 'P-12415797', 'PEAK MILK TIN', '250.00', 2, '500.00', 'Temidayo', 'COMPLETED', '3/7/2022'),
('IVC202237D15601', 'P-25252720', 'BAKING SODA', '200.00', 2, '400.00', 'Temidayo', 'COMPLETED', '3/7/2022'),
('IVC202237D15601', 'P-42232199', 'LUX SOAP', '120.00', 1, '120.00', 'Temidayo', 'COMPLETED', '3/7/2022'),
('IVC2022310M51156', 'P-0655108', 'PEAK MILK REFILL', '600.00', 3, '1800.00', 'Temidayo', 'COMPLETED', '3/10/2022'),
('IVC2022310M51156', 'P-25252720', 'BAKING SODA', '200.00', 2, '400.00', 'Temidayo', 'COMPLETED', '3/10/2022'),
('IVC2022310M51156', 'P-42232199', 'LUX SOAP', '120.00', 2, '240.00', 'Temidayo', 'COMPLETED', '3/10/2022');

-- --------------------------------------------------------

--
-- Table structure for table `tblcategory`
--

CREATE TABLE IF NOT EXISTS `tblcategory` (
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcategory`
--

INSERT INTO `tblcategory` (`name`) VALUES
('BEER'),
('BEVERAGES'),
('BOOKS'),
('COOKING OIL'),
('CREAM'),
('DRINKS'),
('ENERGY DRINKS'),
('EXERCISE BOOK'),
('MILK REFILL'),
('MILK SACHET'),
('MILK TIN'),
('OTHERS'),
('SOFT DRINKS'),
('TOMATO PASTE'),
('WINE'),
('YOGHURT');

-- --------------------------------------------------------

--
-- Table structure for table `tbllogs`
--

CREATE TABLE IF NOT EXISTS `tbllogs` (
  `username` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `login` varchar(50) NOT NULL,
  `logout` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbllogs`
--

INSERT INTO `tbllogs` (`username`, `date`, `login`, `logout`) VALUES
('Afolabi', 'Sunday, October 03, 2021', '9:38 PM', '10:19 PM'),
('Afolabi', 'Sunday, October 03, 2021', '9:45 PM', '10:19 PM'),
('Afolabi', 'Sunday, October 03, 2021', '9:47 PM', '10:19 PM'),
('Temidayo', 'Sunday, October 03, 2021', '9:49 PM', '10:09 PM'),
('Afolabi', 'Sunday, October 03, 2021', '9:50 PM', '10:19 PM'),
('Cashier', 'Sunday, October 03, 2021', '9:55 PM', ''),
('Temidayo', 'Sunday, October 03, 2021', '10:08 PM', '10:09 PM'),
('Afolabi', 'Sunday, October 03, 2021', '10:09 PM', '10:19 PM'),
('Albert', 'Sunday, October 03, 2021', '10:11 PM', '10:11 PM'),
('Pelumi', 'Sunday, October 03, 2021', '10:12 PM', '10:16 PM'),
('Pelumi', 'Sunday, October 03, 2021', '10:15 PM', '10:16 PM'),
('Afolabi', 'Sunday, October 03, 2021', '10:17 PM', '10:19 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:04 PM', '10:09 PM'),
('Afolabi', 'Saturday, October 16, 2021', '9:05 PM', '9:23 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:20 PM', '10:09 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:20 PM', '10:09 PM'),
('Afolabi', 'Saturday, October 16, 2021', '9:22 PM', '9:23 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:23 PM', '10:09 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:44 PM', '10:09 PM'),
('Temidayo', 'Saturday, October 16, 2021', '9:45 PM', '10:09 PM'),
('Pelumi', 'Saturday, October 16, 2021', '9:49 PM', ''),
('Temidayo', 'Saturday, October 16, 2021', '9:59 PM', '10:09 PM'),
('Temidayo', 'Saturday, October 16, 2021', '10:07 PM', '10:09 PM'),
('Pelumi', 'Saturday, October 16, 2021', '10:12 PM', ''),
('Temidayo', 'Saturday, October 16, 2021', '10:20 PM', ''),
('Cashier', 'Monday, October 18, 2021', '7:05 PM', ''),
('Temidayo', 'Monday, October 18, 2021', '7:11 PM', ''),
('Afolabi', 'Monday, October 18, 2021', '7:13 PM', '7:17 PM'),
('Afolabi', 'Tuesday, November 02, 2021', '12:26 PM', '12:30 PM'),
('Temidayo', 'Tuesday, November 02, 2021', '12:30 PM', '12:41 PM'),
('Temidayo', 'Tuesday, November 02, 2021', '12:40 PM', '12:41 PM'),
('Afolabi', 'Thursday, November 18, 2021', '12:37 AM', '10:23 AM'),
('Temidayo', 'Thursday, November 18, 2021', '12:42 AM', '10:21 AM'),
('Afolabi', 'Thursday, November 18, 2021', '10:06 AM', '10:23 AM'),
('Temidayo', 'Thursday, November 18, 2021', '10:16 AM', '10:21 AM'),
('Afolabi', 'Thursday, November 18, 2021', '10:21 AM', '10:23 AM'),
('Temidayo', 'Saturday, November 27, 2021', '1:32 PM', '1:34 PM'),
('Afolabi', 'Saturday, November 27, 2021', '1:34 PM', '1:35 PM'),
('Temidayo', 'Monday, December 13, 2021', '3:35 PM', '3:43 PM'),
('Afolabi', 'Monday, December 13, 2021', '3:43 PM', '3:48 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '1:48 PM', '2:34 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '2:18 PM', '9:43 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '2:18 PM', '2:34 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '2:23 PM', '2:34 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '2:26 PM', '9:43 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '2:26 PM', '2:34 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '2:27 PM', '2:34 PM'),
('Temidayo', 'Tuesday, December 28, 2021', '2:58 PM', ''),
('Afolabi', 'Tuesday, December 28, 2021', '8:11 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:19 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:24 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:25 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:31 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:31 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:36 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:44 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:45 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:46 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:51 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '8:58 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '9:05 PM', '9:43 PM'),
('Pelumi', 'Tuesday, December 28, 2021', '9:17 PM', '9:31 PM'),
('Pelumi', 'Tuesday, December 28, 2021', '9:19 PM', '9:31 PM'),
('Pelumi', 'Tuesday, December 28, 2021', '9:21 PM', '9:31 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '9:32 PM', '9:43 PM'),
('Cashier1', 'Tuesday, December 28, 2021', '9:32 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '9:34 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '9:40 PM', '9:43 PM'),
('Cashier1', 'Tuesday, December 28, 2021', '9:41 PM', '9:43 PM'),
('Afolabi', 'Tuesday, December 28, 2021', '9:43 PM', '9:43 PM'),
('Afolabi', 'Thursday, January 13, 2022', '8:46 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '8:59 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:10 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:11 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:22 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:30 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:33 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:37 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:40 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:42 PM', '10:02 PM'),
('Afolabi', 'Thursday, January 13, 2022', '9:45 PM', '10:02 PM'),
('Temidayo', 'Thursday, January 13, 2022', '9:48 PM', '10:15 PM'),
('Afolabi', 'Thursday, January 13, 2022', '10:02 PM', '10:02 PM'),
('Temidayo', 'Thursday, January 13, 2022', '10:02 PM', '10:15 PM'),
('Temidayo', 'Thursday, January 13, 2022', '10:04 PM', '10:15 PM'),
('Temidayo', 'Thursday, January 13, 2022', '10:08 PM', '10:15 PM'),
('Temidayo', 'Thursday, January 13, 2022', '10:11 PM', '10:15 PM'),
('Temidayo', 'Thursday, January 13, 2022', '10:14 PM', '10:15 PM'),
('Temidayo', 'Friday, January 14, 2022', '10:38 AM', '9:01 PM'),
('Afolabi', 'Friday, January 14, 2022', '10:46 AM', '9:06 PM'),
('Afolabi', 'Friday, January 14, 2022', '10:51 AM', '9:06 PM'),
('Afolabi', 'Friday, January 14, 2022', '10:52 AM', '9:06 PM'),
('Afolabi', 'Friday, January 14, 2022', '10:59 AM', '9:06 PM'),
('Temidayo', 'Friday, January 14, 2022', '11:00 AM', '9:01 PM'),
('Afolabi', 'Friday, January 14, 2022', '8:44 PM', '9:06 PM'),
('Temidayo', 'Friday, January 14, 2022', '8:44 PM', '9:01 PM'),
('Afolabi', 'Friday, January 14, 2022', '9:02 PM', '9:06 PM'),
('Afolabi', 'Wednesday, October 13, 2021', '9:04 PM', ''),
('Afolabi', 'Friday, January 14, 2022', '9:06 PM', ''),
('Afolabi', 'Friday, January 14, 2022', '9:12 PM', ''),
('Afolabi', 'Friday, January 14, 2022', '9:24 PM', ''),
('Temidayo', 'Thursday, January 20, 2022', '8:14 PM', '9:46 PM'),
('Temidayo', 'Thursday, January 20, 2022', '8:23 PM', '9:46 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:09 PM', '9:47 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:19 PM', '9:47 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:20 PM', '9:47 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:28 PM', '9:47 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:33 PM', '9:47 PM'),
('Temidayo', 'Thursday, January 20, 2022', '9:37 PM', '9:46 PM'),
('Afolabi', 'Thursday, January 20, 2022', '9:46 PM', '9:47 PM'),
('Afolabi', 'Monday, February 14, 2022', '10:42 AM', '10:42 AM'),
('Temidayo', 'Monday, February 14, 2022', '10:42 AM', '10:45 AM'),
('Afolabi', 'Sunday, February 27, 2022', '8:15 PM', '8:54 PM'),
('Pelumi', 'Sunday, February 27, 2022', '8:28 PM', '8:41 PM'),
('Afolabi', 'Sunday, February 27, 2022', '8:28 PM', '8:54 PM'),
('Temidayo', 'Sunday, February 27, 2022', '8:28 PM', '8:59 PM'),
('Afolabi', 'Sunday, February 27, 2022', '8:39 PM', '8:54 PM'),
('Pelumi', 'Sunday, February 27, 2022', '8:40 PM', '8:41 PM'),
('Afolabi', 'Sunday, February 27, 2022', '8:42 PM', '8:54 PM'),
('Afolabi', 'Sunday, February 27, 2022', '8:52 PM', '8:54 PM'),
('Afolabi', 'Sunday, February 27, 2022', '8:54 PM', '8:54 PM'),
('Temidayo', 'Sunday, February 27, 2022', '8:54 PM', '8:59 PM'),
('Afolabi', 'Tuesday, March 01, 2022', '8:54 PM', '9:05 PM'),
('Afolabi', 'Tuesday, March 01, 2022', '8:54 PM', '9:05 PM'),
('Afolabi', 'Tuesday, March 01, 2022', '8:57 PM', '9:05 PM'),
('Afolabi', 'Tuesday, March 01, 2022', '9:05 PM', '9:05 PM'),
('Pelumi', 'Tuesday, March 01, 2022', '9:05 PM', '9:08 PM'),
('Afolabi', 'Thursday, March 03, 2022', '8:49 PM', '8:49 PM'),
('afolabi', 'Friday, March 04, 2022', '8:32 PM', '8:44 PM'),
('Cashier1', 'Friday, March 04, 2022', '8:44 PM', '8:45 PM'),
('Temidayo', 'Monday, March 07, 2022', '9:07 PM', '9:13 PM'),
('Afolabi', 'Monday, March 07, 2022', '9:13 PM', '9:15 PM'),
('Afolabi', 'Thursday, March 10, 2022', '6:50 PM', '6:53 PM'),
('Temidayo', 'Thursday, March 10, 2022', '6:51 PM', '6:53 PM'),
('Afolabi', 'Thursday, March 10, 2022', '6:53 PM', '6:53 PM'),
('Afolabi', 'Tuesday, March 15, 2022', '9:14 PM', '9:22 PM'),
('Afolabi', 'Sunday, March 20, 2022', '8:09 PM', '8:13 PM'),
('Afolabi', 'Sunday, March 20, 2022', '8:11 PM', '8:13 PM'),
('Temidayo', 'Sunday, March 20, 2022', '8:13 PM', '8:14 PM');

-- --------------------------------------------------------

--
-- Table structure for table `tblpayment`
--

CREATE TABLE IF NOT EXISTS `tblpayment` (
  `invoiceno` varchar(255) NOT NULL,
  `total` decimal(10,2) DEFAULT NULL,
  `amountpaid` decimal(10,2) NOT NULL,
  `mchange` decimal(10,2) NOT NULL,
  `paymode` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `time` varchar(50) NOT NULL,
  `user` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`invoiceno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblpayment`
--

INSERT INTO `tblpayment` (`invoiceno`, `total`, `amountpaid`, `mchange`, `paymode`, `date`, `time`, `user`, `status`) VALUES
('IVC20211228N52056', '3540.00', '3540.00', '0.00', 'Bank Transfer', '12/28/2021', '9:33 PM', 'Cashier1', 'COMPLETED'),
('IVC20211228T76525', '6360.00', '6500.00', '140.00', 'Cash', '12/28/2021', '9:29 PM', 'Pelumi', 'COMPLETED'),
('IVC20211228V85951', '3580.00', '4000.00', '420.00', 'Cash', '12/28/2021', '3:00 PM', 'Temidayo', 'COMPLETED'),
('IVC20211228X92723', '2060.00', '2100.00', '40.00', 'Cash', '12/28/2021', '9:42 PM', 'Cashier1', 'COMPLETED'),
('IVC2022113I35297', '8140.00', '8200.00', '60.00', 'POS (ATM)', '1/13/2022', '9:55 PM', 'Temidayo', 'COMPLETED'),
('IVC2022114D14665', '1750.00', '2000.00', '250.00', 'Cash', '1/14/2022', '8:45 PM', 'Temidayo', 'COMPLETED'),
('IVC2022114O57687', '2630.00', '3000.00', '370.00', 'Cash', '1/14/2022', '11:04 AM', 'Temidayo', 'COMPLETED'),
('IVC2022120A2693', '2050.00', '2100.00', '50.00', 'Cash', '1/20/2022', '9:45 PM', 'Temidayo', 'COMPLETED'),
('IVC2022120I33089', '3000.00', '3000.00', '0.00', 'POS (ATM)', '1/20/2022', '9:39 PM', 'Temidayo', 'COMPLETED'),
('IVC2022120W91369', '1170.00', '1200.00', '30.00', 'Cash', '1/20/2022', '8:26 PM', 'Temidayo', 'COMPLETED'),
('IVC2022214X95117', '3000.00', '3000.00', '0.00', 'Cash', '2/14/2022', '10:44 AM', 'Temidayo', 'COMPLETED'),
('IVC2022227B6721', '5840.00', '6000.00', '160.00', 'Cash', '2/27/2022', '8:41 PM', 'Pelumi', 'COMPLETED'),
('IVC2022227I32583', '500.00', '1000.00', '500.00', 'POS (ATM)', '2/27/2022', '8:39 PM', 'Temidayo', 'COMPLETED'),
('IVC2022227P62560', '4640.00', '5000.00', '360.00', 'Cash', '2/27/2022', '8:36 PM', 'Temidayo', 'COMPLETED'),
('IVC2022310M51156', '2440.00', '2500.00', '60.00', 'Cash', '3/10/2022', '6:53 PM', 'Temidayo', 'COMPLETED'),
('IVC202237D15601', '3420.00', '3500.00', '80.00', 'Cash', '3/7/2022', '9:12 PM', 'Temidayo', 'COMPLETED');

-- --------------------------------------------------------

--
-- Table structure for table `tblproduct`
--

CREATE TABLE IF NOT EXISTS `tblproduct` (
  `code` varchar(100) NOT NULL,
  `barcode` varchar(13) NOT NULL,
  `pname` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `description` varchar(500) NOT NULL,
  `status` varchar(20) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `picture` blob NOT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblproduct`
--

INSERT INTO `tblproduct` (`code`, `barcode`, `pname`, `category`, `description`, `status`, `quantity`, `price`, `picture`) VALUES
('P-0655108', '2343536363530', 'PEAK MILK REFILL', 'MILK REFILL', 'N/A', 'Active', 42, '600.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd1e21ff0090e784ff00ec9fc9ff00a4575459ff00c905d67fec1561ff00a74bba3c43ff0021cf09ff00d93f93ff0048aea800f0affc9435ff00b05681ff00a374da3c43ff0026bde13ffb0ac9ff00a15d51e15ff9286bff0060ad03ff0046e9b47887fe4d7bc27ff61593ff0042baa002f3fe4a1e8dff006502ff00ff0046da51f0bbfe407a6ffd854ffe96e9145e7fc943d1bfeca05fff00e8db4a3e177fc80f4dff00b0a9ff00d2dd22803bfd1bfe49e7c5bffb0aeb1ffa285117fc943f017fd857c49ffa365a346ff9279f16ff00ec2bac7fe8a1445ff250fc05ff00615f127fe8d9680380f8c3ff0021cf1b7fd85748ff00d229eb9ff17ffccfff00f635c5ff00b7d5d07c61ff0090e78dbfec2ba47fe914f5cff8bffe67ff00fb1ae2ff00dbea00e83c43ff0025abc27ff61593ff004ef7547887fe439e13ff00b27f27fe915d51e21ff92d5e13ff00b0ac9ffa77baa3c43ff21cf09ffd93f93ff48aea803bff000d7fc873c0dff60ad27ff48b53ae7f5aff009243f14bfec6b9ff00f4a20ae83c35ff0021cf037fd82b49ff00d22d4eb9fd6bfe490fc52ffb1ae7ff00d2882800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd1e21ff90e784ffec9fc9ffa4575459ffc905d67fec1561ffa74bba3c43ff21cf09ffd93f93ff48aea800f0aff00c9435ffb05681ffa374da3c43ff26bde13ff00b0ac9ffa15d51e15ff009286bff60ad03ff46e9b47887fe4d7bc27ff0061593ff42baa002f3fe4a1e8dff6502fff00f46da51f0bbfe407a6ff00d854ff00e96e9145e7fc943d1bfeca05ff00fe8db4a3e177fc80f4dffb0a9ffd2dd22803bfd1bfe49e7c5bff00b0aeb1ff00a285117fc943f017fd857c49ff00a365a346ff009279f16ffec2bac7fe8a1445ff00250fc05ff615f127fe8d9680380f8c3ff21cf1b7fd85748ffd229eb9ff0017ff00ccff00ff00635c5ffb7d5d07c61ff90e78dbfec2ba47fe914f5cff008bff00e67fff00b1ae2ffdbea00e83c43ff25abc27ff0061593ff4ef7547887fe439e13ffb27f27fe915d51e21ff0092d5e13ffb0ac9ff00a77baa3c43ff0021cf09ff00d93f93ff0048aea803bff0d7fc873c0dff0060ad27ff0048b53ae7f5aff9243f14bfec6b9fff004a20ae83c35ff21cf037fd82b49ffd22d4eb9fd6bfe490fc52ff00b1ae7ffd2882800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd1e21ff0090e784ff00ec9fc9ff00a4575459ff00c905d67fec1561ff00a74bba3c43ff0021cf09ff00d93f93ff0048aea800f0affc9435ff00b05681ff00a374da3c43ff0026bde13ffb0ac9ff00a15d51e15ff9286bff0060ad03ff0046e9b47887fe4d7bc27ff61593ff0042baa002f3fe4a1e8dff006502ff00ff0046da51f0bbfe407a6ffd854ffe96e9145e7fc943d1bfeca05fff00e8db4a3e177fc80f4dff00b0a9ff00d2dd22803bfd1bfe49e7c5bffb0aeb1ffa285117fc943f017fd857c49ffa365a346ff9279f16ff00ec2bac7fe8a1445ff250fc05ff00615f127fe8d9680380f8c3ff0021cf1b7fd85748ff00d229eb9ff17ffccfff00f635c5ff00b7d5d07c61ff0090e78dbfec2ba47fe914f5cff8bffe67ff00fb1ae2ff00dbea00e83c43ff0025abc27ff61593ff004ef7547887fe439e13ff00b27f27fe915d51e21ff92d5e13ff00b0ac9ffa77baa3c43ff21cf09ffd93f93ff48aea803bff000d7fc873c0dff60ad27ff48b53ae7f5aff009243f14bfec6b9ff00f4a20ae83c35ff0021cf037fd82b49ff00d22d4eb9fd6bfe490fc52ffb1ae7ff00d2882800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd1e21ff90e784ffec9fc9ffa4575459ffc905d67fec1561ffa74bba3c43ff21cf09ffd93f93ff48aea800f0aff00c9435ffb05681ffa374da3c43ff26bde13ff00b0ac9ffa15d51e15ff009286bff60ad03ff46e9b47887fe4d7bc27ff0061593ff42baa002f3fe4a1e8dff6502fff00f46da51f0bbfe407a6ff00d854ff00e96e9145e7fc943d1bfeca05ff00fe8db4a3e177fc80f4dffb0a9ffd2dd22803bfd1bfe49e7c5bff00b0aeb1ff00a285117fc943f017fd857c49ff00a365a346ff009279f16ffec2bac7fe8a1445ff00250fc05ff615f127fe8d9680380f8c3ff21cf1b7fd85748ffd229eb9ff0017ff00ccff00ff00635c5ffb7d5d07c61ff90e78dbfec2ba47fe914f5cff008bff00e67fff00b1ae2ffdbea00e83c43ff25abc27ff0061593ff4ef7547887fe439e13ffb27f27fe915d51e21ff0092d5e13ffb0ac9ff00a77baa3c43ff0021cf09ff00d93f93ff0048aea803bff0d7fc873c0dff0060ad27ff0048b53ae7f5aff9243f14bfec6b9fff004a20ae83c35ff21cf037fd82b49ffd22d4eb9fd6bfe490fc52ff00b1ae7ffd2882800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-106870491', '4353678252929', 'TEST PRODUCT', 'COOKING OIL', 'Test cooking oil', 'Active', 50, '150.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f2b02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f280303e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbeae83e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbea00f7ff00f9923fee6bff00dcd579ff00867fe490e9ff00f62a7887ff004a22af40ff009923fee6bffdcd579ff867fe490e9fff0062a7887ff4a22a00c0f1dffc97af137fd82aebff004d6d5bff0008ff00e4af4fff0062a58ffe93d9d6078eff00e4bd789bfec1575ffa6b6adff847ff00257a7ffb152c7ff49ece803035cff927975ff60a87ff004568747887fe4d7bc27ff61593ff0042baa35cff00927975ff0060a87ff4568747887fe4d7bc27ff0061593ff42baa003c43ff0025abc27ff61593ff004ef7547837fe48adcffd85752ffd344d47887fe4b5784ffec2b27fe9deea8f06ff00c915b9ff00b0aea5ff00a689a800f197fc80edbfec9fe9bffa5b0d6feb5ff2487e297fd8d73ffe9441581e32ff00901db7fd93fd37ff004b61adfd6bfe490fc52ffb1ae7ff00d2882800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f2b02cff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f280303e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbeae83e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbea00f7fff009923fee6bffdcd579ff867fe490e9fff0062a7887ff4a22af40ff9923fee6bff00dcd579ff00867fe490e9ff00f62a7887ff004a22a00c0f1dff00c97af137fd82aebff4d6d5bff08ffe4af4ff00f62a58ff00e93d9d6078effe4bd789bfec1575ff00a6b6adff00847ff257a7ff00b152c7ff0049ece803035cff00927975ff0060a87ff4568747887fe4d7bc27ff0061593ff42baa35cff927975ff60a87ff004568747887fe4d7bc27ff61593ff0042baa003c43ff25abc27ff0061593ff4ef7547837fe48adcff00d85752ff00d344d47887fe4b5784ff00ec2b27fe9deea8f06ffc915b9ffb0aea5ffa689a800f197fc80edbfec9fe9bff00a5b0d6feb5ff002487e297fd8d73ff00e9441581e32ff901db7fd93fd37ff4b61adfd6bfe490fc52ff00b1ae7ffd2882800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f2b02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f280303e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbeae83e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbea00f7ff00f9923fee6bff00dcd579ff00867fe490e9ff00f62a7887ff004a22af40ff009923fee6bffdcd579ff867fe490e9fff0062a7887ff4a22a00c0f1dffc97af137fd82aebff004d6d5bff0008ff00e4af4fff0062a58ffe93d9d6078eff00e4bd789bfec1575ffa6b6adff847ff00257a7ffb152c7ff49ece803035cff927975ff60a87ff004568747887fe4d7bc27ff61593ff0042baa35cff00927975ff0060a87ff4568747887fe4d7bc27ff0061593ff42baa003c43ff0025abc27ff61593ff004ef7547837fe48adcffd85752ffd344d47887fe4b5784ffec2b27fe9deea8f06ff00c915b9ff00b0aea5ff00a689a800f197fc80edbfec9fe9bffa5b0d6feb5ff2487e297fd8d73ffe9441581e32ff00901db7fd93fd37ff004b61adfd6bfe490fc52ffb1ae7ff00d2882800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f2b02cff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f280303e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbeae83e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbea00f7fff009923fee6bffdcd579ff867fe490e9fff0062a7887ff4a22af40ff9923fee6bff00dcd579ff00867fe490e9ff00f62a7887ff004a22a00c0f1dff00c97af137fd82aebff4d6d5bff08ffe4af4ff00f62a58ff00e93d9d6078effe4bd789bfec1575ff00a6b6adff00847ff257a7ff00b152c7ff0049ece803035cff00927975ff0060a87ff4568747887fe4d7bc27ff0061593ff42baa35cff927975ff60a87ff004568747887fe4d7bc27ff61593ff0042baa003c43ff25abc27ff0061593ff4ef7547837fe48adcff00d85752ff00d344d47887fe4b5784ff00ec2b27fe9deea8f06ffc915b9ffb0aea5ffa689a800f197fc80edbfec9fe9bff00a5b0d6feb5ff002487e297fd8d73ff00e9441581e32ff901db7fd93fd37ff4b61adfd6bfe490fc52ff00b1ae7ffd2882800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-12415797', '3452626242270', 'PEAK MILK TIN', 'MILK TIN', 'N/A', 'Active', 37, '250.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd77f67ff24f359ffb27f61ffa2aeeb80b3ff920bacffd82ac3ff4e9775dfd9ffc93cd67fec9fd87fe8abba00e7f5aff009243f14bfec6b9ff00f4a20a3c37ff0035d3fede7ff6ea8d6bfe490fc52ffb1ae7ff00d28828f0dffcd74ffb79ff00dbaa003e167fc9c2f8d7fedfbff4ad2b80f1f7fc8b1e1dff00807fe9b74daeff00e167fc9c2f8d7fedfbff004ad2b80f1f7fc8b1e1dff807fe9b74da00f5ff008a3ff21cd4bfec143ff48b57ae02f3fe4a1e8dff006502ff00ff0046da577ff147fe439a97fd8287fe916af5c05e7fc943d1bfeca05fff00e8db4a003e267fc943f893ff0060ab4ffd1b635bff001b7fe458d77fec6bb7ff00d36c7581f133fe4a1fc49ffb055a7fe8db1adff8dbff0022c6bbff00635dbffe9b63a00c0f10ff00c96af09ffd8564ff00d3bdd51e21ff0090e784ff00ec9fc9ff00a457547887fe4b5784ff00ec2b27fe9deea8f10ffc873c27ff0064fe4ffd22baa003c65ff203b6ff00b27fa6ff00e96c35bfad7fc921f8a5ff00635cff00fa51056078cbfe4076dff64ff4dffd2d86b7f5aff9243f14bfec6b9fff004a20a003e2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775dfd9ffc93cd67fec9fd87fe8abbae02cffe482eb3ff0060ab0ffd3a5dd77f67ff0024f359ff00b27f61ff00a2aee8039fd6bfe490fc52ff00b1ae7ffd28828f0dff00cd74ff00b79ffdbaa35aff009243f14bfec6b9ff00f4a20a3c37ff0035d3fede7ff6ea800f859ff270be35ff00b7effd2b4ae03c7dff0022c7877fe01ffa6dd36bbff859ff00270be35ffb7eff00d2b4ae03c7dff22c7877fe01ff00a6dd36803d7fe28ffc87352ffb050ffd22d5eb80bcff009287a37fd940bfff00d1b695dffc51ff0090e6a5ff0060a1ff00a45abd70179ff250f46ffb2817ff00fa36d2800f899ff250fe24ff00d82ad3ff0046d8d6ff00c6dff91635dffb1aedff00f4db1d607c4cff009287f127fec1569ffa36c6b7fe36ff00c8b1aeff00d8d76fff00a6d8e80303c43ff25abc27ff0061593ff4ef7547887fe439e13ffb27f27fe915d51e21ff0092d5e13ffb0ac9ff00a77baa3c43ff0021cf09ff00d93f93ff0048aea800f197fc80edbfec9fe9bffa5b0d6feb5ff2487e297fd8d73ffe9441581e32ff00901db7fd93fd37ff004b61adfd6bfe490fc52ffb1ae7ff00d2882800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd77f67ff0024f359ff00b27f61ff00a2aeeb80b3ff00920bacff00d82ac3ff004e9775dfd9ff00c93cd67fec9fd87fe8abba00e7f5aff9243f14bfec6b9fff004a20a3c37ff35d3fede7ff006ea8d6bfe490fc52ff00b1ae7ffd28828f0dff00cd74ff00b79ffdbaa003e167fc9c2f8d7fedfbff004ad2b80f1f7fc8b1e1dff807fe9b74daeffe167fc9c2f8d7fedfbff4ad2b80f1f7fc8b1e1dff00807fe9b74da00f5ff8a3ff0021cd4bfec143ff0048b57ae02f3fe4a1e8dff6502fff00f46da577ff00147fe439a97fd8287fe916af5c05e7fc943d1bfeca05ff00fe8db4a003e267fc943f893ff60ab4ff00d1b635bff1b7fe458d77fec6bb7ffd36c7581f133fe4a1fc49ff00b055a7fe8db1adff008dbff22c6bbff635dbff00e9b63a00c0f10ffc96af09ff00d8564ffd3bdd51e21ff90e784ffec9fc9ffa457547887fe4b5784ffec2b27fe9deea8f10ff00c873c27ff64fe4ff00d22baa003c65ff00203b6ffb27fa6ffe96c35bfad7fc921f8a5ff635cfff00a51056078cbfe4076dff0064ff004dff00d2d86b7f5aff009243f14bfec6b9ff00f4a20a003e2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775dfd9ff00c93cd67fec9fd87fe8abbae02cff00e482eb3ff60ab0ff00d3a5dd77f67ff24f359ffb27f61ffa2aee8039fd6bfe490fc52ffb1ae7ff00d28828f0dffcd74ffb79ff00dbaa35aff9243f14bfec6b9fff004a20a3c37ff35d3fede7ff006ea800f859ff00270be35ffb7eff00d2b4ae03c7dff22c7877fe01ff00a6dd36bbff00859ff270be35ff00b7effd2b4ae03c7dff0022c7877fe01ffa6dd36803d7fe28ff00c87352ff00b050ff00d22d5eb80bcff9287a37fd940bff00fd1b695dff00c51ff90e6a5ff60a1ffa45abd70179ff00250f46ff00b2817fff00a36d2800f899ff00250fe24ffd82ad3ff46d8d6ffc6dff0091635dff00b1aedfff004db1d607c4cff9287f127fec1569ff00a36c6b7fe36ffc8b1aeffd8d76ff00fa6d8e80303c43ff0025abc27ff61593ff004ef7547887fe439e13ff00b27f27fe915d51e21ff92d5e13ff00b0ac9ffa77baa3c43ff21cf09ffd93f93ff48aea800f197fc80edbfec9fe9bff00a5b0d6feb5ff002487e297fd8d73ff00e9441581e32ff901db7fd93fd37ff4b61adfd6bfe490fc52ff00b1ae7ffd2882800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-25252720', '2088888825230', 'BAKING SODA', 'OTHERS', 'N/A', 'Active', 39, '200.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fff00f3aaac0b3ff920bacffd82ac3ff4e9775bff00fceaa80303e267fc943f893ff60ab4ff00d1b635bfe19ff9243a7ffd8a9e21ff00d288ab03e267fc943f893ff60ab4ff00d1b635bfe19ff9243a7ffd8a9e21ff00d288a8030346ff009287f16ffec15ac7fe8d147c79ff0090e49ff6159fff0048b4fa346ff9287f16ff00ec15ac7fe8d147c79ff90e49ff006159ff00f48b4fa00eff00c77ff1e9e26ffb0add7fe981ab80bcff00920ba37fd82aff00ff004e9695dff8effe3d3c4dff00615baffd303570179ff241746ffb055fff00e9d2d2800f899ff250fe24ff00d82ad3ff0046d8d73fe2ff00f99fff00ec6b8bff006faba0f899ff00250fe24ffd82ad3ff46d8d73fe2fff0099ff00fec6b8bff6fa803a0f10ff00c96af09ffd8564ff00d3bdd51e21ff0090e784ff00ec9fc9ff00a457547887fe4b5784ff00ec2b27fe9deea8f10ffc873c27ff0064fe4ffd22baa003c43ff21cf09ffd93f93ff48aeab7fc7dff002487c3bff62a27fe9469b581e21ff90e784ffec9fc9ffa45755bfe3eff009243e1dffb1513ff004a34da003e2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775bfff00ceaab02cff00e482eb3ff60ab0ff00d3a5dd6fff00f3aaa00c0f899ff250fe24ff00d82ad3ff0046d8d6ff00867fe490e9ff00f62a7887ff004a22ac0f899ff250fe24ff00d82ad3ff0046d8d6ff00867fe490e9ff00f62a7887ff004a22a00c0d1bfe4a1fc5bffb056b1ffa3451f1e7fe43927fd8567ffd22d3e8d1bfe4a1fc5bff00b056b1ff00a3451f1e7fe43927fd8567ff00d22d3e803bff001dff00c7a789bfec2b75ff00a606ae02f3fe482e8dff0060abff00fd3a5a577fe3bff8f4f137fd856ebff4c0d5c05e7fc905d1bfec157fff00a74b4a003e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbeae83e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbea00e83c43ff0025abc27ff61593ff004ef7547887fe439e13ff00b27f27fe915d51e21ff92d5e13ff00b0ac9ffa77baa3c43ff21cf09ffd93f93ff48aea800f10ff00c873c27ff64fe4ff00d22baadff1f7fc921f0eff00d8a89ffa51a6d607887fe439e13ffb27f27fe915d56ff8fbfe490f877fec544ffd28d36800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6ff00ff003aaac0b3ff00920bacff00d82ac3ff004e9775bfff00ceaa80303e267fc943f893ff0060ab4ffd1b635bfe19ff009243a7ff00d8a9e21ffd288ab03e267fc943f893ff0060ab4ffd1b635bfe19ff009243a7ff00d8a9e21ffd288a8030346ff9287f16ff00ec15ac7fe8d147c79ff90e49ff006159ff00f48b4fa346ff009287f16ffec15ac7fe8d147c79ff0090e49ff6159fff0048b4fa00effc77ff001e9e26ff00b0add7fe981ab80bcff920ba37fd82afff00f4e9695dff008eff00e3d3c4dff615baff00d303570179ff00241746ff00b055ff00fe9d2d2800f899ff00250fe24ffd82ad3ff46d8d73fe2fff0099ff00fec6b8bff6faba0f899ff250fe24ff00d82ad3ff0046d8d73fe2ff00f99fff00ec6b8bff006fa803a0f10ffc96af09ff00d8564ffd3bdd51e21ff90e784ffec9fc9ffa457547887fe4b5784ffec2b27fe9deea8f10ff00c873c27ff64fe4ff00d22baa003c43ff0021cf09ff00d93f93ff0048aeab7fc7dff2487c3bff0062a27fe9469b581e21ff0090e784ff00ec9fc9ff00a45755bfe3eff9243e1dff00b1513ff4a34da003e2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775bff00fceaab02cffe482eb3ff0060ab0ffd3a5dd6ff00ff003aaa00c0f899ff00250fe24ffd82ad3ff46d8d6ff867fe490e9fff0062a7887ff4a22ac0f899ff00250fe24ffd82ad3ff46d8d6ff867fe490e9fff0062a7887ff4a22a00c0d1bfe4a1fc5bff00b056b1ff00a3451f1e7fe43927fd8567ff00d22d3e8d1bfe4a1fc5bffb056b1ffa3451f1e7fe43927fd8567ffd22d3e803bff1dffc7a789bfec2b75ffa606ae02f3fe482e8dff60abfff00d3a5a577fe3bff008f4f137fd856ebff004c0d5c05e7fc905d1bfec157ff00fa74b4a003e267fc943f893ff60ab4ff00d1b635cff8bffe67ff00fb1ae2ff00dbeae83e267fc943f893ff0060ab4ffd1b635cff008bff00e67fff00b1ae2ffdbea00e83c43ff25abc27ff0061593ff4ef7547887fe439e13ffb27f27fe915d51e21ff0092d5e13ffb0ac9ff00a77baa3c43ff0021cf09ff00d93f93ff0048aea800f10ffc873c27ff0064fe4ffd22baadff001f7fc921f0effd8a89ff00a51a6d607887fe439e13ff00b27f27fe915d56ff008fbfe490f877fec544ff00d28d36800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-35948504', '3434473992003', 'PEPSI 50CL', 'SOFT DRINKS', 'N/A', 'Active', 57, '100.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd77f67ff24f359ffb27f61ffa2aeeb80b3ff920bacffd82ac3ff4e9775dfd9ffc93cd67fec9fd87fe8abba003c3dff203f167fd9408ff00f4b6d68bcff92f5a37fd856fff00f4d7694787bfe407e2cffb2811ff00e96dad179ff25eb46ffb0adfff00e9aed28039ff008b9ff24860ff00b1aefbff004a2f2b0355ff0090e6abff00615f15ff00e91256ff00c5cff924307fd8d77dff00a5179581aaff00c87355ff00b0af8aff00f4892803d7fc5fff0033ff00fd8a917fedf57907887fe4b5784ffec2b27fe9deeabd7fc5ff00f33fff00d8a917fedf57907887fe4b5784ff00ec2b27fe9deea8037fc4dff257b50ffb1afc3dff00a4f2d6078eff00e49e789bfeca05d7fe8a6adff137fc95ed43fec6bf0f7fe93cb581e3bff9279e26ff00b28175ff00a29a800f10ff00c96af09ffd8564ff00d3bdd5179ff241746ffb055fff00e9d2d28f10ff00c96af09ffd8564ff00d3bdd5179ff241746ffb055fff00e9d2d28037fc4dff00248750ff00b153c3dffa512d741f1e7fe40727fd82a7ff00d2dd3eb9ff00137fc921d43fec54f0f7fe944b5d07c79ff901c9ff0060a9ff00f4b74fa00e7fe2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775dfd9ffc93cd67fec9fd87fe8abbae02cffe482eb3ff0060ab0ffd3a5dd77f67ff0024f359ff00b27f61ff00a2aee800f0f7fc80fc59ff0065023ffd2db5a2f3fe4bd68dff00615bff00fd35da51e1eff901f8b3feca047ffa5b6b45e7fc97ad1bfec2b7ff00fa6bb4a00e7fe2e7fc92183fec6bbeff00d28bcac0d57fe439aaff00d857c57ffa4495bff173fe490c1ff635df7fe945e5606abff21cd57fec2be2bffd224a00f5ff0017ff00ccff00ff0062a45ffb7d5e41e21ff92d5e13ff00b0ac9ffa77baaf5ff17ffccfff00f62a45ff00b7d5e41e21ff0092d5e13ffb0ac9ff00a77baa00dff137fc95ed43fec6bf0f7fe93cb581e3bff9279e26ff00b28175ff00a29ab7fc4dff00257b50ff00b1afc3dffa4f2d6078effe49e789bfeca05d7fe8a6a003c43ff25abc27ff0061593ff4ef7545e7fc905d1bfec157ff00fa74b4a3c43ff25abc27ff0061593ff4ef7545e7fc905d1bfec157ff00fa74b4a00dff00137fc921d43fec54f0f7fe944b5d07c79ff901c9ff0060a9ff00f4b74fae7fc4dff248750ffb153c3dff00a512d741f1e7fe40727fd82a7ffd2dd3e8039ff8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd77f67ff0024f359ff00b27f61ff00a2aeeb80b3ff00920bacff00d82ac3ff004e9775dfd9ff00c93cd67fec9fd87fe8abba003c3dff00203f167fd9408fff004b6d68bcff0092f5a37fd856ff00ff004d7694787bfe407e2cff00b2811ffe96dad179ff0025eb46ff00b0adff00fe9aed28039ff8b9ff0024860ffb1aefbff4a2f2b0355ff90e6abff615f15ffe91256ffc5cff00924307fd8d77dffa5179581aaffc87355ffb0af8afff004892803d7fc5ff00f33fff00d8a917fedf57907887fe4b5784ff00ec2b27fe9deeabd7fc5fff0033ff00fd8a917fedf57907887fe4b5784ffec2b27fe9deea8037fc4dff00257b50ff00b1afc3dffa4f2d6078effe49e789bfeca05d7fe8a6adff00137fc95ed43fec6bf0f7fe93cb581e3bff009279e26ffb28175ffa29a800f10ffc96af09ff00d8564ffd3bdd5179ff00241746ff00b055ff00fe9d2d28f10ffc96af09ff00d8564ffd3bdd5179ff00241746ff00b055ff00fe9d2d28037fc4dff248750ffb153c3dff00a512d741f1e7fe40727fd82a7ffd2dd3eb9ff137fc921d43fec54f0f7fe944b5d07c79ff00901c9ff60a9fff004b74fa00e7fe2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775dfd9ff00c93cd67fec9fd87fe8abbae02cff00e482eb3ff60ab0ff00d3a5dd77f67ff24f359ffb27f61ffa2aee800f0f7fc80fc59ff65023ff00d2db5a2f3fe4bd68dff615bfff00d35da51e1eff00901f8b3feca047ff00a5b6b45e7fc97ad1bfec2b7fff00a6bb4a00e7fe2e7fc92183fec6bbeffd28bcac0d57fe439aaffd857c57ff00a4495bff00173fe490c1ff00635df7fe945e5606abff0021cd57fec2be2bff00d224a00f5ff17ffccfff00f62a45ff00b7d5e41e21ff0092d5e13ffb0ac9ff00a77baaf5ff0017ff00ccff00ff0062a45ffb7d5e41e21ff92d5e13ff00b0ac9ffa77baa00dff00137fc95ed43fec6bf0f7fe93cb581e3bff009279e26ffb28175ffa29ab7fc4dff257b50ffb1afc3dff00a4f2d6078eff00e49e789bfeca05d7fe8a6a003c43ff0025abc27ff61593ff004ef7545e7fc905d1bfec157fff00a74b4a3c43ff0025abc27ff61593ff004ef7545e7fc905d1bfec157fff00a74b4a00dff137fc921d43fec54f0f7fe944b5d07c79ff00901c9ff60a9fff004b74fae7fc4dff00248750ff00b153c3dffa512d741f1e7fe40727fd82a7ff00d2dd3e8039ff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-42232199', '5735339393839', 'LUX SOAP', 'OTHERS', 'N/A', 'Active', 49, '120.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd1e21ff0090e784ff00ec9fc9ff00a4575459ff00c905d67fec1561ff00a74bba3c43ff0021cf09ff00d93f93ff0048aea803bff0affc93c5ff00b0ae81ff00a2b4da3e267fc93cf893ff00615b4ffd156347857fe49e2ffd85740ffd15a6d1f133fe49e7c49ffb0ada7fe8ab1a0013fe407f11ff00ec157bff00a5baa50fff00203f871ff60ab2ff00d2dd2e84ff00901fc47ffb055eff00e96ea943ff00c80fe1c7fd82acbff4b74ba00e03c77ff25ebc4dff0060abaffd35b56ffc5cff00924307fd8d77dffa5179581e3bff0092f5e26ffb055d7fe9adab7fe2e7fc92183fec6bbeff00d28bca00e03c7dff0022c7877fe01ffa6dd36bbff8dbff0022c6bbff00635dbffe9b63ae03c7dff22c7877fe01ff00a6dd36bbff008dbff22c6bbff635dbff00e9b63a00c0f10ffc96af09ff00d8564ffd3bdd51e0dff922b73ff615d4bff4d1351e21ff0092d5e13ffb0ac9ff00a77baa3c1bff002456e7fec2ba97fe9a26a003c43ff21cf09ffd93f93ff48aeab9fd6bfe467f8a5ff6dfff004e505741e21ff90e784ffec9fc9ffa45755cfeb5ff00233fc52ffb6fff00a7282803bff8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd1e21ff90e784ffec9fc9ffa4575459ffc905d67fec1561ffa74bba3c43ff21cf09ffd93f93ff48aea803bff000aff00c93c5ffb0ae81ffa2b4da3e267fc93cf893ff615b4ff00d156347857fe49e2ff00d85740ff00d15a6d1f133fe49e7c49ff00b0ada7fe8ab1a0013fe407f11ffec157bffa5baa50ff00f203f871ff0060ab2ffd2dd2e84ff901fc47ff00b055effe96ea943ffc80fe1c7fd82acbff004b74ba00e03c77ff0025ebc4dff60abaff00d35b56ff00c5cff924307fd8d77dff00a5179581e3bff92f5e26ff00b055d7fe9adab7fe2e7fc92183fec6bbeffd28bca00e03c7dff22c7877fe01ff00a6dd36bbff008dbff22c6bbff635dbff00e9b63ae03c7dff0022c7877fe01ffa6dd36bbff8dbff0022c6bbff00635dbffe9b63a00c0f10ff00c96af09ffd8564ff00d3bdd51e0dff00922b73ff00615d4bff004d1351e21ff92d5e13ff00b0ac9ffa77baa3c1bff2456e7fec2ba97fe9a26a003c43ff0021cf09ff00d93f93ff0048aeab9fd6bfe467f8a5ff006dff00f4e505741e21ff0090e784ff00ec9fc9ff00a45755cfeb5ff233fc52ff00b6ff00fa7282803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd1e21ff0090e784ff00ec9fc9ff00a4575459ff00c905d67fec1561ff00a74bba3c43ff0021cf09ff00d93f93ff0048aea803bff0affc93c5ff00b0ae81ff00a2b4da3e267fc93cf893ff00615b4ffd156347857fe49e2ffd85740ffd15a6d1f133fe49e7c49ffb0ada7fe8ab1a0013fe407f11ff00ec157bff00a5baa50fff00203f871ff60ab2ff00d2dd2e84ff00901fc47ffb055eff00e96ea943ff00c80fe1c7fd82acbff4b74ba00e03c77ff25ebc4dff0060abaffd35b56ffc5cff00924307fd8d77dffa5179581e3bff0092f5e26ffb055d7fe9adab7fe2e7fc92183fec6bbeff00d28bca00e03c7dff0022c7877fe01ffa6dd36bbff8dbff0022c6bbff00635dbffe9b63ae03c7dff22c7877fe01ff00a6dd36bbff008dbff22c6bbff635dbff00e9b63a00c0f10ffc96af09ff00d8564ffd3bdd51e0dff922b73ff615d4bff4d1351e21ff0092d5e13ffb0ac9ff00a77baa3c1bff002456e7fec2ba97fe9a26a003c43ff21cf09ffd93f93ff48aeab9fd6bfe467f8a5ff6dfff004e505741e21ff90e784ffec9fc9ffa45755cfeb5ff00233fc52ffb6fff00a7282803bff8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd1e21ff90e784ffec9fc9ffa4575459ffc905d67fec1561ffa74bba3c43ff21cf09ffd93f93ff48aea803bff000aff00c93c5ffb0ae81ffa2b4da3e267fc93cf893ff615b4ff00d156347857fe49e2ff00d85740ff00d15a6d1f133fe49e7c49ff00b0ada7fe8ab1a0013fe407f11ffec157bffa5baa50ff00f203f871ff0060ab2ffd2dd2e84ff901fc47ff00b055effe96ea943ffc80fe1c7fd82acbff004b74ba00e03c77ff0025ebc4dff60abaff00d35b56ff00c5cff924307fd8d77dff00a5179581e3bff92f5e26ff00b055d7fe9adab7fe2e7fc92183fec6bbeffd28bca00e03c7dff22c7877fe01ff00a6dd36bbff008dbff22c6bbff635dbff00e9b63ae03c7dff0022c7877fe01ffa6dd36bbff8dbff0022c6bbff00635dbffe9b63a00c0f10ff00c96af09ffd8564ff00d3bdd51e0dff00922b73ff00615d4bff004d1351e21ff92d5e13ff00b0ac9ffa77baa3c1bff2456e7fec2ba97fe9a26a003c43ff0021cf09ff00d93f93ff0048aeab9fd6bfe467f8a5ff006dff00f4e505741e21ff0090e784ff00ec9fc9ff00a45755cfeb5ff233fc52ff00b6ff00fa7282803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-59447964', '2972991882911', 'COCA COLA 50CL', 'SOFT DRINKS', 'N/A', 'Active', 120, '70.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fe8bff257be16ff00d8a907fe93cf58167ff241759ffb05587fe9d2eeb7f45ff92bdf0b7fec5483ff0049e7a003c21ff2247803fedaff00e9eac6ba0d1bfe49e7c5bffb0aeb1ffa28573fe10ff9123c01ff006d7ff4f5635d068dff0024f3e2dffd85758ffd14280380f157fc9436ff00b056bfff00a3752a3e0f7fc873c13ff615d5ff00f48a0a3c55ff00250dbfec15afff00e8dd4a8f83dff21cf04ffd85757ffd2282800f06ff00c915b9ff00b0aea5ff00a689ab7fe36ffc8b1aeffd8d76ff00fa6d8eb03c1bff002456e7fec2ba97fe9a26adff008dbff22c6bbff635dbff00e9b63a00e03fe677ff00b953ff0070b4789bfe458d43fee5effd36cb47fcceff00f72a7fee168f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd56fe8bff00257be16ffd8a907fe93cf581e21ff92d5e13ff00b0ac9ffa77baadfd17fe4af7c2dffb1520ff00d279e80380d17fe467f85bff006c3ff4e53d1a4ffc921d4ffedf3ff4a34aa345ff00919fe16ffdb0ff00d394f4693ff248753ffb7cff00d28d2a803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd6fe8bff257be16ff00d8a907fe93cf58167ff241759ffb05587fe9d2eeb7f45ff92bdf0b7fec5483ff0049e7a003c21ff2247803fedaff00e9eac6ba0d1bfe49e7c5bffb0aeb1ffa28573fe10ff9123c01ff006d7ff4f5635d068dff0024f3e2dffd85758ffd14280380f157fc9436ff00b056bfff00a3752a3e0f7fc873c13ff615d5ff00f48a0a3c55ff00250dbfec15afff00e8dd4a8f83dff21cf04ffd85757ffd2282800f06ff00c915b9ff00b0aea5ff00a689ab7fe36ffc8b1aeffd8d76ff00fa6d8eb03c1bff002456e7fec2ba97fe9a26adff008dbff22c6bbff635dbff00e9b63a00e03fe677ff00b953ff0070b4789bfe458d43fee5effd36cb47fcceff00f72a7fee168f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd56fe8bff00257be16ffd8a907fe93cf581e21ff92d5e13ff00b0ac9ffa77baadfd17fe4af7c2dffb1520ff00d279e80380d17fe467f85bff006c3ff4e53d1a4ffc921d4ffedf3ff4a34aa345ff00919fe16ffdb0ff00d394f4693ff248753ffb7cff00d28d2a803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd6fe8bff257be16ff00d8a907fe93cf58167ff241759ffb05587fe9d2eeb7f45ff92bdf0b7fec5483ff0049e7a003c21ff2247803fedaff00e9eac6ba0d1bfe49e7c5bffb0aeb1ffa28573fe10ff9123c01ff006d7ff4f5635d068dff0024f3e2dffd85758ffd14280380f157fc9436ff00b056bfff00a3752a3e0f7fc873c13ff615d5ff00f48a0a3c55ff00250dbfec15afff00e8dd4a8f83dff21cf04ffd85757ffd2282800f06ff00c915b9ff00b0aea5ff00a689ab7fe36ffc8b1aeffd8d76ff00fa6d8eb03c1bff002456e7fec2ba97fe9a26adff008dbff22c6bbff635dbff00e9b63a00e03fe677ff00b953ff0070b4789bfe458d43fee5effd36cb47fcceff00f72a7fee168f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd56fe8bff00257be16ffd8a907fe93cf581e21ff92d5e13ff00b0ac9ffa77baadfd17fe4af7c2dffb1520ff00d279e80380d17fe467f85bff006c3ff4e53d1a4ffc921d4ffedf3ff4a34aa345ff00919fe16ffdb0ff00d394f4693ff248753ffb7cff00d28d2a803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803d02cff00e482eb3ff60ab0ff00d3a5dd6fe8bff257be16ff00d8a907fe93cf58167ff241759ffb05587fe9d2eeb7f45ff92bdf0b7fec5483ff0049e7a003c21ff2247803fedaff00e9eac6ba0d1bfe49e7c5bffb0aeb1ffa28573fe10ff9123c01ff006d7ff4f5635d068dff0024f3e2dffd85758ffd14280380f157fc9436ff00b056bfff00a3752a3e0f7fc873c13ff615d5ff00f48a0a3c55ff00250dbfec15afff00e8dd4a8f83dff21cf04ffd85757ffd2282800f06ff00c915b9ff00b0aea5ff00a689ab7fe36ffc8b1aeffd8d76ff00fa6d8eb03c1bff002456e7fec2ba97fe9a26adff008dbff22c6bbff635dbff00e9b63a00e03fe677ff00b953ff0070b4789bfe458d43fee5effd36cb47fcceff00f72a7fee168f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd56fe8bff00257be16ffd8a907fe93cf581e21ff92d5e13ff00b0ac9ffa77baadfd17fe4af7c2dffb1520ff00d279e80380d17fe467f85bff006c3ff4e53d1a4ffc921d4ffedf3ff4a34aa345ff00919fe16ffdb0ff00d394f4693ff248753ffb7cff00d28d2a803bff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-65948223', '2922728229918', 'BLACK SOAP', 'OTHERS', 'N/A', 'Active', 41, '400.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fe8bff257be16ff00d8a907fe93cf58167ff241759ffb05587fe9d2eeb7f45ff92bdf0b7fec5483ff0049e7a00c0bcff920ba37fd82afff00f4e9695bfa8ffc9c2f88ff00ee15ff00a57a7d605e7fc905d1bfec157fff00a74b4adfd47fe4e17c47ff0070affd2bd3e803a08bfe4a1f80bfec2be24ffd1b2d1e25ff0090e78e7fec15ab7fe91699445ff250fc05ff00615f127fe8d968f12ffc873c73ff0060ad5bff0048b4ca00e03c77ff0025ebc4dff60abaff00d35b56ff00c3ff00f9a3bff71aff00d9ab03c77ff25ebc4dff0060abaffd35b56ffc3fff009a3bff0071affd9a80380ff99dff00ee54ff00dc2d1e26ff00916350ff00b97bff004db2d1ff0033bffdca9ffb85a3c4dff22c6a1ff72f7fe9b65a00e83c43ff0025abc27ff61593ff004ef7547c37ff009279ae7fd82b5dff00d156147887fe4b5784ff00ec2b27fe9deea8f86fff0024f35cff00b056bbff00a2ac2800f891ff0024f343ff00b05685ff00a2afeb7fe36ffc8cfaeffd8a96ff00fa728eb03e247fc93cd0ff00ec15a17fe8abfadff8dbff00233ebbff0062a5bffe9ca3a003e2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775bfa2ffc95ef85bff62a41ff00a4f3d6059ffc905d67fec1561ffa74bbadfd17fe4af7c2dffb1520ff00d279e80302f3fe482e8dff0060abff00fd3a5a56fea3ff00270be23ffb857fe95e9f58179ff241746ffb055fff00e9d2d2b7f51ff9385f11ff00dc2bff004af4fa00e822ff009287e02ffb0af893ff0046cb47897fe439e39ffb056adffa45a65117fc943f017fd857c49ffa365a3c4bff0021cf1cff00d82b56ff00d22d3280380f1dff00c97af137fd82aebff4d6d5bff0ff00fe68effdc6bff66ac0f1dffc97af137fd82aebff004d6d5bff000fff00e68eff00dc6bff0066a00e03fe677ffb953ff70b4789bfe458d43fee5eff00d36cb47fccefff0072a7fee168f137fc8b1a87fdcbdffa6d96803a0f10ff00c96af09ffd8564ff00d3bdd51f0dff00e49e6b9ff60ad77ff455851e21ff0092d5e13ffb0ac9ff00a77baa3e1bff00c93cd73fec15aeff00e8ab0a003e247fc93cd0ff00ec15a17fe8abfadff8dbff00233ebbff0062a5bffe9ca3ac0f891ff24f343ffb05685ffa2afeb7fe36ff00c8cfaeff00d8a96fff00a728e800f8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6fe8bff00257be16ffd8a907fe93cf58167ff00241759ff00b05587fe9d2eeb7f45ff0092bdf0b7fec5483ff49e7a00c0bcff00920ba37fd82aff00ff004e9695bfa8ff00c9c2f88ffee15ffa57a7d605e7fc905d1bfec157ff00fa74b4adfd47fe4e17c47ff70aff00d2bd3e803a08bfe4a1f80bfec2be24ff00d1b2d1e25ff90e78e7fec15ab7fe91699445ff00250fc05ff615f127fe8d968f12ff00c873c73ff60ad5bff48b4ca00e03c77ff25ebc4dff0060abaffd35b56ffc3fff009a3bff0071affd9ab03c77ff0025ebc4dff60abaff00d35b56ff00c3ff00f9a3bff71aff00d9a80380ff0099dffee54ffdc2d1e26ff916350ffb97bff4db2d1ff33bff00dca9ff00b85a3c4dff0022c6a1ff0072f7fe9b65a00e83c43ff25abc27ff0061593ff4ef7547c37ff9279ae7fd82b5dffd156147887fe4b5784ffec2b27fe9deea8f86ff00f24f35cffb056bbffa2ac2800f891ff24f343ffb05685ffa2afeb7fe36ff00c8cfaeff00d8a96fff00a728eb03e247fc93cd0ffec15a17fe8abfadff008dbff233ebbff62a5bff00e9ca3a003e2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775bfa2ff00c95ef85bff0062a41ffa4f3d6059ff00c905d67fec1561ff00a74bbadfd17fe4af7c2dff00b1520ffd279e80302f3fe482e8dff60abfff00d3a5a56fea3ff270be23ff00b857fe95e9f58179ff00241746ff00b055ff00fe9d2d2b7f51ff009385f11ffdc2bff4af4fa00e822ff9287e02ff00b0af893ff46cb47897fe439e39ff00b056adff00a45a65117fc943f017fd857c49ff00a365a3c4bff21cf1cffd82b56ffd22d3280380f1dffc97af137fd82aebff004d6d5bff000fff00e68eff00dc6bff0066ac0f1dff00c97af137fd82aebff4d6d5bff0ff00fe68effdc6bff66a00e03fe677ff00b953ff0070b4789bfe458d43fee5effd36cb47fcceff00f72a7fee168f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd51f0dffe49e6b9ff0060ad77ff00455851e21ff92d5e13ff00b0ac9ffa77baa3e1bffc93cd73fec15aeffe8ab0a003e247fc93cd0ffec15a17fe8abfadff008dbff233ebbff62a5bff00e9ca3ac0f891ff0024f343ff00b05685ff00a2afeb7fe36ffc8cfaeffd8a96ff00fa728e800f8b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-74565216', '4252542432564', 'CORN FLAKES', 'OTHERS', 'N/A', 'In-Active', 50, '0.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f2b02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f280303c3dff0026bde2cffb0ac7ff00a15ad6ff0086ff00e6ba7fdbcffedd560787bfe4d7bc59ff006158ff00f42b5adff0dffcd74ffb79ff00dbaa00c04ff90e7c47ff00b0adeffe916a95bfe24ff9a17ff6edff00b6b5809ff21cf88fff00615bdffd22d52b7fc49ff342ff00eddbff006d6800ff00e755478b7fe458f875ff0062a6a7ff00a6d5a3ff009d551e2dff009163e1d7fd8a9a9ffe9b56800f847ff257a7ff00b152c7ff0049eceb80f137fc8b1a87fdcbdffa6d96bbff00847ff257a7ff00b152c7ff0049eceb80f137fc8b1a87fdcbdffa6d96803a0f10ff00c96af09ffd8564ff00d3bdd56ff867fe490e9fff0062a7887ff4a22ac0f10ffc96af09ff00d8564ffd3bdd56ff00867fe490e9ff00f62a7887ff004a22a00c0f06ff00c80ee7fec9fea5ff00a5b35179ff00241746ff00b055ff00fe9d2d28f06ffc80ee7fec9fea5ffa5b35179ff241746ffb055fff00e9d2d28037fe2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775bf7bff0034f7fee58ffdbcac0b3ff920bacffd82ac3ff4e9775bf7bff34f7fee58ff00dbca00c0f0f7fc9af78b3fec2b1ffe856b5bfe1bff009ae9ff006f3ffb75581e1eff00935ef167fd8563ff00d0ad6b7fc37ff35d3fede7ff006ea803013fe439f11ffec2b7bffa45aa56ff00893fe685ff00dbb7fedad6027fc873e23ffd856f7ff48b54adff00127fcd0bff00b76ffdb5a003ff009d551e2dff009163e1d7fd8a9a9ffe9b568ffe755478b7fe458f875ff62a6a7ffa6d5a003e11ff00c95e9ffec54b1ffd27b3ae03c4dff22c6a1ff72f7fe9b65aeffe11ff00c95e9ffec54b1ffd27b3ae03c4dff22c6a1ff72f7fe9b65a00e83c43ff0025abc27ff61593ff004ef755bfe19ff9243a7ffd8a9e21ff00d288ab03c43ff25abc27ff0061593ff4ef755bfe19ff009243a7ff00d8a9e21ffd288a80303c1bff00203b9ffb27fa97fe96cd45e7fc905d1bfec157ff00fa74b4a3c1bff203b9ff00b27fa97fe96cd45e7fc905d1bfec157fff00a74b4a00dff8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f2b02cff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f280303c3dff26bde2cff00b0ac7ffa15ad6ff86ffe6ba7fdbcff00edd560787bfe4d7bc59ff6158fff0042b5adff000dff00cd74ff00b79ffdbaa00c04ff0090e7c47ffb0adeff00e916a95bfe24ff009a17ff006edffb6b5809ff0021cf88ff00f615bdff00d22d52b7fc49ff00342ffeddbff6d6800ffe755478b7fe458f875ff62a6a7ffa6d5a3ff9d551e2dff9163e1d7fd8a9a9ff00e9b56800f847ff00257a7ffb152c7ff49eceb80f137fc8b1a87fdcbdff00a6d96bbff847ff00257a7ffb152c7ff49eceb80f137fc8b1a87fdcbdff00a6d96803a0f10ffc96af09ff00d8564ffd3bdd56ff00867fe490e9ff00f62a7887ff004a22ac0f10ff00c96af09ffd8564ff00d3bdd56ff867fe490e9fff0062a7887ff4a22a00c0f06ffc80ee7fec9fea5ffa5b35179ff241746ffb055fff00e9d2d28f06ff00c80ee7fec9fea5ff00a5b35179ff00241746ff00b055ff00fe9d2d28037fe2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775bf7bff34f7fee58ff00dbcac0b3ff00920bacff00d82ac3ff004e9775bf7bff0034f7fee58ffdbca00c0f0f7fc9af78b3fec2b1ff00e856b5bfe1bff9ae9ff6f3ff00b75581e1eff935ef167fd8563ffd0ad6b7fc37ff0035d3fede7ff6ea803013fe439f11ff00ec2b7bff00a45aa56ff893fe685ffdbb7fedad6027fc873e23ff00d856f7ff0048b54adff127fcd0bffb76ff00db5a003ff9d551e2dff9163e1d7fd8a9a9ff00e9b568ff00e755478b7fe458f875ff0062a6a7ff00a6d5a003e11ffc95e9ff00ec54b1ff00d27b3ae03c4dff0022c6a1ff0072f7fe9b65aeff00e11ffc95e9ff00ec54b1ff00d27b3ae03c4dff0022c6a1ff0072f7fe9b65a00e83c43ff25abc27ff0061593ff4ef755bfe19ff009243a7ff00d8a9e21ffd288ab03c43ff0025abc27ff61593ff004ef755bfe19ff9243a7ffd8a9e21ff00d288a80303c1bff203b9ff00b27fa97fe96cd45e7fc905d1bfec157fff00a74b4a3c1bff00203b9ffb27fa97fe96cd45e7fc905d1bfec157ff00fa74b4a00dff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9);
INSERT INTO `tblproduct` (`code`, `barcode`, `pname`, `category`, `description`, `status`, `quantity`, `price`, `picture`) VALUES
('P-85812424', '2326172628928', 'SONAWAP WATER', 'OTHERS', 'N/A', 'In-Active', 50, '0.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd1e21ff0090e784ff00ec9fc9ff00a4575459ff00c905d67fec1561ff00a74bba3c43ff0021cf09ff00d93f93ff0048aea8039fd47fe663ff00b1534aff00dc7d77fe26ff009243a87fd8a9e1effd2896b80d47fe663ffb1534affdc7d77fe26ff9243a87fd8a9e1eff00d2896800f16ffc8cff000ebfec6bd4ff00f4e4b58179ff00250f46ff00b2817fff00a36d2b7fc5bff233fc3aff00b1af53ff00d392d605e7fc943d1bfeca05ff00fe8db4a00dff001b7fcc23fee6effdaf58117fc93cf017fd82bc49ff00a2a5adff001b7fcc23fee6effdaf58117fc93cf017fd82bc49ff00a2a5a00dff008aff00f3387fdb4ffdc35607887fe4d7bc27ff0061593ff42baadff8afff003387fdb4ff00dc35607887fe4d7bc27ff61593ff0042baa003c43ff25abc27ff0061593ff4ef7547c37ff9279ae7fd82b5dffd156147887fe4b5784ffec2b27fe9deea8f86ff00f24f35cffb056bbffa2ac28037fc4dff00248750ff00b153c3dffa512d741f1e7fe40727fd82a7ff00d2dd3eb9ff00137fc921d43fec54f0f7fe944b5d07c79ff901c9ff0060a9ff00f4b74fa00e7fe2e7fc95e83fec54beff00d27bcaf20f1dff00c943f137fd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3bff9287e26ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e97747887fe439e13ffb27f27fe915d5167ff241759ffb05587fe9d2ee8f10ff00c873c27ff64fe4ff00d22baa00e7f51ff998ff00ec54d2bff71f5dff0089bfe490ea1ff62a787bff004a25ae0351ff00998ffec54d2bff0071f5dff89bfe490ea1ff0062a787bff4a25a003c5bff00233fc3affb1af53ffd392d605e7fc943d1bfeca05fff00e8db4adff16ffc8cff000ebfec6bd4ff00f4e4b58179ff00250f46ff00b2817fff00a36d28037fc6dff308ff00b9bbff006bd6045ff24f3c05ff0060af127fe8a96b7fc6dff308ff00b9bbff006bd6045ff24f3c05ff0060af127fe8a968037fe2bffcce1ff6d3ff0070d581e21ff935ef09ff00d8564ffd0aeab7fe2bff00cce1ff006d3ff70d581e21ff00935ef09ffd8564ff00d0aea800f10ffc96af09ff00d8564ffd3bdd51f0dffe49e6b9ff0060ad77ff00455851e21ff92d5e13ff00b0ac9ffa77baa3e1bffc93cd73fec15aeffe8ab0a00dff00137fc921d43fec54f0f7fe944b5d07c79ff901c9ff0060a9ff00f4b74fae7fc4dff248750ffb153c3dff00a512d741f1e7fe40727fd82a7ffd2dd3e8039ff8b9ff00257a0ffb152fbff49ef2bc83c77ff250fc4dff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078effe4a1f89bfec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd1e21ff90e784ffec9fc9ffa4575459ffc905d67fec1561ffa74bba3c43ff21cf09ffd93f93ff48aea8039fd47fe663ffb1534affdc7d77fe26ff9243a87fd8a9e1eff00d2896b80d47fe663ff00b1534aff00dc7d77fe26ff009243a87fd8a9e1effd2896800f16ff00c8cff0ebfec6bd4fff004e4b58179ff250f46ffb2817ff00fa36d2b7fc5bff00233fc3affb1af53ffd392d605e7fc943d1bfeca05fff00e8db4a00dff1b7fcc23fee6eff00daf58117fc93cf017fd82bc49ffa2a5adff1b7fcc23fee6eff00daf58117fc93cf017fd82bc49ffa2a5a00dff8afff003387fdb4ff00dc35607887fe4d7bc27ff61593ff0042baadff008aff00f3387fdb4ffdc35607887fe4d7bc27ff0061593ff42baa003c43ff0025abc27ff61593ff004ef7547c37ff009279ae7fd82b5dff00d156147887fe4b5784ff00ec2b27fe9deea8f86fff0024f35cff00b056bbff00a2ac28037fc4dff248750ffb153c3dff00a512d741f1e7fe40727fd82a7ffd2dd3eb9ff137fc921d43fec54f0f7fe944b5d07c79ff00901c9ff60a9fff004b74fa00e7fe2e7fc95e83fec54beffd27bcaf20f1dffc943f137fd856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3bff009287e26ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e97747887fe439e13ff00b27f27fe915d5167ff00241759ff00b05587fe9d2ee8f10ffc873c27ff0064fe4ffd22baa00e7f51ff00998ffec54d2bff0071f5dff89bfe490ea1ff0062a787bff4a25ae0351ff998ff00ec54d2bff71f5dff0089bfe490ea1ff62a787bff004a25a003c5bff233fc3aff00b1af53ff00d392d605e7fc943d1bfeca05ff00fe8db4adff0016ff00c8cff0ebfec6bd4fff004e4b58179ff250f46ffb2817ff00fa36d28037fc6dff00308ffb9bbff6bd6045ff0024f3c05ff60af127fe8a96b7fc6dff00308ffb9bbff6bd6045ff0024f3c05ff60af127fe8a968037fe2bff00cce1ff006d3ff70d581e21ff00935ef09ffd8564ff00d0aeab7fe2bffcce1ff6d3ff0070d581e21ff935ef09ff00d8564ffd0aea800f10ff00c96af09ffd8564ff00d3bdd51f0dff00e49e6b9ff60ad77ff455851e21ff0092d5e13ffb0ac9ff00a77baa3e1bff00c93cd73fec15aeff00e8ab0a00dff137fc921d43fec54f0f7fe944b5d07c79ff00901c9ff60a9fff004b74fae7fc4dff00248750ff00b153c3dffa512d741f1e7fe40727fd82a7ff00d2dd3e8039ff008b9ff257a0ff00b152fbff0049ef2bc83c77ff00250fc4dff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078eff00e4a1f89bfec2b75ffa35a803ffd9),
('P-98695671', '4256252272662', '40 LEAVES NOTEBOOK', 'EXERCISE BOOK', 'N/A', 'Active', 80, '50.00', 0xffd8ffe000104a46494600010101006000600000ffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc0001108003c007b03012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00e7ecff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f2b02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f280303c3dff0026bfe2cffb0ac7ff00a15ad6ff008fbfe490f877fec544ff00d28d36b03c3dff0026bfe2cffb0ac7ff00a15ad6ff008fbfe490f877fec544ff00d28d36800f097fc8cff117fec6bd33ff004e4d47c3ff00f9a3dff71aff00d9a8f097fc8cff00117fec6bd33ff4e4d47c3fff009a3dff0071affd9a8039ff0086ff00f24f75cffb056bbffa2ac2bd83c25ff257be227fdc33ff0049dabc7fe1bffc93dd73fec15aeffe8ab0af60f097fc95ef889ff70cff00d276a00e7fc09ff1e9e19ffb0adaff00e9816b80f8c3ff0021bf1b7fd85748ff00d229ebbff027fc7a7867fec2b6bffa605ae03e30ff00c86fc6dff615d23ff48a7a003c43ff0025abc27ff61593ff004ef75458ff00c813e0affd856e7ff4b63a3c43ff0025abc27ff61593ff004ef75458ff00c813e0affd856e7ff4b63a00dff17ffc891e3fff00b65ffa7abeae83e3c7fc8124ff00b054ff00fa5ba7d73fe2ff00f9123c7fff006cbff4f57d5d07c78ff90249ff0060a9ff00f4b74fa00e7fe2e7fc95e83fec54beff00d27bcaf20f1e7fc943f12ffd856ebff46b57affc5cff0092bd07fd8a97dffa4f795e41e3cff9287e25ff00b0add7fe8d6a00f40b3ff920bacffd82ac3ff4e9775bf7bff34f7fee58ff00dbcac0b3ff00920bacff00d82ac3ff004e9775bf7bff0034f7fee58ffdbca00c0f0f7fc9aff8b3fec2b1ff00e856b5bfe3eff9243e1dff00b1513ff4a34dac0f0f7fc9aff8b3fec2b1ff00e856b5bfe3eff9243e1dff00b1513ff4a34da003c25ff233fc45ff00b1af4cff00d39351f0ff00fe68f7fdc6bff66a3c25ff00233fc45ffb1af4cffd39351f0fff00e68f7fdc6bff0066a00e7fe1bffc93dd73fec15aeffe8ab0af60f097fc95ef889ff70cff00d276af1ff86fff0024f75cff00b056bbff00a2ac2bd83c25ff00257be227fdc33ff49da8039ff027fc7a7867fec2b6bffa605ae03e30ff00c86fc6dff615d23ff48a7aeffc09ff001e9e19ff00b0adaffe9816b80f8c3ff21bf1b7fd85748ffd229e800f10ff00c96af09ffd8564ff00d3bdd5163ff204f82bff00615b9ffd2d8e8f10ff00c96af09ffd8564ff00d3bdd5163ff204f82bff00615b9ffd2d8e8037fc5fff0022478fff00ed97fe9eafaba0f8f1ff0020493fec153ffe96e9f5cff8bffe448f1fff00db2ffd3d5f5741f1e3fe40927fd82a7ffd2dd3e8039ff8b9ff00257a0ffb152fbff49ef2bc83c79ff250fc4bff00615baffd1ad5ebff00173fe4af41ff0062a5f7fe93de579078f3fe4a1f897fec2b75ff00a35a803d02cffe482eb3ff0060ab0ffd3a5dd6fdeffcd3dffb963ff6f2b02cff00e482eb3ff60ab0ff00d3a5dd6fdeff00cd3dff00b963ff006f280303c3dff26bfe2cff00b0ac7ffa15ad6ff8fbfe490f877fec544ffd28d36b03c3dff26bfe2cff00b0ac7ffa15ad6ff8fbfe490f877fec544ffd28d36800f097fc8cff00117fec6bd33ff4e4d47c3fff009a3dff0071affd9a8f097fc8cff117fec6bd33ff004e4d47c3ff00f9a3dff71aff00d9a8039ff86fff0024f75cff00b056bbff00a2ac2bd83c25ff00257be227fdc33ff49dabc7fe1bff00c93dd73fec15aeff00e8ab0af60f097fc95ef889ff0070cffd276a00e7fc09ff001e9e19ff00b0adaffe9816b80f8c3ff21bf1b7fd85748ffd229ebbff00027fc7a7867fec2b6bff00a605ae03e30ffc86fc6dff00615d23ff0048a7a003c43ff25abc27ff0061593ff4ef75458ffc813e0aff00d856e7ff004b63a3c43ff25abc27ff0061593ff4ef75458ffc813e0aff00d856e7ff004b63a00dff0017ff00c891e3ff00fb65ff00a7abeae83e3c7fc8124ffb054fff00a5ba7d73fe2fff009123c7ff00f6cbff004f57d5d07c78ff0090249ff60a9fff004b74fa00e7fe2e7fc95e83fec54beffd27bcaf20f1e7fc943f12ff00d856ebff0046b57aff00c5cff92bd07fd8a97dff00a4f795e41e3cff009287e25ffb0add7fe8d6a00f40b3ff00920bacff00d82ac3ff004e9775bf7bff0034f7fee58ffdbcac0b3ff920bacffd82ac3ff4e9775bf7bff34f7fee58ff00dbca00c0f0f7fc9aff008b3fec2b1ffe856b5bfe3eff009243e1dffb1513ff004a34dac0f0f7fc9aff008b3fec2b1ffe856b5bfe3eff009243e1dffb1513ff004a34da003c25ff00233fc45ffb1af4cffd39351f0fff00e68f7fdc6bff0066a3c25ff233fc45ff00b1af4cff00d39351f0ff00fe68f7fdc6bff66a00e7fe1bff00c93dd73fec15aeff00e8ab0af60f097fc95ef889ff0070cffd276af1ff0086ff00f24f75cffb056bbffa2ac2bd83c25ff257be227fdc33ff0049da8039ff00027fc7a7867fec2b6bff00a605ae03e30ffc86fc6dff00615d23ff0048a7aeff00c09ff1e9e19ffb0adaff00e9816b80f8c3ff0021bf1b7fd85748ff00d229e800f10ffc96af09ff00d8564ffd3bdd5163ff00204f82bff615b9ff00d2d8e8f10ffc96af09ff00d8564ffd3bdd5163ff00204f82bff615b9ff00d2d8e8037fc5ff00f22478ff00fed97fe9eafaba0f8f1ff20493fec153ff00e96e9f5cff008bff00e448f1ff00fdb2ff00d3d5f5741f1e3fe40927fd82a7ff00d2dd3e8039ff008b9ff257a0ff00b152fbff0049ef2bc83c79ff00250fc4bff615baff00d1ad5ebff173fe4af41ff62a5f7fe93de579078f3fe4a1f897fec2b75ffa35a803ffd9);

-- --------------------------------------------------------

--
-- Table structure for table `tblsettings`
--

CREATE TABLE IF NOT EXISTS `tblsettings` (
  `name` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `address` varchar(500) NOT NULL,
  `motto` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblsettings`
--

INSERT INTO `tblsettings` (`name`, `phone`, `email`, `address`, `motto`) VALUES
('Alhaja Hamzat Mini Mart', '08090949669', 'afolabi8120@gmail.com', 'Sango Rd, Ibadan, Oyo State.', 'cheaper than expected');

-- --------------------------------------------------------

--
-- Table structure for table `tblstockadjustment`
--

CREATE TABLE IF NOT EXISTS `tblstockadjustment` (
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(400) NOT NULL,
  `reason` varchar(50) NOT NULL,
  `action` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `adjustedby` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstockadjustment`
--

INSERT INTO `tblstockadjustment` (`code`, `name`, `description`, `reason`, `action`, `quantity`, `adjustedby`, `date`, `time`) VALUES
('P-98695671', '40 LEAVES NOTEBOOK', 'N/A', 'we need it to be 50 in stock', 'ADD TO STOCK', 10, 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', '7:35 PM'),
('P-42232199', 'LUX SOAP', 'N/A', 'it should be 50 in stock not 30', 'ADD TO STOCK', 20, 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', '7:37 PM'),
('P-0655108', 'PEAK MILK REFILL', 'N/A', 'it should be 30 in stock', 'ADD TO STOCK', 5, 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', '7:41 PM'),
('P-98695671', '40 LEAVES NOTEBOOK', 'N/A', 'Added New Stock to the old ones', 'ADD TO STOCK', 12, 'AFOLABI TEMIDAYO TIMOTHY', '9/18/2021', '10:35 PM'),
('P-65948223', 'BLACK SOAP', 'N/A', 'Removed 5 from the 95 on the shelf, so that it wil', 'REMOVE FROM STOCK', 5, 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', '9:28 PM'),
('P-98695671', '40 LEAVES NOTEBOOK', 'N/A', 'removed 5 from the 95', 'REMOVE FROM STOCK', 5, 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', '9:29 PM'),
('P-25252720', 'BAKING SODA', 'N/A', 'Test', 'ADD TO STOCK', 8, 'AFOLABI TEMIDAYO TIMOTHY', '2/27/2022', '8:20 PM'),
('P-98695671', '40 LEAVES NOTEBOOK', 'N/A', 'Rest', 'ADD TO STOCK', 6, 'AFOLABI TEMIDAYO TIMOTHY', '3/1/2022', '9:03 PM');

-- --------------------------------------------------------

--
-- Table structure for table `tblstockhistory`
--

CREATE TABLE IF NOT EXISTS `tblstockhistory` (
  `referenceno` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `pname` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `supplier_id` varchar(50) NOT NULL,
  `receivedby` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstockhistory`
--

INSERT INTO `tblstockhistory` (`referenceno`, `code`, `pname`, `price`, `quantity`, `total`, `supplier_name`, `supplier_id`, `receivedby`, `date`, `status`) VALUES
('REF202191175252', 'P-59447964', 'COCA COLA 50CL', '50.00', 70, '4700.00', 'COCA COLA', 'SUP-381549', 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', 'COMPLETED'),
('REF202191175252', 'P-42232199', 'LUX SOAP', '100.00', 30, '3000.00', 'COCA COLA', 'SUP-381549', 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', 'COMPLETED'),
('REF202191175252', 'P-0655108', 'PEAK MILK REFILL', '450.00', 25, '11250.00', 'COCA COLA', 'SUP-381549', 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', 'COMPLETED'),
('REF202191175252', 'P-12415797', 'PEAK MILK TIN', '200.00', 30, '6000.00', 'COCA COLA', 'SUP-381549', 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', 'COMPLETED'),
('REF202191175252', 'P-98695671', '40 LEAVES NOTEBOOK', '50.00', 40, '2000.00', 'COCA COLA', 'SUP-381549', 'AFOLABI TEMIDAYO TIMOTHY', '9/11/2021', 'COMPLETED'),
('REF202191850453', 'P-65948223', 'BLACK SOAP', '400.00', 20, '8000.00', 'LIZZY CONCEPT', 'SUP-2120900', 'AFOLABI TEMIDAYO TIMOTHY', '9/18/2021', 'COMPLETED'),
('REF202191850453', 'P-25252720', 'BAKING SODA', '150.00', 35, '5250.00', 'LIZZY CONCEPT', 'SUP-2120900', 'AFOLABI TEMIDAYO TIMOTHY', '9/18/2021', 'COMPLETED'),
('REF202111221447', 'P-106870491', 'TEST PRODUCT', '100.00', 40, '4000.00', 'EMERALD VENTURES', 'SUP-1726021', 'AFOLABI TEMIDAYO TIMOTHY', '11/2/2021', 'COMPLETED'),
('REF202211359576', 'P-42232199', 'LUX SOAP', '100.00', 30, '3000.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-35948504', 'PEPSI 50CL', '80.00', 50, '4000.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-98695671', '40 LEAVES NOTEBOOK', '40.00', 50, '2000.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-65948223', 'BLACK SOAP', '250.00', 15, '3750.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-59447964', 'COCA COLA 50CL', '50.00', 60, '3000.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-0655108', 'PEAK MILK REFILL', '400.00', 20, '8000.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-12415797', 'PEAK MILK TIN', '230.00', 20, '4600.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED'),
('REF202211359576', 'P-25252720', 'BAKING SODA', '150.00', 15, '2250.00', 'SMILES VENTURES', 'SUP-0851828', 'AFOLABI TEMIDAYO TIMOTHY', '1/13/2022', 'COMPLETED');

-- --------------------------------------------------------

--
-- Table structure for table `tblstockhistory_payment`
--

CREATE TABLE IF NOT EXISTS `tblstockhistory_payment` (
  `referenceno` varchar(50) NOT NULL,
  `item_total` decimal(10,2) NOT NULL,
  `amountpaid` decimal(10,2) NOT NULL,
  `mchange` decimal(10,2) NOT NULL,
  `payment_status` varchar(50) NOT NULL,
  PRIMARY KEY (`referenceno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstockhistory_payment`
--

INSERT INTO `tblstockhistory_payment` (`referenceno`, `item_total`, `amountpaid`, `mchange`, `payment_status`) VALUES
('REF202111221447', '4000.00', '4000.00', '0.00', 'Paid'),
('REF202191175252', '26450.00', '27000.00', '550.00', 'Paid'),
('REF202191850453', '13250.00', '14000.00', '750.00', 'Paid'),
('REF202211359576', '30600.00', '31000.00', '400.00', 'Paid');

-- --------------------------------------------------------

--
-- Table structure for table `tblsupplier`
--

CREATE TABLE IF NOT EXISTS `tblsupplier` (
  `id` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `address` varchar(500) NOT NULL,
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblsupplier`
--

INSERT INTO `tblsupplier` (`id`, `name`, `phone`, `email`, `address`, `status`) VALUES
('SUP-0851828', 'SMILES VENTURES', '08090949669', 'afolabi8120@gmail.com', 'N/A', 'Active'),
('SUP-1726021', 'EMERALD VENTURES', '09098595885', 'emerald2000@gmail.com', 'N/A', 'Active'),
('SUP-2120900', 'LIZZY CONCEPT', '08090949678', 'lizzy@gmail.com', 'N/A', 'Active'),
('SUP-381549', 'COCA COLA', '07049269626', 'coke@gmail.com', 'N/A', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE IF NOT EXISTS `tbluser` (
  `username` varchar(50) NOT NULL,
  `fullname` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `usertype` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `status` varchar(15) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`username`, `fullname`, `password`, `usertype`, `email`, `status`) VALUES
('Afolabi', 'Afolabi Temidayo Timothy', '12345', 'Administrator', 'afolabi8120@gmail.com', 'Active'),
('Cashier1', 'Albert Faith Segun', '12345', 'User', 'albert@gmail.com', 'Active'),
('Pelumi', 'Oladiti Pelumi Micheal', '12345', 'User', 'm.oladiti1@gmail.com', 'Active'),
('Temidayo', 'Afolabi Olaonipekun Ayokunle', '12345', 'User', 'timo@gmail.com', 'Active');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
