using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    public GameObject Content;
    public Container linkedInventory;
    public GameObject ListItemButton;

    public void Load(Container inventoryController)
    {
        linkedInventory = inventoryController;
        foreach (InventoryItem item in linkedInventory.Contents)
            AddItem(item);
    }
    private void AddItem(InventoryItem item)
    {
        var gObject = Instantiate(ListItemButton, Content.transform);
        gObject.GetComponent<Listbutton>().SetItem(item);
    }
    public void Close()
    {
        linkedInventory.Close();
        Destroy(gameObject);
    }
	
}
