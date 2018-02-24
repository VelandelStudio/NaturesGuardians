using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Statistics and calculation Script for the Biome
public class NatureEvolution : MonoBehaviour {

    public List<GameObject> animal = new List<GameObject>();
    public bool[] eventCondition = new bool[2];

    private int trees;
    private int rocks;
    private int bushes;

    private void Start()
    {
        Debug.Log(eventCondition.Length);
    }

    private void Update()
    {
        eventCondition[0] = trees >= 5;
        eventCondition[1] = trees >= 20;
        eventCondition[2] = trees > 0;         
    }

    #region addRemove

    public void AddNatureElem(GameObject nature)
    {
        if (nature.tag == "Tree")
        {
            trees++;
        }

        if (nature.tag == "Rock")
        {
            rocks++;
        }

        if (nature.tag == "Bush")
        {
            bushes++;
        }
    }

    public void RemoveNatureElem(GameObject nature)
    {
        if (!nature)
            return;

        if (nature.tag == "Tree")
        {
            trees--;
        }

        if (nature.tag == "Rock")
        {
            rocks--;
        }

        if (nature.tag == "bush")
        {
            bushes--;
        }
    }

    #endregion
}
