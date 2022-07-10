-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3308:3308
-- Generation Time: Jul 10, 2022 at 04:17 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.0.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbhotelmanagement`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomer`
--

CREATE TABLE `tblcustomer` (
  `CustomerID` int(11) NOT NULL,
  `Fullname` varchar(60) NOT NULL,
  `NoOfRooms` int(60) NOT NULL,
  `Phone` varchar(11) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `CheckInDate` varchar(45) NOT NULL,
  `CheckOutDate` varchar(45) NOT NULL,
  `RoomReference` varchar(11) NOT NULL,
  `Address` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tblcustomer`
--

INSERT INTO `tblcustomer` (`CustomerID`, `Fullname`, `NoOfRooms`, `Phone`, `Email`, `CheckInDate`, `CheckOutDate`, `RoomReference`, `Address`) VALUES
(1, 'Aomine Daiki', 3, '09236532148', 'aomine@gmail.com', '6/14/2022', '6/14/2022', 'Standard', 'Tokyo, Japan'),
(3, 'Kise Ryota', 6, '2147483647', 'kiseryota@gmai.com', '6/14/2022', '6/16/2022', 'Deluxe', 'Shibuya'),
(4, 'Testsuya Kuroko', 5, '2147483647', 'tetsuya@gmail.com', '6/14/2022', '6/16/2022', 'Suite', 'Nagasaki, Japan'),
(5, 'Aaron Bujatin', 2, '2', 'aaronbujatin@gmail.com', '6/14/2022', '6/16/2022', 'Deluxe', 'Rodriguez'),
(6, 'Amethys Queue', 6, '2147483647', 'ame@gmail.com', '6/14/2022', '6/17/2022', 'Suite', 'Quezon'),
(7, 'Allynere Stack', 7, '2147483647', 'allynere@gmail.com', '6/14/2022', '6/19/2022', 'Suite', 'California'),
(8, 'Reign Set', 3, '910886381', 'reign@gmail.com', '6/14/2022', '6/15/2022', 'Standard', 'Rizal'),
(9, 'Spongebob Squarepants', 4, '2147483647', 'spongebob@gmail.com', '6/14/2022', '6/16/2022', 'Suite', 'Bikini Bottom'),
(10, 'Patrick Star', 8, '09108863810', 'patrickstar@gmail.com', '6/14/2022', '6/22/2022', 'Standard', 'Bikini Bottom'),
(11, 'Bea Alonzo', 6, '09105631247', 'beaalonzo@gmail.com', '6/14/2022', '6/23/2022', 'Deluxe', 'Quezon City');

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomertwo`
--

CREATE TABLE `tblcustomertwo` (
  `CustomerID` int(11) NOT NULL,
  `Firstname` varchar(45) NOT NULL,
  `Lastname` varchar(45) NOT NULL,
  `NoOfRooms` int(10) NOT NULL,
  `Phone` varchar(11) NOT NULL,
  `CheckinDate` varchar(10) NOT NULL,
  `CheckoutDate` varchar(10) NOT NULL,
  `RoomReference` varchar(10) NOT NULL,
  `Address` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tblcustomertwo`
--

INSERT INTO `tblcustomertwo` (`CustomerID`, `Firstname`, `Lastname`, `NoOfRooms`, `Phone`, `CheckinDate`, `CheckoutDate`, `RoomReference`, `Address`) VALUES
(1, 'Bea ', 'Alonzo', 2, '09108863810', '7/9/2022', '7/12/2022', 'Deluxe', 'California'),
(3, 'Bianca', 'Santos', 3, '09136584563', '7/9/2022', '7/19/2022', 'Deluxe', 'San Francisco');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblcustomer`
--
ALTER TABLE `tblcustomer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `tblcustomertwo`
--
ALTER TABLE `tblcustomertwo`
  ADD PRIMARY KEY (`CustomerID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblcustomer`
--
ALTER TABLE `tblcustomer`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `tblcustomertwo`
--
ALTER TABLE `tblcustomertwo`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
