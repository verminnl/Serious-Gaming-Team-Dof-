<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$Firstname = $_GET["fn"];
	$Lastname = $_GET["ln"];
	$Job = $_GET["jo"];
	$Character = $_GET["ch"];
	$Username = $_GET["us"];
	$Password = $_GET["pw"];
	$Element = $_GET["el"];
	$Skill1 = $_GET["s1"];
	$Skill2 = $_GET["s2"];
	$Skill3 = $_GET["s3"];
	$Tutorial = 1;
	
	//http://localhost/Database/create/player.php?fn=voornaam&ln=achternaam&jo=functie&ch=character&us=username&pw=password&el=element
	print_r($_GET);
	
	$query = "INSERT INTO `player` (`PlayerID`, `FirstName`, `LastName`, `Job`,`SpawnPoint`, ";
	$query = $query . "`Character`, `Username`, `Password`, `Element`, `FoundPlayers`, `Room`, `Skill1`, `Skill2`, `Skill3`) ";
	$query = $query . "VALUES (NULL, '$Firstname', '$Lastname', '$Job', NULL,";
	$query = $query . "'$Character', '$Username', '$Password', '$Element', NULL, NULL, '$Skill1', '$Skill2', '$Skill3', $Tutorial)";
	echo $query;
	$result = mysqli_query($conn,$query);
?>