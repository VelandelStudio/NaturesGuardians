using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    private GameObject naturalElement;
    private GameObject NaturalElementInstance;

    private bool isBuildable;

    private void Start()
    {
        isBuildable = true;
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        if (isBuildable)
        {
            Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + naturalElem.transform.lossyScale.y /2.0f , transform.position.z);
            NaturalElementInstance = Instantiate(naturalElement, naturalPlace, Quaternion.identity, transform);
            isBuildable = false;

            Debug.Log(NaturalElementInstance.name + " is placed");
        }
    }

    public void RemoveNaturalElemt()
    {
        Destroy(NaturalElementInstance);
        isBuildable = true;
    }

    public override void ActionOnTouch()
    {
        if (GameManagement.instance.ObjToCreate)
        {
            naturalElement = GameManagement.instance.ObjToCreate;
            TryPlaceNaturalElem(naturalElement);
        }
    }
}
