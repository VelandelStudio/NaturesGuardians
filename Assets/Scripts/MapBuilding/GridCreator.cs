using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour {

    public int length = 3;
    public int width = 3;
    public int heigth = 3;

    private string holderName = "GeneratedGrid";
    private Transform Biome;

    [HideInInspector] public List<Transform> zGrid = new List<Transform>();
    [HideInInspector] public List<List<Transform>> xGrid = new List<List<Transform>>();
    [HideInInspector] public List<List<List<Transform>>> yGrid = new List<List<List<Transform>>>();

    public Transform groundTile;

    private void Awake()
    {
        if (transform.Find(holderName))
        {
            Destroy(transform.Find(holderName).gameObject);
        }

        Biome = new GameObject(holderName).transform;
        Biome.parent = transform;
    }

    private void Start()
    {
        InitiateBiome();
    }

    private void InitiateBiome()
    {
        InitiateGrid(); 
    }

    private void InitiateGrid()
    {
        for (int y = 0; y < heigth; y++)
        {
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    if (y == 0)
                    {
                        Transform tile = TilePlacement(x, y, z, groundTile);
                        tile.parent = Biome;

                        zGrid.Add(tile);
                    }
                    else
                    {
                        zGrid.Add(null);
                    }
                }
                xGrid.Add(zGrid);
            }
            yGrid.Add(xGrid);
        }
    }

    private Transform TilePlacement(int x, int y, int z, Transform gTile)
    {
        Vector3 TilePosition = new Vector3(x, y, z);
        Transform tile = Instantiate(gTile, TilePosition, Quaternion.identity) as Transform;

        return tile;
    }

    public Transform GetTransformOnGrid(Vector3 vector3)
    {
        return yGrid.ToArray()[(int) vector3.y].ToArray()[(int) vector3.x].ToArray()[(int) vector3.z];
    }

    public void AddNewBuildSystem(Transform tileToInstance)
    {
        //Debug.Log(GetTransformOnGrid(tileToInstance.position).position.x + ", " + GetTransformOnGrid(tileToInstance.position).position.y + ", " + GetTransformOnGrid(tileToInstance.position).position.z);

        Transform tr = GetTransformOnGrid(tileToInstance.position);
        tr = tileToInstance;

        //Debug.Log(GetTransformOnGrid(tileToInstance.position).position.x + ", " + GetTransformOnGrid(tileToInstance.position).position.y + ", " + GetTransformOnGrid(tileToInstance.position).position.z);
    }

    public void RemoveNewBuildSystem(Transform tileClicked)
    {
        Transform tr = GetTransformOnGrid(tileClicked.position);
        tr = null;

        //Debug.Log(GetTransformOnGrid(tileClicked.position));
    }
}
