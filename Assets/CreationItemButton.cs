using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationItemButton : ToucheableElement
{
    protected GameObject objectToCreate;

    public override void ActionOnTouch()
    {
        //GameManagement.instance.ObjToCreate = objectToCreate;
    }

    public void PassObjectToCreate(GameObject obj)
    {
        objectToCreate = obj;
    }

}
