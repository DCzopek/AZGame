using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernInteractions : MonoBehaviour {

    SceneLoadingController sceneController;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneLoadingController>();
        //TODO Load available missions to lists
    }

    public void InkeeperInteraction()
    {
        //TODO show menu with available missions - level easy and medium
        //TODO choosing missions from list
        //TODO saving choosen mission
        // Key rule: only one mission taken
        Debug.Log("pressed inkeepper");
    }
    public void CustomerInteraction()
    {
        //TODO show menu with available missions - level easy and medium
        //TODO choosing missions from list
        //TODO saving choosen mission
        // Key rule: only one mission taken
        Debug.Log("customer pressed");
    }
    public void BackToMainMenu()
    {
        sceneController.LoadScene(GameScene.Menu, true);
    }
}
