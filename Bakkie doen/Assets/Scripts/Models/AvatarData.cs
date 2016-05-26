using UnityEngine;

/// <summary>
/// The data of the player returned by the webserver
/// </summary>
public class AvatarData
{
    public int PlayerID;
    public string FirstName;
    public string LastName;
    public string FullName { get { return FirstName + "  " + LastName; } }
    public string Job;
    public string SpawnPoint;
    public string Character;
    public Sprite CharacterSprite;
    public string Element;
    public string Room;
    public int[] FoundPlayers;
    public string[] Skills;
    public string SessionID;
    public bool tutorial;
    public string[] Dialogue;
}
