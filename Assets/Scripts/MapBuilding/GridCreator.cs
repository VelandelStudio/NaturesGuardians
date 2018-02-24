using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour {

    public int length = 20;
    public int width = 30;
    public int heigth = 10;

    private string holderName = "GeneratedGrid";
    private Transform Biome;

    public List<Vector3> grid = new List<Vector3>();
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
        InitiateGrid();
    }

    private void InitiateBiome()
    {
        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < width; z++)
            {
                Transform tile = TilePlacement(x, z, groundTile);
                tile.parent = Biome;
            }
        }
    }

    private void InitiateGrid()
    {
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                for (int z = 0; z < width; z++)
                {
                    Vector3 position = new Vector3(x,y,z);
                    grid.Add(position);
                }
            }
        }
    }

    private Transform TilePlacement(int x, int z, Transform gTile)
    {
        Vector3 TilePosition = new Vector3(x, 0, z);
        Transform tile = Instantiate(gTile, TilePosition, Quaternion.identity) as Transform;

        return tile;
    }

    [System.Serializable]
    public struct Coord
    {
        public int x;
        public int y;
        public int z;

        public Coord(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
}
