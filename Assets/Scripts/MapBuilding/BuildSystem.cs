using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    private GameObject naturalElement;
    private GameObject NaturalElementInstance;
    private TileModifier tileModifier;

    private bool isBuildable;
    public bool IsBuildable
    {
        get { return !GameManagement.instance.InsideMenus && isBuildable; }
        set { isBuildable = value; }
    }

    private void Start()
    {
        IsBuildable = true;
        tileModifier = GetComponent<TileModifier>();
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        if (IsBuildable)
        {
            tileModifier.DisableDisplayer();
            Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + naturalElem.transform.lossyScale.y /2.0f , transform.position.z);
            NaturalElementInstance = Instantiate(naturalElement, naturalPlace, Quaternion.identity, transform);
            IsBuildable = false;

            Debug.Log(NaturalElementInstance.name + " is placed");
            Debug.Log(GameManagement.instance.NatureEvolution);

            GameManagement.instance.NatureEvolution.AddNatureElem(NaturalElementInstance);
            return;
        }

        if(!isBuildable && !GameManagement.instance.InsideMenus)
        {
            if (!tileModifier.TileModifierPanel.activeSelf)
            {
                tileModifier.DisplayTileModifier();
            }
        }
    }

    public void RemoveNaturalElemt()
    {
        GameManagement.instance.NatureEvolution.RemoveNatureElem(NaturalElementInstance);
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
