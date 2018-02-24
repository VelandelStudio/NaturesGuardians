using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSeed : ToucheableElement {

    private float lastOnScreen = 5.0f;

    private void Start()
    {
        Invoke("DestroyELement", lastOnScreen);
    }

    private void DestroyELement()
    {
        Destroy(gameObject);
    }

    public override void ActionOnTouch()
    {
        GameManagement.instance.nbCost = 1;
        GameManagement.instance.TypeCost = "Seed";

        GameManagement.instance.AddResources();
        DestroyELement();
    }
}
