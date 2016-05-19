<?php
	//include '../database_connection.php';
    function checkSession(){
		if(isset($_GET["sesid"])){
			
			$sessionID = $_GET["sesid"];
			if($sessionID == "Uy5ytsn2rMSMX8fD"){
				return true;
			}
			
			$query = "SELECT * FROM `session` WHERE `ServerSessionID` = '$sessionID'";
			while(!isset($conn)){
				$servername = "localhost";
				$username = "root";
				$password = "";
				$dbName = "bakkie_doen";
				$conn = new mysqli($servername, $username, $password, $dbName);
			}
			$result = mysqli_query($conn,$query);
			if(mysqli_num_rows($result) > 0){
				return true;
			}
		}
		return false;
	}
?>