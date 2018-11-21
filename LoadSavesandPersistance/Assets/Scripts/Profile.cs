using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Profile
{
    public string Username;
    public CharacterStats Stats;
    public List<InventoryItem> inventory;

    public Profile(string Name)
    {
        Username = Name;
        Stats = new CharacterStats();
        inventory = new List<InventoryItem>();
    }
}
	
