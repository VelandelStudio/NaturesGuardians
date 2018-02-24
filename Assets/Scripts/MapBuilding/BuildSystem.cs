using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    private GameObject naturalElement;
    private GameObject naturalElementInstance;
    public GameObject NaturalElementInstance
    {
        get; private set;
    }

    private TileModifier tileModifier;

    private bool isBuildable;
    public bool IsBuildable
    {
        get
        {
            bool isMaxHeigth = transform.position.y < GameManagement.instance.GridCreator.heigth;

            return !GameManagement.instance.InsideMenus && isBuildable && isMaxHeigth && !NaturalElementInstance;
        }

        set { isBuildable = value; }
    }

    private void Start()
    {
        IsBuildable = true;
        tileModifier = GetComponent<TileModifier>();
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + naturalElem.transform.lossyScale.y /2.0f , transform.position.z);
        NaturalElementInstance = Instantiate(naturalElem, naturalPlace, Quaternion.identity, transform);
        IsBuildable = false;

        GameManagement.instance.NatureEvolution.AddNatureElem(NaturalElementInstance);

        if (NaturalElementInstance.GetComponentInChildren<BuildSystem>())
        {
            GameManagement.instance.GridCreator.AddNewBuildSystem(NaturalElementInstance.transform);
        }
    }

    public void RemoveNaturalElemt()
    {
        if (NaturalElementInstance)
        {
            GameManagement.instance.NatureEvolution.RemoveNatureElem(NaturalElementInstance);
            Destroy(NaturalElementInstance);
            isBuildable = true;
        }
        else
        {
            transform.parent.GetComponent<BuildSystem>().NaturalElementInstance = null;

            Destroy(gameObject);
        }

        tileModifier.DisableDisplayer();
    }

    public override void ActionOnTouch()
    {
        if (IsBuildable || (!isBuildable && !GameManagement.instance.InsideMenus))
        {
            tileModifier.DisplayTileModifier(this);
        }
    }
}
