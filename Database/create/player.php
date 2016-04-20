<?php
	include '../database_connection.php';
	$Firstname = $_GET["fn"];
	$Lastname = $_GET["ln"];
	$Job = $_GET["jo"];
	$Character = $_GET["ch"];
	$Username = $_GET["us"];
	$Password = $_GET["pw"];
	$Element = $_GET["el"];
	
	//http://localhost/Database/create/player.php?fn=voornaam&ln=achternaam&jo=functie&ch=character&us=username&pw=password&el=element
	print_r($_GET);
	
	$query = "INSERT INTO `player` (`PlayerID`, `FirstName`, `LastName`, `Job`,`SpawnPoint`, ";
	$query = $query . "`Character`, `Username`, `Password`, `Element`, `FoundPlayers`, `Domain`) ";
	$query = $query . "VALUES (NULL, '$Firstname', '$Lastname', '$Job', NULL,";
	$query = $query . "'$Character', '$Username', '$Password', '$Element', NULL, NULL)";
	echo $query;
	$result = mysqli_query($conn,$query);
?>