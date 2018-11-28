using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Listbutton : MonoBehaviour {

    public Text txtName;
    public InventoryItem Item;

    public void SetItem(InventoryItem item)
    {
        Item = item;
        txtName.text = Item.Name;
    }
}
