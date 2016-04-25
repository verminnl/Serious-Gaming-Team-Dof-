<?php
	$servername = "localhost";
	$username = "root";
	$password = "";
	$dbName = "bakkie_doen";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Check Connection
	if(!$conn){
		die("Connection Failed." . mysqli_connect_error());
	}	
?>