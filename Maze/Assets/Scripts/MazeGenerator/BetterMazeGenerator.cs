using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMazeGenerator : MonoBehaviour
{
     // private int[,] map;
    public int[,] verticalMap;
    public int[,] horizontalMap;
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    // public PathMaker pathMaker;

    public GameObject verticalPrefab;
    public GameObject horizontalPrefab;

    // Start is called before the first frame update
    void Start()
    {

        verticalMap = new int[rows, columns];
        horizontalMap = new int[rows, columns];
        InitializeMaze();
        CarvePath();
        DrawMap();
        // pathMaker = new PathMaker();

    }

    private void InitializeMaze()
    { 
        int row = 0;
        int column = 0;

        while (row < this.rows)
        {
            while (column < this.columns)
            {
                verticalMap[row, column] = 1;
                column++;
            }
            column = 0;
            row++;
        }
        row = 0;
        column = 0;

        while (row < this.rows)
        {
            while (column < this.columns)
            {
                horizontalMap[row, column] = 1;
                column++;
            }
            column = 0;
            row++;
        }
    }

    void CarvePath()
    {
        //pathMaker.CarvePath(map, this.rows, this.columns);
        int row = 1;
        int column = 1;
        int randomNumber = 0;

        while (row < this.rows)
        {
            while (column < this.columns)
            {
                // flip a coin
                randomNumber = Random.Range(0, 100);

                if(column == columns-1){
                    horizontalMap[row, column] = 0;
                }
                if(row == rows-1){
                    verticalMap[row, column] = 0;
                }
                
                if (randomNumber < 50 && row < this.rows)
                {
                    // horizontalMap[row, column] = 0;
                    if(row < rows){
                        horizontalMap[row, column] = 0;
                    }
                }
                else if (randomNumber > 50 && column < this.columns)
                {
                    // verticalMap[row, column] = 0;
                    if(column < columns){
                        verticalMap[row, column] = 0;
                    }
                }
                column++;
            }
            column = 0;
            row++;
        }

    }

    private void DrawMap()
    {

        int row = 0;
        int column = 0;
        
        while (row < this.rows)
        {
            while (column < this.columns)
            {
                // instantiate a new prefab at
                if (horizontalMap[row, column] == 1) { 
                    Instantiate(horizontalPrefab, new Vector3(column * 5 + 2.45f, 0, row * 5), Quaternion.identity);
                }
                column++;
            }
            column = 0;
            row++;
        }
        
        row = 0;
        column = 0;

        while (row < this.rows)
        {
            while (column < this.columns)
            {
                // instantiate a new prefab at
                if (verticalMap[row, column] == 1)
                {
                    Instantiate(verticalPrefab, new Vector3(column * 5, 0, row * 5 + 2.45f), Quaternion.identity);
                }
                column++;
            }
            column = 0;
            row++;
        }
    }
}
