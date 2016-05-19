<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$ID = NULL;
	$SkillName = $_GET["sk"];
	$SkillDescription = $_GET["sd"];
	//http://localhost/Database/create/player.php?sk=skillnaam&sd=skillbeschrijving
	print_r($_GET);
	
	$query = "INSERT INTO `skill` (`Skill_ID`, `Name`, `Description`) ";
	$query = $query . "VALUES (NULL, '$SkillName', '$SkillDescription');";
	
	$result = mysqli_query($conn,$query);
?>