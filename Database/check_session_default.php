<?php
	//include '../database_connection.php';
    function checkSession(){
		if(isset($_GET["sesid"])){
			
			$sessionID = $_GET["sesid"];
			if($sessionID == "Uy5ytsn2rMSMX8fD"){
				return true;
			}
		}
		return false;
	}
?>