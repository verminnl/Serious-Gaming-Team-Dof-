<?php
	$servername = "https://www.db4free.net";
	$username = "bakkie_doen";
	$password = "bakkie";
	$dbName = "bakkie_doen";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Check Connection
	if(!$conn){
		die("Connection Failed." . mysqli_connect_error());
	}
?>