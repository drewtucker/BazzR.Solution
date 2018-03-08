-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 08, 2018 at 07:18 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bazzr_test`
--
CREATE DATABASE IF NOT EXISTS `bazzr_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bazzr_test`;

-- --------------------------------------------------------

--
-- Table structure for table `buy_offer`
--

CREATE TABLE `buy_offer` (
  `id` int(11) NOT NULL,
  `offerer_id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `sell_transaction_id` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `offered_game_id` int(11) NOT NULL,
  `comment` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE `games` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `platform` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `photopath` varchar(255) NOT NULL,
  `metascore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- --------------------------------------------------------

--
-- Table structure for table `games_tags`
--

CREATE TABLE `games_tags` (
  `id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `tag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `games_tags`
--

INSERT INTO `games_tags` (`id`, `game_id`, `tag_id`) VALUES
(1, 7, 1),
(2, 7, 2),
(3, 8, 3),
(4, 15, 4),
(5, 15, 5),
(6, 16, 6),
(7, 23, 7),
(8, 23, 8),
(9, 24, 9),
(10, 31, 10),
(11, 31, 11),
(12, 32, 12),
(13, 39, 17),
(14, 39, 18),
(15, 40, 19),
(16, 47, 24),
(17, 47, 25),
(18, 48, 26),
(19, 55, 31),
(20, 55, 32),
(21, 56, 33),
(22, 63, 38),
(23, 63, 39),
(24, 64, 40),
(25, 71, 45),
(26, 71, 46),
(27, 72, 47),
(28, 79, 52),
(29, 79, 53),
(30, 80, 54),
(31, 87, 59),
(32, 87, 60),
(33, 88, 61),
(34, 95, 66),
(35, 95, 67),
(36, 96, 68),
(37, 103, 73),
(38, 103, 74),
(39, 104, 75),
(40, 111, 80),
(41, 111, 81),
(42, 112, 82),
(43, 119, 87),
(44, 119, 88),
(45, 120, 89),
(46, 127, 94),
(47, 127, 95),
(48, 128, 96),
(49, 135, 101),
(50, 135, 102),
(51, 136, 103),
(52, 143, 108),
(53, 143, 109),
(54, 144, 110),
(55, 151, 115),
(56, 151, 116),
(57, 152, 117),
(58, 159, 122),
(59, 159, 123),
(60, 160, 124),
(61, 167, 129),
(62, 167, 130),
(63, 168, 131),
(64, 186, 136),
(65, 186, 137),
(66, 187, 138),
(67, 205, 147),
(68, 205, 148),
(69, 206, 149),
(70, 213, 154),
(71, 213, 155),
(72, 214, 156),
(73, 221, 161),
(74, 221, 162),
(75, 222, 163),
(76, 229, 168),
(77, 229, 169),
(78, 230, 170),
(79, 237, 175),
(80, 237, 176),
(81, 238, 177),
(82, 245, 182),
(83, 245, 183),
(84, 246, 184),
(85, 253, 189),
(86, 253, 190),
(87, 254, 191),
(88, 261, 196),
(89, 261, 197),
(90, 262, 198),
(91, 269, 203),
(92, 269, 204),
(93, 270, 205),
(94, 277, 210),
(95, 277, 211),
(96, 278, 212),
(97, 285, 217),
(98, 285, 218),
(99, 286, 219),
(100, 293, 224),
(101, 293, 225),
(102, 294, 226);

-- --------------------------------------------------------

--
-- Table structure for table `sell_transaction`
--

CREATE TABLE `sell_transaction` (
  `id` int(11) NOT NULL,
  `user_seller` int(11) NOT NULL,
  `user_buyer` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `status` varchar(255) NOT NULL,
  `photo_of_traded_game` varchar(255) NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tags`
--

CREATE TABLE `tags` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `filter_by_true_false` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `lastname` varchar(255) CHARACTER SET utf8 COLLATE utf8_estonian_ci NOT NULL,
  `date_registered` datetime NOT NULL,
  `rep` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `buy_offer`
--
ALTER TABLE `buy_offer`
  ADD PRIMARY KEY (`id`),
  ADD KEY `offer_id` (`offerer_id`,`game_id`),
  ADD KEY `game_id` (`game_id`);

--
-- Indexes for table `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `games_tags`
--
ALTER TABLE `games_tags`
  ADD PRIMARY KEY (`id`),
  ADD KEY `game_id` (`game_id`,`tag_id`),
  ADD KEY `tag_id` (`tag_id`);

--
-- Indexes for table `sell_transaction`
--
ALTER TABLE `sell_transaction`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_seller` (`user_seller`,`user_buyer`),
  ADD KEY `user_buyer` (`user_buyer`),
  ADD KEY `game_id` (`game_id`);

--
-- Indexes for table `tags`
--
ALTER TABLE `tags`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`email`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `buy_offer`
--
ALTER TABLE `buy_offer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=147;
--
-- AUTO_INCREMENT for table `games`
--
ALTER TABLE `games`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=295;
--
-- AUTO_INCREMENT for table `games_tags`
--
ALTER TABLE `games_tags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;
--
-- AUTO_INCREMENT for table `sell_transaction`
--
ALTER TABLE `sell_transaction`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=145;
--
-- AUTO_INCREMENT for table `tags`
--
ALTER TABLE `tags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=231;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
