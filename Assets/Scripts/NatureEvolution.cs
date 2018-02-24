using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Statistics and calculation Script for the Biome
public class NatureEvolution : MonoBehaviour {

    private int trees;
    private int rocks;
    private int bushes;

    private void Update()
    {
        if (trees > 10 && rocks > 5 && bushes > 5)
        {
            AnimalPop();
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

    #region Events

    public void AnimalPop()
    {
        Debug.Log("Possible animal spaw");
    }

    #endregion
}
