using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimulation : MonoBehaviour
{
    [SerializeField]
    GameObject StartUI;
    public void StartGame()
    {
        StartUI.SetActive(false);
    }
}
