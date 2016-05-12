<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$ID = NULL;
	$PlayerID = $_GET["pid"];
	$SkillID = $_GET["sid"];
	//http://localhost/Database/create/player_skill.php?pid=1&sid=2
	print_r($_GET);
	
	$query = "INSERT INTO `player_has_skill` (`Player_PlayerID`, `Skill_Skill_ID`) ";
	$query = $query . "VALUES (NULL, '$PlayerID', '$SkillID');";
	
	$result = mysqli_query($conn,$query);
?>