<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$PlayerID = $_GET["pid"];
	//http://localhost/Database/read/player_complete.php?pid=5
	$query = "SELECT `PlayerID`,`FirstName`,`LastName`,`Job`,`SpawnPoint`,`Character`,`Element`,`Room` From `player` WHERE `PlayerID` != '$PlayerID'";
	$result = mysqli_query($conn,$query);
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo json_encode($row, JSON_NUMERIC_CHECK);
		}
	}
?>