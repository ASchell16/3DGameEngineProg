using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectionController : MonoBehaviour
{
    public string SelectedObjectTag;
    public GameObject SelectedObject;
    public float maxInteractionDistance = 500;
    private RaycastHit hitResult;
    public Text txtSelected;

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,
                           Camera.main.transform.forward,
                           out hitResult,
                           maxInteractionDistance))
        {
           
            if (hitResult.collider.gameObject.tag != "Untagged")
            {
                SelectedObject = hitResult.collider.gameObject;
                SelectedObjectTag = hitResult.collider.gameObject.tag;
                ShowText();
            }
            else
            {
                SelectedObject = null;
                SelectedObjectTag = "";
                HideText();
            }
            if (!string.IsNullOrEmpty(SelectedObjectTag))
                txtSelected.text = SelectedObjectTag;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SelectedObject != null)
                HandleSelection();
        }
    }

    private void HandleSelection()
    {
        switch (SelectedObjectTag)
        {
            case "Container":
                SelectedObject.GetComponent<Container>().Toggle();
                break;
        }
    }
    private void ShowText()
    {
        txtSelected.gameObject.SetActive(true);
    }
    private void HideText()
    {
        txtSelected.gameObject.SetActive(false);
    }
	
}
