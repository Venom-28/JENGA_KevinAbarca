using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaPieces : MonoBehaviour
{
    // Class wih properties son Instantiated objects get their info assigned so it can Display on UI
    public string iD;
    public string subject;
    public string grade;
    public string mastery;
    public string domaindID;
    public string domain;
    public string cluster;
    public string standarID;
    public string standardDescription;

    public string ID{get { return iD; }set { iD = value; } }
    public string Subject { get { return subject; } set { subject = value; } }
    public string Grade { get { return grade; } set { grade = value; } }
    public string Mastery { get { return mastery; } set { mastery = value; } }
    public string DomaindID { get { return domaindID; } set { domaindID = value; } }
    public string Domain { get { return domain; } set { domain = value; } }
    public string Cluster { get { return cluster; } set { cluster = value; } }
    public string StandardID { get { return standarID; } set { standarID = value; } }
    public string StandarDescription { get { return standardDescription; } set { standardDescription = value; } }
}
