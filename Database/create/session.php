<?php
	include '../database_connection.php';
	include '../check_session.php';
	
	if(!checkSession()){
		die("haha nope");
	}
	
	$PlayerID = $_GET["pid"];
	//http://localhost/Database/read/player_complete.php?pid=5
        
	$query = "INSERT INTO `session` (`Session_ID`, `Date`, `ServerSessionID`, `Player_PlayerID`) ";
	$query = $query . "VALUES (NULL, '" . date("d-m-y H:i:s") . "', NULL, '$PlayerID')";
    $result = mysqli_query($conn,$query);
    
    $query = "SELECT * FROM `session` WHERE `Player_PlayerID` = $PlayerID ORDER BY `Session_ID` DESC LIMIT 1";
    $result = mysqli_query($conn,$query);
    
    $seed = "hquPrlxhx0R3QEfGkxKkNGlSmQT7lg2zqYpn5f7wjh50nvfLhl";
    $SessionID;
    if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			$SessionID = md5($row['Date'] . $PlayerID . $seed . $row['Session_ID']);
            $session = $row['Session_ID'];
            $query = "UPDATE `session` SET `ServerSessionID` = ";
            $query = $query . "'$SessionID' WHERE `session`.`Session_ID` = " . $session;
		}
	}
    $result = mysqli_query($conn,$query);
    echo $SessionID;    
?>