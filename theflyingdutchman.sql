-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 23, 2022 at 11:01 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `theflyingdutchman`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `getApiLimit` (IN `id` INT)   SELECT userID, apiLimit FROM users WHERE userID = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getShip` (IN `id` INT)   SELECT * FROM shipstatic WHERE shipID = id$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getSpoofData` (IN `spoofid` INT)   SELECT * FROM requests WHERE requestID = spoofid$$

DELIMITER ;

-- --------------------------------------------------------

CREATE USER IF NOT EXISTS 'fdlocaladmin'@'localhost' IDENTIFIED BY 'fdlocaladmin';
GRANT ALL PRIVILEGES ON theflyingdutchman.* TO 'fdlocaladmin'@'localhost' WITH GRANT OPTION;

CREATE USER IF NOT EXISTS 'fdapiuser'@'localhost' IDENTIFIED BY 'fdapiuser';
GRANT CREATE, UPDATE, SELECT ON theflyingdutchman.* TO 'fdapiuser'@'localhost';

--
-- Table structure for table `requests`
--

CREATE TABLE `requests` (
  `requestID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `shipID` int(11) NOT NULL,
  `longitude` float NOT NULL,
  `latitude` float NOT NULL,
  `timestamp` int(11) NOT NULL,
  `cog` int(11) NOT NULL,
  `sog` int(11) NOT NULL,
  `heading` int(11) NOT NULL,
  `rot` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  `currentTime` timestamp(6) NOT NULL DEFAULT current_timestamp(6),
CONSTRAINT CHK_NavData CHECK (longitude > -181 AND longitude <= 181 AND latitude > -91 AND latitude <= 91 AND timestamp >= 0 AND timestamp < 64)
	
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `requests`
--

INSERT INTO `requests` (`requestID`, `userID`, `shipID`, `longitude`, `latitude`, `timestamp`, `cog`, `sog`, `heading`, `rot`, `status`, `currentTime`) VALUES
(19, 9, 12, -10, -36, 33, 90, 29, 149, 103, 15, '2022-06-07 10:24:02.652717'),
(25, 11, 10, 119, -28, 23, 105, 49, 43, 127, 1, '2022-06-07 10:24:02.654162'),
(36, 10, 21, 109, 80, 30, 9, 24, 149, 104, 3, '2022-06-07 10:24:02.656788'),
(42, 8, 37, -133, -40, 15, 27, 30, 215, 28, 3, '2022-06-07 10:24:02.658214');

-- --------------------------------------------------------

--
-- Stand-in structure for view `shiphistory`
-- (See below for the actual view)
--
CREATE TABLE `shiphistory` (
`nameOfShip` varchar(20)
,`mmsi` int(11)
,`longitude` float
,`latitude` float
);

-- --------------------------------------------------------

--
-- Table structure for table `shipstatic`
--

CREATE TABLE `shipstatic` (
  `shipID` int(11) NOT NULL,
  `mmsi` int(11) NOT NULL,
  `nameOfShip` varchar(20) NOT NULL,
  `typeOfShip` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE INDEX indexmmsi
	ON shipstatic (mmsi);
--
-- Dumping data for table `shipstatic`
--

INSERT INTO `shipstatic` (`shipID`, `mmsi`, `nameOfShip`, `typeOfShip`) VALUES
(2, 701647225, 'Edwin', 41),
(3, 201513229, 'Ricardo', 40),
(5, 356138275, 'Connie', 39),
(6, 361767108, 'Martin', 26),
(7, 310611892, 'Adam', 89),
(8, 212136953, 'Michael', 28),
(9, 720915808, 'Karl', 97),
(10, 631279268, 'Aaron', 58),
(11, 312393650, 'David', 99),
(12, 436717300, 'Tiffany', 87),
(13, 565422919, 'Derek', 15),
(14, 262420729, 'Maria', 79),
(15, 332817912, 'Jeremy', 73),
(16, 661639126, 'Kenneth', 40),
(17, 374100974, 'Rebecca', 73),
(18, 219336104, 'Dustin', 15),
(19, 679283897, 'Carla', 14),
(20, 263825622, 'Darrell', 14),
(21, 477824967, 'Lucas', 13),
(22, 475956644, 'Jennifer', 80),
(23, 765559423, 'Patrick', 87),
(24, 249378573, 'Carol', 37),
(25, 765148280, 'William', 84),
(26, 273640243, 'Anthony', 56),
(27, 202640276, 'Cory', 71),
(28, 642264669, 'Jesus', 60),
(29, 725547935, 'Kristin', 83),
(30, 234291219, 'Miranda', 57),
(31, 314495971, 'Gregory', 66),
(32, 244505975, 'Sarah', 88),
(33, 679150591, 'Glenn', 35),
(34, 277623204, 'Diamond', 40),
(35, 254268493, 'Thomas', 58),
(36, 269726273, 'Kathleen', 30),
(37, 625205780, 'Tammie', 81),
(38, 266245403, 'Tyler', 63),
(39, 566522696, 'Wanda', 97),
(40, 334353680, 'Shannon', 63),
(41, 508697520, 'Matthew', 85),
(42, 557534455, 'Courtney', 38),
(43, 225177581, 'Meghan', 93),
(44, 301747909, 'Amanda', 13),
(45, 536738878, 'Robert', 22),
(46, 258828255, 'Tammy', 88),
(47, 508326786, 'Alan', 84),
(48, 512296427, 'Todd', 42),
(49, 663212343, 'John', 77),
(50, 657908745, 'Mariah', 86),
(51, 215403697, 'Sergio', 35),
(52, 333333333, 'Grand Jolly', 12),
(53, 12121, 'John', 4),
(56, 1, 'red', 2),
(57, 212, 'red', 1231);

--
-- Triggers `shipstatic`
--
DELIMITER $$
CREATE TRIGGER `validateRequest` AFTER DELETE ON `shipstatic` FOR EACH ROW DELETE FROM requests
 WHERE shipID NOT IN (SELECT s.shipID 
                        FROM shipstatic AS s)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userID` int(11) NOT NULL,
  `apiKey` varchar(50) NOT NULL,
  `apiLimit` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `apiKey`, `apiLimit`) VALUES
(2, 'FduRVG4WvL8UkNfotgVFamN792hzE0CwW0NvQNfmVaTf6zlsml', 701),
(4, 'rC0BxdfhKTE61lSBG6FeLIKhviJejUAZnYmKnyBMZgr7pOzoXt', 394),
(5, 'fl4b7qMzuoG1m0LcG1fKXKM5dxK0oa0PBMhFedu4OjfphXrcic', 604),
(7, 'xyQoZQo2rcaElTPuoTR5eyAAZi9dzoMuNCuSu72qBxqdvsY8BW', 975),
(8, 'oAJsoJwtHkU9uUrt9wgcOKUN47FJve2Ki2bgk0fVYJV0xCzj5e', 867),
(9, '87ryknFns0MtZJqd3zmyY4ts0W7PZbB0gL5KOQMqIbIMYh40JR', 970),
(10, 'sOHVHPgela6DY6ZiLTW5FfYjVEWcukBY204tcumje8iEE8wu8k', 606),
(11, 'av7YaGijhQo6kxIJ4LMSFjX4xxlZUGaHsytqypR7TSLAaktlaw', 591);

--
-- Triggers `users`
--
DELIMITER $$
CREATE TRIGGER `UpdateInfoIfDeleted` AFTER DELETE ON `users` FOR EACH ROW DELETE FROM requests
 WHERE userID NOT IN (SELECT u.userID 
                        FROM users AS u)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `userspooofhistory`
-- (See below for the actual view)
--
CREATE TABLE `userspooofhistory` (
`userID` int(11)
,`apiKey` varchar(50)
,`shipID` int(11)
,`longitude` float
,`latitude` float
,`currentTime` timestamp(6)
);

-- --------------------------------------------------------

--
-- Structure for view `shiphistory`
--
DROP TABLE IF EXISTS `shiphistory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `shiphistory`  AS SELECT `s`.`nameOfShip` AS `nameOfShip`, `s`.`mmsi` AS `mmsi`, `r`.`longitude` AS `longitude`, `r`.`latitude` AS `latitude` FROM (`shipstatic` `s` join `requests` `r` on(`s`.`shipID` = `r`.`shipID`))  ;

-- --------------------------------------------------------

--
-- Structure for view `userspooofhistory`
--
DROP TABLE IF EXISTS `userspooofhistory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `userspooofhistory`  AS SELECT `u`.`userID` AS `userID`, `u`.`apiKey` AS `apiKey`, `r`.`shipID` AS `shipID`, `r`.`longitude` AS `longitude`, `r`.`latitude` AS `latitude`, `r`.`currentTime` AS `currentTime` FROM (`users` `u` join `requests` `r` on(`u`.`userID` = `r`.`userID`))  ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`requestID`);

--
-- Indexes for table `shipstatic`
--
ALTER TABLE `shipstatic`
  ADD PRIMARY KEY (`shipID`),
  ADD UNIQUE KEY `mmsi` (`mmsi`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `apiKey` (`apiKey`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `requests`
--
ALTER TABLE `requests`
  MODIFY `requestID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT for table `shipstatic`
--
ALTER TABLE `shipstatic`
  MODIFY `shipID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
