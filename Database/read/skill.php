<?php
	include '../database_connection.php';
	
	$SkillID = $_GET["sid"];
	
	//http://localhost/Database/read/skill.php?sid=5
	$query = "SELECT * FROM `skill` WHERE `Skill_ID` = '$SkillID'";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			foreach($row as $key => $value){
				echo $key . ":" .$value . "|";
			}
		}
	}
?>