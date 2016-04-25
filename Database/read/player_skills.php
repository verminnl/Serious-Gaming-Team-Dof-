<?php
	include '../database_connection.php';
	
	$PlayerID = $_GET["pid"];
	
	//http://localhost/Database/read/skill.php?sid=1
	
	$query = "SELECT * FROM `player_has_skill` WHERE `Player_PlayerID` = '$PlayerID'";
	$result = mysqli_query($conn,$query);
	
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			foreach($row as $key => $value){
				if($key == "Skill_Skill_ID"){
					$query = "SELECT * FROM `skill` WHERE `Skill_ID` = '$value'";
					$result = mysqli_query($conn,$query);
					if(mysqli_num_rows($result) > 0){
						while($row = mysqli_fetch_assoc($result)){
							foreach($row as $key => $value){
								echo $key . ":" .$value . "|";
							}
						}
					}
				}
			}
		}
	}
?>