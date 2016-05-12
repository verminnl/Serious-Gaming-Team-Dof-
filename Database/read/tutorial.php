<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$PlayerID = $_GET["pid"];
	
	//http://localhost/Database/read/skill.php?sid=5
	$query = "SELECT * FROM `session` WHERE `Player_PlayerID` = '$PlayerID'";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) == 1){
		echo "true";
	}
?>