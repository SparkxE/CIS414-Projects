using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private int rowCount;
    [SerializeField] private int colCount;
    [SerializeField] private int cubeCount;
    [SerializeField] private int cubeScale;
    private int[,] mazeArray;
    private int cubeIndex;

    private void Awake() {
        // look into simple maze algorithm, removes either N or E wall, starts from SW corner (0,1)
        mazeArray = new int[rowCount, colCount];
        for(int i = 0; i<colCount; i++){
            for(int j = 0; j<rowCount; j++){
                int spawn = Random.Range(0,2);
                if(spawn == 1){
                    mazeArray[j, i] = 1;
                }
                else if(spawn == 0){
                    mazeArray[j, i] = 0;
                }
            }
        }

        for(int i = 0; i<colCount; i++){
            for(int j = 0; j<rowCount; j++){
                if(mazeArray[j, i] == 1 && cubeIndex<=cubeCount){
                    Instantiate(prefab, new Vector3(j,0,i), Quaternion.identity);
                    cubeIndex++;
                }
            }
        }
    }
}
