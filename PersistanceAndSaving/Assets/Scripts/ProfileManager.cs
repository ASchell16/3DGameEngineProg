using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    private GameInstance instance;
    public InputField txtUsername;
    public Button btnCreate;
    public Button btnLoad;
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
                btnLoad.onClick.AddListener(LoadProfile<T>(username));
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
    public void LoadProfile(string profile)
    {
        if (File.Exists(profile))
        {

        }
    }

    public T Load<T>(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                return JsonUtility.FromJson<T>(json);
            }
        }
        else
        {
            return default(T);
        }
    }

}
