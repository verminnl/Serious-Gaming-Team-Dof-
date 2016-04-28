using UnityEngine;
using System.Collections;

/// <summary>
/// The data of the player returned by the webserver
/// </summary>
public class PlayerData
{
    public int PlayerID;
    public string FirstName;
    public string LastName;
    public string Job;
    public string SpawnPoint;
    public string Character;
    public string Element;
    public string Domain;
    public int[][] FoundPlayers;
}
