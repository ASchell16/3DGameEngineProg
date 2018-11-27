using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private GameInstance instance;
    public Text textUserName;

    public Button btnPlay;
    public Button btnQuit;
    public Button btnDelete;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController != null)
        {
            instance = gameController.GetComponent<GameInstance>();
            textUserName.text = instance.UserProfile.Username;

            btnPlay.onClick.AddListener(StartGame);
            btnQuit.onClick.AddListener(QuitGame);
            btnDelete.onClick.AddListener(DeleteProfileAndRestart);
        }
    }
    private void StartGame()
    {
        instance.LoadScene("game");
    }
    public void QuitGame()
    {
        instance.Quit();
    }
    public void DeleteProfileAndRestart()
    {
        instance.DeleteProfile();
        instance.LoadScene("CreateProfile");
    }

}
