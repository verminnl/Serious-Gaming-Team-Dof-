<?php
	include '../database_connection.php';
	
	$PlayerID = $_GET["pid"];
    
	$query = "SELECT `Player_PlayerID1` FROM `foundplayer` WHERE `Player_PlayerID` = $PlayerID";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
            echo "(". $row['Player_PlayerID1'] .")";
		}
	}
?>