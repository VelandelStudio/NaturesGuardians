using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour {

    private GameObject naturalElement;
    private bool isBuildable;

    private void Start()
    {
        isBuildable = true;
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        if (isBuildable)
        {
            Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Instantiate(naturalElement, naturalPlace, Quaternion.identity, transform);
            naturalElement = GetComponent<GameObject>();
            isBuildable = false;
        }
    }

    public void RemoveNaturalElemt()
    {
        Destroy(naturalElement);

        isBuildable = true;
    }
}
