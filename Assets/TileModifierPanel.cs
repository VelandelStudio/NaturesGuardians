using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModifierPanel : MonoBehaviour {

    private BuildSystem workingObject;

    public void Rotate(float angle)
    {
        workingObject.NaturalElementInstance.transform.Rotate(Vector3.up, angle);
    }

    public void Remove()
    {
        workingObject.RemoveNaturalElemt();
        Destroy(workingObject);
    }

    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }

    public void EnablePanel(BuildSystem system)
    {
        gameObject.SetActive(true);
        workingObject = system;
    }
}
