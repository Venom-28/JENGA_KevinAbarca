using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SortData : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    //Temporary holder for sorting whole line in 2D grid
    MultiDimensionalArray tempHolder = new MultiDimensionalArray();

    void Start()
    {
        SortDataGrid();
    }
    private void SortDataGrid()
    {
        for (int i = 0; i < DataConnection.Instance.dataGrid.Count -2; i++)
        {
            string firstDomainItem = DataConnection.Instance.dataGrid[i].myGridData[5];
            string secondDomainItem = DataConnection.Instance.dataGrid[i + 1].myGridData[5];

            //Determine if DOMAIN string is equally long in both items
            if (firstDomainItem.Length == secondDomainItem.Length)
            {
                Debug.Log("AAA");
                //if Both strings are same lenght compare first and last item on both string to "verify" are identical
                if (firstDomainItem[0] == secondDomainItem[0]
                    && firstDomainItem[firstDomainItem.Length - 1] == secondDomainItem[firstDomainItem.Length - 1])
                {
                    Debug.Log("BBB");
                    string firstClusterItem = DataConnection.Instance.dataGrid[i].myGridData[6];
                    string secondClusterItem = DataConnection.Instance.dataGrid[i + 1].myGridData[6];

                    //Determine if CLUSTER string is equally long in both items 
                    if (DataConnection.Instance.dataGrid[i].myGridData[6].Length == DataConnection.Instance.dataGrid[i + 1].myGridData[6].Length)
                    {
                        Debug.Log("DDD");
                        //if Both strings are same lenght compare first and last item on both string to "verify" are identical
                        if (firstClusterItem[0] == secondClusterItem[0]
                            && firstClusterItem[firstClusterItem.Length - 1] == secondClusterItem[firstClusterItem.Length - 1])
                        {
                            Debug.Log("EEE");
                            //Sort items according to STANDARD ID
                            string firstStandardItem = DataConnection.Instance.dataGrid[i].myGridData[7];
                            string secondStandardItem = DataConnection.Instance.dataGrid[i + 1].myGridData[7];
                           
                            // Compare strings by ASCII value
                            if((int)firstStandardItem[0] < (int)secondStandardItem[0])
                            {
                                Debug.Log("FFF");
                                tempHolder = DataConnection.Instance.dataGrid[i];
                                DataConnection.Instance.dataGrid[i] = DataConnection.Instance.dataGrid[i + 1];
                                DataConnection.Instance.dataGrid[i + 1] = tempHolder;
                            }
                        }
                    } //CLUSTER strings are not identicall, the we sort
                    else
                    {
                        Debug.Log("GGG");
                        if ((int)firstClusterItem[0] < (int)secondClusterItem[0])
                        {
                            Debug.Log("HHH");
                            tempHolder = DataConnection.Instance.dataGrid[i];
                            DataConnection.Instance.dataGrid[i] = DataConnection.Instance.dataGrid[i + 1];
                            DataConnection.Instance.dataGrid[i + 1] = tempHolder;
                        }
                    }
                }else// DOMAIN strings are not identicall, the we sort
                {
                    Debug.Log("III");
                    if ((int)firstDomainItem[0] < (int)secondDomainItem[0])
                    {
                        Debug.Log("JJJ");
                        tempHolder = DataConnection.Instance.dataGrid[i];
                        DataConnection.Instance.dataGrid[i] = DataConnection.Instance.dataGrid[i + 1];
                        DataConnection.Instance.dataGrid[i + 1] = tempHolder;
                    }
                }
            }else // DOMAIN STRING ARE NOT EQUALLY LONG
            {
                if ((int)firstDomainItem[0] < (int)secondDomainItem[0])
                {
                    Debug.Log("KKK");
                    tempHolder = DataConnection.Instance.dataGrid[i];
                    DataConnection.Instance.dataGrid[i] = DataConnection.Instance.dataGrid[i + 1];
                    DataConnection.Instance.dataGrid[i + 1] = tempHolder;
                }
            }
        }
        startButton.interactable = true;
    }
}
