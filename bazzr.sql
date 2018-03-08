-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 08, 2018 at 07:19 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bazzr`
--
CREATE DATABASE IF NOT EXISTS `bazzr` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bazzr`;

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
INSERT INTO `games` (`id`, `title`, `platform`, `description`, `photopath`, `metascore`) VALUES
(4, 'Grand Theft Auto III', 'Playstation 2', '', 'https://upload.wikimedia.org/wikipedia/en/b/be/GTA3boxcover.jpg', 97),
(5, 'Dark Souls', 'Playstation 3', '2011', 'https://upload.wikimedia.org/wikipedia/en/8/8d/Dark_Souls_Cover_Art.jpg', 89),
(6, 'Katamari Damacy', 'Playstation 2', '2004', 'https://upload.wikimedia.org/wikipedia/en/a/aa/KatamariDamacybox.jpg', 86),
(7, 'Dark Souls II', 'PC', '2014', 'https://upload.wikimedia.org/wikipedia/en/e/ed/Dark_Souls_II_cover.jpg', 94),
(8, 'Portal 2', 'PC', '2011', 'https://upload.wikimedia.org/wikipedia/en/f/f9/Portal2cover.jpg', 95),
(9, 'StarCraft', 'PC', '1998', 'https://upload.wikimedia.org/wikipedia/en/9/93/StarCraft_box_art.jpg', 88),
(10, 'Batman: Arkham City', 'Xbox 360', '2011', 'https://upload.wikimedia.org/wikipedia/en/0/00/Batman_Arkham_City_Game_Cover.jpg', 94),
(11, 'Goldeneye 007', 'Nintendo 64', '1997', 'https://upload.wikimedia.org/wikipedia/en/3/36/GoldenEye007box.jpg', 96),
(12, 'Grand Theft Auto IV', 'Playstation 3', '2008', 'https://upload.wikimedia.org/wikipedia/en/b/b7/Grand_Theft_Auto_IV_cover.jpg', 98),
(13, 'Perfect Dark', 'Nintendo 64', '2000', 'https://upload.wikimedia.org/wikipedia/en/3/32/Perfect_dark_box.jpg', 97),
(14, 'Parasite Eve', 'Playstation', '1998', 'https://upload.wikimedia.org/wikipedia/en/3/3f/Parasite_Eve_Coverart.png', 81),
(15, 'Tekken 3', 'Playstation', '1998', 'https://upload.wikimedia.org/wikipedia/en/f/f0/T3usposter.jpg', 96);


--
-- Table structure for table `games_tags`
--

CREATE TABLE `games_tags` (
  `id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `tag_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
