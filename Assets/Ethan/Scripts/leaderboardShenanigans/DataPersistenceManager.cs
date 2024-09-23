using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager Instance {  get; private set; }
    //REFERENCE VIDEO: https://youtu.be/aUi9aijvpgs?si=Es15MXUo9x9JAqnh
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        //TODO - Load any saved data from a file using the data handler
        
        //makes new game data if no game data was found
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing to defaults.");
            NewGame();
        }
        //TODO - push loaded data to all other scripts that need it
    }
    public void SaveGame()
    {
        //TODO - pass data to other scripts so they can update

        //TODO - save that data to a file using the data handler
    }
}
