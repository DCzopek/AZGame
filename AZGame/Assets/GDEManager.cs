using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

public class GDEManager : MonoBehaviour {

    GDECharactersData character;
    List<GDECharactersData> characterList;
    public string atak;

	// Use this for initialization
	void Start ()
    {
        GDEDataManager.Init("gde_data_enc", true);
        characterList = new List<GDECharactersData>();
        FindCharacters();
        //Choose character once and set his data to current character
        
    }
	void FindCharacters()
    {
        foreach(GDECharactersData item in GDEDataManager.GetAllItems<GDECharactersData>())
        {
            characterList.Add(item);
        }
    }

    //Modify data
    //call GDEDataManager.Save();
    //call character.LoadFromSavedData(GDEItemKeys.Characters_CH000);

}
