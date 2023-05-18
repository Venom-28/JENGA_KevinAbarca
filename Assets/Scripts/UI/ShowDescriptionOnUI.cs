using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowDescriptionOnUI : MonoBehaviour
{
    private GameObject UIPanel;

    private void Start()
    {
        UIPanel = GameObject.FindGameObjectWithTag("InfoPanel");
    }

    private void OnMouseOver()
    {
        UIPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Grade : " + gameObject.GetComponent<JengaPieces>().grade +"    Domain :"+ gameObject.GetComponent<JengaPieces>().Domain;
        UIPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Cluster : " + gameObject.GetComponent<JengaPieces>().cluster;
        UIPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Standard ID : " + gameObject.GetComponent<JengaPieces>().standarID + gameObject.GetComponent<JengaPieces>().standardDescription;
    }
    private void OnMouseExit()
    {
        UIPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Grade : ";
        UIPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Cluster : ";
        UIPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Standard ID ";
    }
}
