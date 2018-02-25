using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    public Material mat;

    public GameObject NaturalElementInstance
    {
        get; private set;
    }

    public bool IsTileBase
    {
        get {return transform.parent.GetComponentInParent<BuildSystem>() == null;  }
    }

    private TileModifier tileModifier;

    private bool isBuildable;
    public bool IsBuildable
    {
        get
        {
            bool isMaxHeigth = transform.position.y < GameManagement.instance.GridCreator.heigth;

            return !GameManagement.instance.InsideMenus && isBuildable && isMaxHeigth;
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

        if (NaturalElementInstance.tag == "Tree")
        {
            MeshRenderer mrd = GetComponent<MeshRenderer>();
            mrd.material = mat;
        }

        if(NaturalElementInstance.GetComponent<RessourcesConsummer>())
        {
            GameManagement.instance.RemoveResources(NaturalElementInstance.GetComponent<RessourcesConsummer>());
        }

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
            if (!IsTileBase)
            {
                transform.parent.GetComponentInParent<BuildSystem>().IsBuildable = true;
                GameManagement.instance.GridCreator.RemoveNewBuildSystem(transform);
                Destroy(transform.parent.gameObject);
            }
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
