<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$PlayerID = $_GET["pid"];
	$Spawn = $_GET["spawn"];
	$Tutorial = $_GET["tut"];
    //UPDATE `player` SET `SpawnPoint`='T1_55.93_-16.77' WHERE `PlayerID`=16
	
	$query = "UPDATE `player` SET `SpawnPoint`='$Spawn', `Tutorial` = $Tutorial WHERE `PlayerID` = $PlayerID";
	echo $query;
    $result = mysqli_query($conn,$query);
?>