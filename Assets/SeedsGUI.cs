using UnityEngine;

public class SeedsGUI : Ressources {

    public override void AddSeed(int i)
    {
        number += i;
        numberOfElement.text ="<b>" + number.ToString() + "</b>";
    }

    public override bool RemoveSeed(int i)
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
