using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationItemButton : ToucheableElement
{
    protected GameObject objectToCreate;

    public override void ActionOnTouch()
    {
        Debug.Log(objectToCreate);
        GameManagement.instance.ObjToCreate = objectToCreate;
        GetComponentInParent<MenusBuildersDisplayer>().ActionOnTouch();
    }

    public void PassObjectToCreate(GameObject obj)
    {
        objectToCreate = obj;
    }

    public void Update()
    {
        Debug.Log(GameManagement.instance.InsideMenus);
    }

}
