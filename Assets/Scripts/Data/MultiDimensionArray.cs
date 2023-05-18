using System.Collections.Generic;

[System.Serializable]
public class MultiDimensionalArray
{
    //Serialize so it's visible in Inspector (List of Lists of strings)
    public List<string> myGridData = new List<string>(9);
}
