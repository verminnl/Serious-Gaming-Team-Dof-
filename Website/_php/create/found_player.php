<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	$PlayerID = $_GET["pid"];
	$FoundPlayerID = $_GET["fid"];

	$query = "INSERT INTO `foundplayer` (`idFoundPlayer`, `Player_PlayerID`, `Player_PlayerID1`)";
	$query = $query . "VALUES (NULL, '$PlayerID', '$FoundPlayerID')";
	echo $query;
	$result = mysqli_query($conn,$query);
?>