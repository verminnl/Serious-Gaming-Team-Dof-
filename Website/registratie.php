<?php
if(isset($_POST["submit"])){
	
	$firstnameErr = "";
	$lastnameErr = "";
	$jobErr = "";
	$usernameErr = "";
	$passwordErr = "";
	$characterErr = "";
	$skill1Err = "";
	$skill2Err = "";
	$skill3Err = "";
	$roomErr = "";
	
	// Check if its between 4 and 40 characters
	$Firstname = filter_var($_POST["voornaam"],FILTER_SANITIZE_STRING);
	if(strlen($Firstname) < 4 || strlen($Firstname) > 40){
		$firstnameErr = "Voornaam is te kort of te lang.";
	}
	// Check if its between 4 and 40 characters
	$Lastname = filter_var($_POST["achternaam"],FILTER_SANITIZE_STRING);
	if(strlen($Lastname) < 4 || strlen($Lastname) > 40){
		$lastnameErr = "Achternaam is te kort of te lang.";
	}
	// Check if its between 4 and 40 characters
	$Job = filter_var($_POST["functie"],FILTER_SANITIZE_STRING);
	if(strlen($Job) < 4 || strlen($Job) > 40){
		$jobErr = "Functie is te kort of te lang.";
	}
	// Length check 7 or 8 chars
	$Username = filter_var($_POST["gebruikersnaam"],FILTER_SANITIZE_NUMBER_INT);
	if(strlen($Username) == 7 || strlen($Password) == 8){
		$usernameErr = "Gebruikersnaam te kort of te lang.";
	}
	// Length check 3 chars
	$Password = filter_var($_POST["wachtwoord"],FILTER_SANITIZE_NUMBER_INT);
	if(strlen($Password) != 3){
		$passwordErr = "Wachtwoord is niet lang genoeg.";
	}
	// Check if its between 4 and 40 characters
	$Skill1 = filter_var($_POST["talent1"],FILTER_SANITIZE_STRING);
	if(strlen($Skill1) < 4 || strlen($Skill1) > 40){
		$skill1Err = "Talent 1 is te kort of te lang.";
	}
	// Check if its between 4 and 40 characters
	$Skill2 = filter_var($_POST["talent2"],FILTER_SANITIZE_STRING);
	if (strlen($Skill2) < 4 || strlen($Skill2) > 40) {
        $skill2Err = "Talent 2 is te kort of te lang.";
    }
	// Check if its between 4 and 40 characters
	$Skill3 = filter_var($_POST["talent3"],FILTER_SANITIZE_STRING);
	if (strlen($Skill2) < 4 || strlen($Skill2) > 40){
        $skill3Err = "Talent 3 is te kort of te lang.";
    }
	// Check if its between 5 and 7 characters
	$Room = filter_var($_POST["kamernummer"],FILTER_SANITIZE_STRING);
	if (strlen($Room) < 5 || strlen($Room) > 7) {
        $roomErr = "Kamernummer is te kort of te lang.";
    }
	// Check if value is "man" or "woman"
	$Character = filter_var($_POST["karakter"],FILTER_SANITIZE_STRING);
	if ($Character != "man" || $Character != "vrouw") {
        $characterErr = "Het gekozen karakter heeft een foutieve waarde.";
    }
			
	$continue = true;
	if($firstnameErr != "" ||
		$lastnameErr != "" ||
		$jobErr != "" ||
		$usernameErr != "" ||
		$passwordErr != "" ||
		$characterErr != "" ||
		$skill1Err != "" ||
		$skill2Err != "" ||
		$skill3Err != "" ||
		$roomErr != "")
	{
		include 'database_connection.php';
		$query = "SELECT * FROM `player` WHERE `Username` = $Username";
		$result = mysqli_query($conn,$query);
		if(mysqli_num_rows($result) > 0){
			$usernameErr = "Deze gebruikersnaam is al in gebruik.";
		}
		else{
			$query = "INSERT INTO `player` (`PlayerID`, `FirstName`, `LastName`, `Job`,`SpawnPoint`, ";
			$query = $query . "`Character`, `Username`, `Password`, `Room`, `Skill1`, `Skill2`, `Skill3`, `Tutorial`) ";
			$query = $query . "VALUES (NULL, '$Firstname', '$Lastname', '$Job', '',";
			$query = $query . "'$Character', '$Username', '$Password', '$Room', '$Skill1', '$Skill2', '$Skill3', 1)";
			$result = mysqli_query($conn,$query);
			echo $query;
		}
	}	
}

function placeErrorBox($var){
	if($var != ""){
		echo "<p>" . $var . "</p>";
	}
	
}
	
?>
<html>
	<head>
		<link rel="stylesheet" type="text/css" href="_css/stijl.css">
		<link href='https://fonts.googleapis.com/css?family=Press+Start+2P' rel='stylesheet' type='text/css'>
		<link rel="shortcut icon" href="_img/flavicon.ico"/>
		<title>Bakkie Doen Serious Gaming</title>
	</head>
	<body>
		<div id="header">
		</div>

		<div id="section">
		<form id="form" action="" method="post">
			<fieldset class="fieldset_top">
				<h2>Registratie</h2>
				<img class="karakter_man"/>
				<img id="logo" class="logo"/>
				<img class="karakter_vrouw"/>
			</fieldset>
			
			<fieldset class="fieldset_middle">
				<legend> Persoonlijke informatie </legend>
				<?php placeErrorBox($firstnameErr); ?> 
				<label>Voornaam</label><input value=<?php echo '"' . $Firstname . '"';?> type="text" placeholder="Jan" name="voornaam" maxlength="45" required /> <br/>
				<?php placeErrorBox($lastnameErr); ?> 
				<label>Achternaam</label><input value=<?php echo '"' . $Lastname . '"';?> type="text" placeholder="Janssen" name="achternaam" maxlength="45" required/> <br/>
				<?php placeErrorBox($jobErr); ?> 
				<label>Functie</label><input value=<?php echo '"' . $Job . '"';?> type="text" placeholder="Huismeester" name="functie" maxlength="45" required/> <br/>
				<?php placeErrorBox($roomErr); ?> 
				<label>Kamernummer</label><input value=<?php echo '"' . $Room . '"';?> type="text" placeholder="T0.09" name="kamernummer" maxlength="7" required/> <br/>
				<?php placeErrorBox($skill1Err); ?> 
				<label>Talent 1</label><input value=<?php echo '"' . $Skill1 . '"';?> type="text" placeholder="Toezicht houden" name="talent1" maxlength="45" required/> <br/> 
				<?php placeErrorBox($skill2Err); ?> 
				<label>Talent 2</label><input value=<?php echo '"' . $Skill2 . '"';?> type="text" placeholder="Evenementen klaarzetten" name="talent2" maxlength="45"/> <br/> 
				<?php placeErrorBox($skill3Err); ?> 
				<label>Talent 3</label><input value=<?php echo '"' . $Skill3 . '"';?> type="text" placeholder="Koffie drinken" name="talent3" maxlength="45"/> <br/> 
			</fieldset>
			
			<fieldset class="fieldset_middle">
				<legend>Inloggegevens</legend>
				<?php placeErrorBox($usernameErr); ?>
				<label>Gebruikersnaam</label><input value=<?php echo '"' . $Username . '"';?> type="text" placeholder="12345678" name="gebruikersnaam" maxlength="8" required/> <br/>
				<?php placeErrorBox($passwordErr); ?> 
				<label>Wachtwoord</label><input value=<?php echo '"' . $Password . '"';?> type="text" placeholder="123" name="wachtwoord" maxlength="3" required/> 
			</fieldset>
			
			<fieldset>
			<legend> Karakter </legend>
				<div class="container">
					<label class="radioText"><img src="_img/r_man.png"/></label><input class="radio" type="radio" name="karakter" value="r_man" checked> 
				</div>
				<div class="container">
					<label class="radioText"><img src="_img/b_man.png"/></label><input class="radio" type="radio" name="karakter" value="b_man"> 
				</div>
				<div class="container">
					<label class="radioText"><img src="_img/r_vrouw.png"/></label><input class="radio" type="radio" name="karakter" value="r_vrouw"> 
				</div>
				<div class="container">
					<label class="radioText"><img src="_img/b_vrouw.png"/></label><input class="radio" type="radio" name="karakter" value="b_vrouw"> 
				</div>
			<input class="submitButton" type="submit" name="submit" value="Registreren">		
			</fieldset>	
			</form>
		</div>
	</body>
</html>