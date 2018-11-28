using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContainer : Container
{
    public bool isOpened = false;
    public override void Start()
    {
        base.Start();
    }

    public override void Open()
    {
        isOpened = true;
        base.Open();
    }
    public override void Close()
    {
        isOpened = false;
        base.Close();
    }
    public override void Toggle()
    {
        if (isOpened)
            Close();
        else
            Open();
          
        base.Toggle();
    }
}
