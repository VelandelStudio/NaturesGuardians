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

    private void Update()
    {
        if (trees >= 5)
        {
            eventCondition[0] = true;

            if (trees >= 20)
            {
                eventCondition[1] = true;
            }
            else
            {
                eventCondition[1] = false;
            }
        }
        else
        {
            eventCondition[0] = false;
        }
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
