using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    private GameInstance instance;
    public InputField txtUsername;
    public Button btnCreate;
    private string username;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController != null)
        {
            instance = gameController.GetComponent<GameInstance>();
            if (instance.DoesProfileExist())
            {
                instance.Load();
                instance.LoadScene("MainMenu");
            }
            else
            {
                txtUsername.onValueChanged.AddListener(ValidateTextBox);
                txtUsername.onEndEdit.AddListener(OnUsernameEntered);
                btnCreate.onClick.AddListener(CreateProfile);
            }
        }
        else
        {
            Debug.Log("Game Controller has not been added to the scene");
        }
    }
    private void ValidateTextBox(string contents)
    {
        if (!string.IsNullOrEmpty(contents))
            btnCreate.interactable = true;
        else
            btnCreate.interactable = false;
    }
    private void OnUsernameEntered(string contents)
    {
        username = contents;
    }
    private void CreateProfile()
    {
        if (!string.IsNullOrEmpty(username))
        {
            instance.CreateProfile(username);
            instance.LoadScene("MainMenu");
        }
    }

}
