using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Linq;
using System;

public class DataConnection : MonoBehaviour
{
    [SerializeField]
    private string URL;

    [SerializeField]
    private GameObject SorterObject;

    //Singleton Instance to ease acces to data
    [SerializeField]
    public List<MultiDimensionalArray> dataGrid = new List<MultiDimensionalArray>(113);

    public int maxIterationValue = 113;

    public static DataConnection Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(ConnectToAPI());
    }

    //Get data from URL using SimpleJSON library
    IEnumerator ConnectToAPI()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.LogError(request.error);

            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSON.Parse(json);

                for (var i = 0; i < dataGrid.Count; i++)
                {
                    dataGrid[i].myGridData[0] = stats[i]["id"];
                    dataGrid[i].myGridData[1] = stats[i]["subject"];
                    dataGrid[i].myGridData[2] = stats[i]["grade"];
                    dataGrid[i].myGridData[3] = stats[i]["mastery"];
                    dataGrid[i].myGridData[4] = stats[i]["domainid"];
                    dataGrid[i].myGridData[5] = stats[i]["domain"];
                    dataGrid[i].myGridData[6] = stats[i]["cluster"];
                    dataGrid[i].myGridData[7] = stats[i]["standardid"];
                    dataGrid[i].myGridData[8] = stats[i]["standarddescription"];
                }
                SorterObject.SetActive(true);
            }
        }
    }
}