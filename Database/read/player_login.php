<?php
	include '../database_connection.php';
	
	$Username = $_GET["us"];
	$Password = $_GET["pw"];
	
	//http://localhost/Database/read/player_login.php?us=dodo&pw=dodo
	$query = "SELECT `PlayerID` From `player` WHERE `Username` = '$Username' AND `Password` = '$Password'";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) == 1){
		while($row = mysqli_fetch_assoc($result)){
			echo json_encode($row, JSON_NUMERIC_CHECK);
		}
	}
?>