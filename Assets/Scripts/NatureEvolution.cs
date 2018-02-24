using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Statistics and calculation Script for the Biome
public class NatureEvolution : MonoBehaviour {

    public List<GameObject> animal = new List<GameObject>();

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

    #region Events

    public void AnimalPop()
    {
        Debug.Log("POP MASSIF");
        //Instantiate(animal[0], new Vector3(5, 1, 10), Quaternion.identity);
    }

    #endregion
}
