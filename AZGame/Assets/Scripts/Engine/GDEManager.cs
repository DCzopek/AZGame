using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GDEManager : MonoBehaviour {

    [SerializeField] Text[] charactersDescriptions;
    public static Character character = new Character();
    public static List<GDECharactersData> characterList;

    public static List<GDEMissionsData> missionList;
    public GDEMissionsData currentMission;

    static FileStream file;
    static PlayerData data = new PlayerData();

    public static GDEManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        GDEDataManager.Init("gde_data_enc", true);
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
            file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        characterList = new List<GDECharactersData>();
        missionList = new List<GDEMissionsData>();

        FindMissions();

        FindCharacters();
        FillCharactersDescriptionsText();
        //Choose character once and set his data to current character

    }
    void FindMissions()
    {
        foreach(GDEMissionsData item in GDEDataManager.GetAllItems<GDEMissionsData>())
        {
            if (item.FirstCard)
                missionList.Add(item);
        }
    }
    void FindCharacters()
    {
        foreach(GDECharactersData item in GDEDataManager.GetAllItems<GDECharactersData>())
        {
                characterList.Add(item);
        }
    }
    void FillCharactersDescriptionsText()
    {
        for(int i = 0; i < charactersDescriptions.Length; i++)
        {
            charactersDescriptions[i].text = characterList[i].CharacterDescription;
        }
    }
    public static void SavePlayerData(int i = 0,bool firstSave = false)
    {
        if(firstSave)
            InitCharacter(i);

        BinaryFormatter bf = new BinaryFormatter();

        file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);

        
        if(firstSave)
        {
            data.characterName = characterList[i].CharacterName;
            data.characterDescription = characterList[i].CharacterDescription;
            data.health = characterList[i].HealthPoints;
            data.experience = characterList[i].Experience;
            data.level = characterList[i].Level;
            data.basicMelee = characterList[i].BasicMelee;
            data.basicDistance = characterList[i].BasicDistance;
            data.basicMagic = characterList[i].BasicMagic;
        }
        else
        {
            data.characterName = character.characterName;
            data.characterDescription = character.characterDescription;
            data.health = character.health;
            data.experience = character.experience;
            data.level = character.level;
            data.basicMelee = character.basicMelee;
            data.basicDistance = character.basicDistance;
            data.basicMagic = character.basicMagic;
        }
        bf.Serialize(file, data);
    }
    static void InitCharacter(int i)
    {
        character.characterName = characterList[i].CharacterName;
        character.characterDescription = characterList[i].CharacterDescription;
        character.experience = characterList[i].Experience;
        character.level = characterList[i].Level;
        character.basicMagic = characterList[i].BasicMagic;
        character.basicDistance = characterList[i].BasicDistance;
        character.basicMelee = characterList[i].BasicMelee;
    }
    public static void LoadPlayerData()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            character.characterName = data.characterName;
            character.characterDescription = data.characterDescription;
            character.health = data.health;
            character.experience = data.experience;
            character.level = data.level;
            character.basicMelee = data.basicMelee;
            character.basicDistance = data.basicDistance;
            character.basicMagic = data.basicMagic;
        }
    }
    //Modify data
    //call GDEDataManager.Save();
    //call character.LoadFromSavedData(GDEItemKeys.Characters_CH000);
}

[Serializable]
class PlayerData
{
    public string characterName;
    public string characterDescription;
    public float health;
    public float experience;
    public float level;
    public float basicMelee;
    public float basicDistance;
    public float basicMagic;
}

