using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernInteractions : MonoBehaviour {

    [Header("Game Objects")]
    [SerializeField] GameObject missionView;

    [Header("Buttons")]
    [SerializeField] Button inkeeperButton;
    [SerializeField] Button customerButton;
    [SerializeField] Button backToMenuButton;

    [Header("Text Fields")]
    [SerializeField] Text missionName;
    [SerializeField] Text missionDescription;

    SceneLoadingController sceneController;
    GDEManager gdeManager;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneLoadingController>();
        gdeManager = FindObjectOfType<GDEManager>();
    }

    public void InkeeperInteraction()
    {
        DisableButtons();
        RandomizeMission();
        missionView.SetActive(true);
        Debug.Log("pressed inkeepper");
    }
    public void CustomerInteraction()
    {
        DisableButtons();
        RandomizeMission();
        missionView.SetActive(true);
        Debug.Log("customer pressed");
    }
    public void RandomizeMission()
    {
        gdeManager.previousMission = gdeManager.currentMission;
        while(gdeManager.previousMission == gdeManager.currentMission)
            gdeManager.currentMission = GDEManager.missionList[Random.Range(0, GDEManager.missionList.Count)];
        missionName.text = gdeManager.currentMission.MissionName;
        missionDescription.text = gdeManager.currentMission.MissionDescription;
    }
    public void TurnOffMissionView()
    {
        missionView.SetActive(false);
        EnableButtons();
    }
    public void BackToMainMenu()
    {
        sceneController.LoadScene(GameScene.Menu, true);
    }
    void DisableButtons()
    {
        inkeeperButton.enabled = false;
        customerButton.enabled = false;
        backToMenuButton.enabled = false;
    }
    void EnableButtons()
    {
        inkeeperButton.enabled = true;
        customerButton.enabled = true;
        backToMenuButton.enabled = true;
    }
}
