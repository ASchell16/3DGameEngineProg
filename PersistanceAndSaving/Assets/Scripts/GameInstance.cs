using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public Profile UserProfile;
    private string savePath;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void CreateProfile(string username)
    {
        savePath = Application.persistentDataPath + "\\" + username + ".sav";
        UserProfile = new Profile(username);
        Save();
    }
    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(UserProfile);
            sw.Write(json);
        }
    }
    public void Load()
    {
        using (StreamReader sr = new StreamReader(savePath))
        {
            string json = sr.ReadToEnd();
            UserProfile = JsonUtility.FromJson<Profile>(json);
        }
    }
    public void DeleteProfile()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
    public bool DoesProfileExist()
    {
        bool doesExist;

        if (File.Exists(savePath))
            doesExist = true;
        else
            doesExist = false;

        return doesExist; 
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
        Save();
        Application.Quit();
    }



}
