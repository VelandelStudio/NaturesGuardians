using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Statistics and calculation Script for the Biome
public class NatureEvolution : MonoBehaviour {

    private int trees;
    private int rocks;
    private int bushes;

    public void AddTree()
    {
        trees++;
    }

    public void AddRocks()
    {
        rocks++;
    }

    public void AddBushes()
    {
        bushes++;
    }

    public void RemoveTree()
    {
        trees--;
    }

    public void RemoveRocks()
    {
        rocks--;
    }

    public void RemoveBushes()
    {
        bushes--;
    }
}
