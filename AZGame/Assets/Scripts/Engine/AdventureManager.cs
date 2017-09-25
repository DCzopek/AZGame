using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour {

    GDEManager gdeManager;

    TextFields textFields;

    private void Awake()
    {
        gdeManager = FindObjectOfType<GDEManager>();
        textFields = GetComponent<TextFields>();

        LoadMissionData();
    }
    public void LoadMissionData()
    {
        if (gdeManager.currentMission.NextCard == null) return;

        gdeManager.currentMission = new GameDataEditor.GDEMissionsData(gdeManager.currentMission.NextCard);
        textFields.missionName.text = gdeManager.currentMission.MissionName;
        textFields.missionDescription.text = gdeManager.currentMission.MissionDescription;
        textFields.answerA.text = gdeManager.currentMission.AnswerA;
        textFields.answerB.text = gdeManager.currentMission.AnswerB;
        textFields.answerC.text = gdeManager.currentMission.AnswerC;
        textFields.answerD.text = gdeManager.currentMission.AnswerD;
    }


}
