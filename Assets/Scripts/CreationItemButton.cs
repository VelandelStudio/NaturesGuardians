using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationItemButton : ToucheableElement
{
    protected GameObject objectToCreate;
    protected int nbCost;
    protected string typeCost;

    public override void ActionOnTouch()
    {
        Debug.Log(objectToCreate);
        GameManagement.instance.ObjToCreate = objectToCreate;
        GameManagement.instance.nbCost = nbCost;
        GameManagement.instance.TypeCost = typeCost;

        GetComponentInParent<MenusBuildersDisplayer>().ActionOnTouch();
    }

    public void PassObjectToCreate(GameObject obj, int nbCost, string typeCost)
    {
        objectToCreate = obj;
        this.nbCost = nbCost;
        this.typeCost = typeCost;
    }
}
