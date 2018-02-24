using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ToucheableElement {

    public Material greenMat;
    public Material snowMat;

    private GameObject naturalElement;
    private float altitude;

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

            return !GameManagement.instance.InsideMenus && isBuildable && isMaxHeigth;
        }

        set { isBuildable = value; }
    }

    private void Start()
    {
        IsBuildable = true;
        altitude = transform.position.y;
        tileModifier = GetComponent<TileModifier>();
    }

    public void TryPlaceNaturalElem(GameObject naturalElem)
    {
        Vector3 naturalPlace = new Vector3(transform.position.x, transform.position.y + naturalElem.transform.lossyScale.y /2.0f , transform.position.z);
        NaturalElementInstance = Instantiate(naturalElem, naturalPlace, Quaternion.identity, transform);
        IsBuildable = false;

        GameManagement.instance.NatureEvolution.AddNatureElem(NaturalElementInstance);

        MatModifier();

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
            transform.parent.GetComponentInParent<BuildSystem>().IsBuildable = true;
            GameManagement.instance.GridCreator.RemoveNewBuildSystem(transform);
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

    public void MatModifier()
    {
        MeshRenderer mrd = GetComponent<MeshRenderer>();

        if (NaturalElementInstance.tag == "Tree")
        {
            mrd.material = greenMat;
        }

        if (altitude >= 5)
        {
            mrd.material = snowMat;
        }
    }
}
