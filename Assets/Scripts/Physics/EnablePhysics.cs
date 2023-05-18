using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnablePhysics : MonoBehaviour
{
    [SerializeField]
    GameObject brokenGlassAudio;

    [SerializeField]
    GameObject sixthGradeGlass;

    [SerializeField]
    GameObject seventhGradeGlass;

    [SerializeField]
    GameObject eightGradeGlass;

    [SerializeField]
    GameObject mainCamera;

    private void Awake()
    {
        Physics.autoSimulation = false;
    }
    public void ReEnablePhysics()
    {
        Physics.autoSimulation = true;
        brokenGlassAudio.SetActive(true);

        //Validate which tower is focused so it can destroy its GlassPieces

        if (mainCamera.GetComponent<CinemachineVirtualCamera>().LookAt.gameObject.name == "7thCameraFollow")
            seventhGradeGlass.SetActive(false);
        else if (mainCamera.GetComponent<CinemachineVirtualCamera>().LookAt.gameObject.name == "6thCameraFollow")
            sixthGradeGlass.SetActive(false);
        else if (mainCamera.GetComponent<CinemachineVirtualCamera>().LookAt.gameObject.name == "8thCameraFollow")
            eightGradeGlass.SetActive(false);
    }
}
