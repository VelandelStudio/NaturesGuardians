using UnityEngine;

public class SeedsGUI : Ressources {

    public override void AddElement(int i)
    {
        number += i;
        numberOfElement.text ="<b>" + number.ToString() + "</b>";
    }

    public override bool RemoveElement(int i)
    {
        if(number >= i)
        {
            number -= i;
            numberOfElement.text = "<b>" + number.ToString() + "</b>";
            return true;
        }

        return false;
    }
}
