<?php
	include '/database_connection.php';
		
	$name = $_GET['Name'];
	$type = $_GET['Type'];
	$cost = $_GET['Cost'];
	$url_information = "NULL, '";
	$counter = 0;
	foreach ($_GET as $value) {
		if($counter == 0){
			$url_information = $url_information + "$value";
			$counter = 1;
		}
		else {
			$url_information = $url_information + "','$value'";
		}
	}
	
	$sql = "INSERT INTO `items` (`ID`, `Name`, `Type`, `Cost`) VALUES (NULL,'$name','$type','$cost')";
	$sql = "INSERT INTO `items` (`ID`, `Name`, `Type`, `Cost`) VALUES ($url_information)";
	$result = mysqli_query($conn,$sql);
?>