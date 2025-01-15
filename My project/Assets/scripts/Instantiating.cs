using UnityEngine;
using System.Linq;

public class Instantiating : MonoBehaviour
{
    [SerializeField] private GameObject GravelTile;
    [SerializeField] private GameObject RockTile;
    [SerializeField] private GameObject StoneTile;
    [SerializeField] private GameObject VineTile;
    [SerializeField] private GameObject Crystal;
    [SerializeField] public GameObject tileStorage;
    public IntroCamPos introCamPos;
    public StartPressed startPressed;
    public bool Finished = false;
    private float[,] grid;
    private int[] rowSize;
    public float[] gridSpecs = new float[4];
    private int sideLength;
    public Vector3 origin_WalkSuface;
    [SerializeField] public GameObject WalkSuface;

    public void GenerateMap(int gridSize){
     
        sideLength = (int)((0.5 * gridSize) + 0.5);
        gridSpecs[0] = (float)gridSize;         //Grid Width SIze.
        gridSpecs[1] = (float)(3*sideLength*(sideLength - 1) + 1);  //Amount of tiles.

        void MakeRowSizes(){

            rowSize = new int[gridSize];
            int reducer = 0;

            for (int i = 0; i < gridSize; i++)
            {
                // Equation for size is: sidelength = 0.5(hex width) + 0.5
                if (i < (gridSize - 1) / 2){
                    rowSize[i] = (int)((0.5 * gridSize) + 0.5 + i);
                    reducer = i;
                }
                else if(i > (gridSize - 1) / 2){
                    rowSize[i] = (int)((0.5 * gridSize) + 0.5 + reducer);
                    reducer -= 1;
                }
                else{
                    rowSize[i] = gridSize;
                }

            }
        }

        void InstantiateTiles(){

            float tileX, tileY;

            grid = new float[gridSize, 2];

            tileX = 0;
            tileY = 0;
            int reducer2 = 0;
            int tileNum = 0;

            int[] smallGrid = {9,41,49,81};
            int[] mediumGrid = {12,21,85,93,156,165,174,237,245,318,309};
            int[] largeGrid = {};

            for(int i = 0; i < gridSize; i++){
 
                tileY = (i * -1.55f);

                if (i <= (gridSize - 1) / 2){

                    tileX = (i * -0.9f);
                    reducer2 = i - 1;
                }
                else if (i > (gridSize - 1) / 2){
                    
                    tileX = (reducer2 * -0.9f);
                    
                    reducer2 = reducer2 - 1;

                }

                for(int g = 0; g < rowSize[i]; g++){
                                    
                    Vector3 position = new Vector3((tileX + (g * 1.8f)), 0, tileY);

                    int terrainSelect = Random.Range(0, 100);

                    if (terrainSelect < 70)  // 70% chance for gravel
                    {
                        Instantiate(GravelTile, position, Quaternion.identity, tileStorage.transform);if (tileNum == (int)(gridSpecs[1])/2){
                            gridSpecs[2] = position.x;
                            gridSpecs[3] = position.z;
                        }
                        tileNum += 1;
                    }
                    else if (terrainSelect < 80)  // 10% chance for rock
                    {
                        Instantiate(RockTile, position, Quaternion.identity, tileStorage.transform);
                        if (tileNum == (int)(gridSpecs[1])/2){
                            gridSpecs[2] = position.x;
                            gridSpecs[3] = position.z;
                        }
                        tileNum += 1;
                    }
                    else if (terrainSelect < 90)  // 10% chance for vine
                    {
                        Instantiate(VineTile, position, Quaternion.identity, tileStorage.transform);
                        if (tileNum == (int)(gridSpecs[1])/2){
                            gridSpecs[2] = position.x;
                            gridSpecs[3] = position.z;
                        }
                        tileNum += 1;
                    }
                    else  // Remaining 10% chance for stone
                    {
                        Instantiate(StoneTile, position, Quaternion.identity, tileStorage.transform);
                        if (tileNum == (int)(gridSpecs[1])/2){  //Center tile position.
                            gridSpecs[2] = position.x;
                            gridSpecs[3] = position.z;
                        }
                        tileNum += 1;
                    }

                    if(gridSize == 11 && smallGrid.Contains(tileNum - 1)){
                        Debug.Log(tileNum-1);
                        Instantiate(Crystal, position, Quaternion.Euler(new Vector3(0, 180, 0)), tileStorage.transform);
                    }
                    else if(gridSize == 21 && mediumGrid.Contains(tileNum - 1)){
                        Debug.Log(tileNum-1);
                        Instantiate(Crystal, position, Quaternion.Euler(new Vector3(0, 180, 0)), tileStorage.transform);
                    }
                    else if(gridSize == 33 && largeGrid.Contains(tileNum - 1)){
                        Debug.Log(tileNum-1);
                        Instantiate(Crystal, position, Quaternion.Euler(new Vector3(0, 180, 0)), tileStorage.transform);
                    }
                }
            }
            WalkSuface.transform.position = origin_WalkSuface;
            WalkSuface.transform.localScale = new Vector3(gridSize, gridSize, gridSize);
        }

        MakeRowSizes();
        Finished = true;
        InstantiateTiles();
        introCamPos.Begin(); 
    }
}