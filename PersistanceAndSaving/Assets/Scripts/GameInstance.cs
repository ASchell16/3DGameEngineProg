using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public Profile UserProfile;
    private string savePath;
    private string inventoryListPath;
    private static InventoryList masterInventory;
    public static InventoryList MasterInventory { get { return masterInventory; } }

    private void Awake()
    {
        inventoryListPath = Application.streamingAssetsPath + "/inventory.json";
        LoadInventoryList();
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void CreateProfile(string username)
    {
        savePath = Application.persistentDataPath + "\\" + username + ".sav";
        UserProfile = new Profile(username);
        SaveUserProfile();
    }
    public void SaveUserProfile()
    {
        Save(UserProfile, savePath);
    }
    public void Save(object objecttosave, string savePath)
    {
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(objecttosave);
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
        SaveUserProfile();
        Application.Quit();
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
    public void LoadInventoryList()
    {
        var items = Load<InventoryList>(inventoryListPath);
        if (items != null)
        {
            masterInventory = items;
        }
    }
    public static List<InventoryItem> GetItemsOfRarity(ItemRarity rarity)
    {
        return MasterInventory.Items.Where(item => item.Rarity == rarity).ToList();
    }
    public static InventoryItem GetInventoryItem(int ID)
    {
        return masterInventory.Items.Find(item => item.ID == ID);
    }

}
