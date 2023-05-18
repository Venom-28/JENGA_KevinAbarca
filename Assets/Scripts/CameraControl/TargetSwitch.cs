using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class TargetSwitch : MonoBehaviour
{
    [SerializeField]
    Transform sixthTower;
    [SerializeField]
    Transform seventhTower;
    [SerializeField]
    Transform eigthTower;

    [SerializeField]
    private int counter =1;

    CinemachineVirtualCamera lookAtCam;

    [SerializeField]
    CinemachineVirtualCamera orbitCam;

    [SerializeField]
    TextMeshProUGUI gradeTex;



    void Start()
    {
        gradeTex.text = "7th GROUP";

        lookAtCam = GetComponent<CinemachineVirtualCamera>();
        lookAtCam.LookAt = seventhTower;

        orbitCam.LookAt = seventhTower;
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            lookAtCam.Priority = 1;
            orbitCam.Priority = 2;
        }
        if (Input.GetMouseButtonUp(2))
        {
            lookAtCam.Priority = 2;
            orbitCam.Priority = 1;
        }
    }

    //Toggles Cinemachine "LookAT" on NextStack UI Event
    public void NextTower()
    {
        counter++;

        if (counter > 2)
            counter = 0;

        if (counter == 1)
        {
            gradeTex.text = "7th GROUP";
            lookAtCam.LookAt = seventhTower;
            orbitCam.LookAt = seventhTower;
            orbitCam.Follow = seventhTower;
        }
        else if (counter == 2)
        {
            gradeTex.text = "8th GROUP";
            lookAtCam.LookAt = eigthTower;
            orbitCam.LookAt = eigthTower;
            orbitCam.Follow = eigthTower;
        }
        else if (counter == 0)
        {
            gradeTex.text = "6th GROUP";
            lookAtCam.LookAt = sixthTower;
            orbitCam.LookAt = sixthTower;
            orbitCam.Follow = sixthTower;
        }
    }

    //Toggles Cinemachine "LookAT" on PreviousStack UI Event
    public void PreviousTower()
    {
        counter--;

        if (counter < 0)
            counter = 2;

        if (counter == 1)
        {
            gradeTex.text = "7th GROUP";
            lookAtCam.LookAt = seventhTower;
            orbitCam.LookAt = seventhTower;
            orbitCam.Follow = seventhTower;
        }
        else if (counter == 2)
        {
            gradeTex.text = "8th GROUP";
            lookAtCam.LookAt = eigthTower;
            orbitCam.LookAt = eigthTower;
            orbitCam.Follow = eigthTower;
        }
        else if (counter == 0)
        {
            gradeTex.text = "6th GROUP";
            lookAtCam.LookAt = sixthTower;
            orbitCam.LookAt = sixthTower;
            orbitCam.Follow = sixthTower;
        }
    }
}
