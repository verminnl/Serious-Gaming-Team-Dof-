<?php
	include '../database_connection.php';
	
	$PlayerID = $_GET["pid"];
	
	//http://localhost/Database/read/player_skills.php?pid=1
	
	$query = "SELECT skill.Skill_ID, skill.Name
				FROM skill
				INNER JOIN player_has_skill
				ON skill.Skill_ID = player_has_skill.Skill_Skill_ID
				WHERE player_has_skill.Player_PlayerID = '$PlayerID'";
	$result = mysqli_query($conn,$query);
	
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo "(". $row['Name'] .")";
		}
	}
?>