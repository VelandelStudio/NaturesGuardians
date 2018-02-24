using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    private GameObject naturalElement;
    private GameObject NaturalElementInstance;

    private bool isBuildable;
    public bool IsBuildable
    {
        get { return !GameManagement.instance.InsideMenus && isBuildable; }
        set { isBuildable = value; }
    }

    private void Start()
    {
        IsBuildable = true;
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        if (IsBuildable)
        {
            Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + naturalElem.transform.lossyScale.y /2.0f , transform.position.z);
            NaturalElementInstance = Instantiate(naturalElement, naturalPlace, Quaternion.identity, transform);
            IsBuildable = false;

            Debug.Log(NaturalElementInstance.name + " is placed");
        }
    }

    public void RemoveNaturalElemt()
    {
        Destroy(NaturalElementInstance);
        IsBuildable = true;
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
