using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistanceManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        Instance = this;
    }
    public void Start()
    {
        dataPersistanceObjects = FindAllDataPersistanceObjects();
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        LoadGame();
    }
    public void OnApplicationPause()
    {
        if (dataPersistanceObjects != null)
            SaveGame();
    }
    public void OnApplicationQuit()
    {
        SaveGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if (gameData == null)
            NewGame();

        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        return FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistance>().ToList();
    }
}
