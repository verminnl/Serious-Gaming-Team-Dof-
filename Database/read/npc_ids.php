<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$PlayerID = $_GET["pid"];
	//http://localhost/Database/read/player_complete.php?pid=5
	$query = "SELECT `PlayerID` From `player` WHERE `PlayerID` != '$PlayerID'";
	$result = mysqli_query($conn,$query);
	
	while($row = mysqli_fetch_assoc($result)){
		$rows[] += $row['PlayerID'];
	}
	$data['intList'] = $rows;
	echo json_encode($data);
?>