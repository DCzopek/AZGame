using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTavern : MonoBehaviour {

    SceneLoadingController sceneController;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneLoadingController>();
    }

    public void GoToTavern()
    {
        sceneController.LoadScene(GameScene.Tavern, true);
    }
}
