<?php
	include '../database_connection.php';
	
	$PlayerID = $_GET["pid"];
	echo $_SERVER["PATH"];
	//http://localhost/Database/read/player_complete.php?pid=5
	$query = "SELECT * From `player` WHERE `PlayerID` = '$PlayerID'";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			foreach($row as $key => $value){
				echo $key . ":" .$value . "|";
			}
		}
	}
?>