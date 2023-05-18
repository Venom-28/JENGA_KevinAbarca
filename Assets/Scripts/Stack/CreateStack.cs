using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStack : MonoBehaviour
{
    [SerializeField]
    GameObject glassPiecePrefab;
    [SerializeField]
    GameObject woodPiecePrefab;
    [SerializeField]
    GameObject stonePiecePrefab;
    [SerializeField]
    GameObject parentPrefab;

    [SerializeField]
    float pieceSideOffset;
    [SerializeField]
    float pieceUpOffset;

    [SerializeField]
    string gradeValidator;

    [SerializeField]
    GameObject stackParentObject;

    [SerializeField]
    GameObject stackSpawner;

    [SerializeField]
    GameObject glassParent;

    [SerializeField]
    Vector3 piecesOffset;

    [SerializeField]
    Transform[] parentsArray = new Transform[114];

    private int iterations = 114;

    void Start()
    {
        int parent = iterations / 2;
        GeneratePiecesParents(parent);
        BuildStack();
        
    }
    private void BuildStack()
    {
        float sideAxisMovement = 0f;
        float verticalAxissMovement = 0f;

        int parentIndex = 0;

        for (int i = 0; i< iterations; i++)
        {
            if(DataConnection.Instance.dataGrid[i].myGridData[2]== gradeValidator)
            {
                if (i % 3 == 0)
                {
                    parentIndex++;
                    sideAxisMovement = 0;
                    verticalAxissMovement += pieceUpOffset;
                }

                sideAxisMovement -= pieceSideOffset;

                //Determine type of piece is gonna be instantiated and make them child of corresponding parent
                if (DataConnection.Instance.dataGrid[i].myGridData[3] == "0")
                {
                    GameObject instantiatedPrefab = Instantiate(glassPiecePrefab, new Vector3(stackSpawner.transform.position.x, stackSpawner.transform.position.y + verticalAxissMovement, stackSpawner.transform.position.z+ sideAxisMovement), Quaternion.identity);
                    instantiatedPrefab.transform.SetParent(parentsArray[parentIndex].transform, false);
                    SetPieceInfoPieces(instantiatedPrefab, i);

                    instantiatedPrefab.transform.SetParent(glassParent.transform);

                }
                else if (DataConnection.Instance.dataGrid[i].myGridData[3] == "1")
                {
                    GameObject instantiatedPrefab = Instantiate(woodPiecePrefab, new Vector3(stackSpawner.transform.position.x, stackSpawner.transform.position.y + verticalAxissMovement, stackSpawner.transform.position.z + sideAxisMovement), Quaternion.identity);
                    instantiatedPrefab.transform.SetParent(parentsArray[parentIndex].transform, false);
                    SetPieceInfoPieces(instantiatedPrefab, i);
                }
                else if (DataConnection.Instance.dataGrid[i].myGridData[3] == "2")
                {
                    GameObject instantiatedPrefab = Instantiate(stonePiecePrefab, new Vector3(stackSpawner.transform.position.x, stackSpawner.transform.position.y + verticalAxissMovement, stackSpawner.transform.position.z + sideAxisMovement), Quaternion.identity);
                    instantiatedPrefab.transform.SetParent(parentsArray[parentIndex].transform, false);
                    SetPieceInfoPieces(instantiatedPrefab, i);
                }
            }
            
        }
    }

    public void GeneratePiecesParents(int numberOfItems)
    {
        //every 3 pieces parent them to a new Prefab so we can rotate the whole parent not each ppiece
        if(numberOfItems %3 == 0)
        {
            for (int i = 0; i < numberOfItems/3; i++)
            {
                GameObject instantiatedParent = Instantiate(parentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                if (i % 2 == 1)
                {
                    instantiatedParent.transform.rotation = Quaternion.Euler(0, 90, 0);
                    instantiatedParent.transform.position = piecesOffset;
                }
                parentsArray[i] = instantiatedParent.transform;
                instantiatedParent.transform.parent = stackParentObject.transform;
            }
        }
    }

    //Assign information from API to each instantiated piece
    public void SetPieceInfoPieces(GameObject piecePrefab, int index)
    {
        piecePrefab.GetComponent<JengaPieces>().iD = DataConnection.Instance.dataGrid[index].myGridData[0];
        piecePrefab.GetComponent<JengaPieces>().subject = DataConnection.Instance.dataGrid[index].myGridData[1];
        piecePrefab.GetComponent<JengaPieces>().grade = DataConnection.Instance.dataGrid[index].myGridData[2];
        piecePrefab.GetComponent<JengaPieces>().mastery = DataConnection.Instance.dataGrid[index].myGridData[3];
        piecePrefab.GetComponent<JengaPieces>().domaindID = DataConnection.Instance.dataGrid[index].myGridData[4];
        piecePrefab.GetComponent<JengaPieces>().domain = DataConnection.Instance.dataGrid[index].myGridData[5];
        piecePrefab.GetComponent<JengaPieces>().cluster = DataConnection.Instance.dataGrid[index].myGridData[6];
        piecePrefab.GetComponent<JengaPieces>().standarID = DataConnection.Instance.dataGrid[index].myGridData[7];
        piecePrefab.GetComponent<JengaPieces>().standardDescription = DataConnection.Instance.dataGrid[index].myGridData[8];
    }
}
