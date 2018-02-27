using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGUI : Ressources
{

    public override void AddElement(int i)
    {
        number += i;
        numberOfElement.text = "<b>" + number.ToString() + "</b>";
    }

    public override bool RemoveElement(int i)
    {
        if (number >= i)
        {
            number -= i;
            numberOfElement.text = "<b>" + number.ToString() + "</b>";
            return true;
        }

        return false;
    }
}
