using UnityEngine;
using System.Collections;

public class ReadDataController
{

    public static string[] items;

    public static void Start(string userInformation)
    {
        WWW itemsData = new WWW("http://localhost/Database/read/player_login.php?us=" + userInformation + "&pw=" + userInformation);
        //yield return itemsData;
        string itemsDataString = itemsData.text;
        
        items = itemsDataString.Split(':');
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }


}