using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeItem : ItemDisplayer
{
    protected void Awake()
    {
        TypeCost = "Seed";
        nbCost = 5;
    }

    protected override string GetDescription()
    {
        return "This is the first Tree of the game :D";
    }
}
