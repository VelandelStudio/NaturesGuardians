using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenusBuildersDisplayer : ToucheableElement {

    [SerializeField] protected GameObject associatedMenus;

    public override void ActionOnTouch()
    {
        ItemDisplayer[] itemsDisplayers = associatedMenus.GetComponentsInChildren<ItemDisplayer>();
        for(int i = 0; i < itemsDisplayers.Length; i++)
        {
            if(itemsDisplayers[i].IsActivated)
            {
                itemsDisplayers[i].DisableItem();
            }
        }
        associatedMenus.SetActive(!associatedMenus.activeSelf);
        GameManagement.instance.InsideMenus = (associatedMenus.activeSelf);

        MenusBuildersDisplayer[] menuDisplayers = transform.parent.GetComponentsInChildren<MenusBuildersDisplayer>();
        for (int i = 0; i < menuDisplayers.Length; i++)
        {
            if (menuDisplayers[i] != this)
            {
                menuDisplayers[i].DisableMenusDisplayer();
            }
        }
    }

    public void DisableMenusDisplayer()
    {
        ItemDisplayer[] itemsDisplayers = associatedMenus.GetComponentsInChildren<ItemDisplayer>();
        for (int i = 0; i < itemsDisplayers.Length; i++)
        {
            if (itemsDisplayers[i].IsActivated)
            {
                itemsDisplayers[i].DisableItem();
            }
        }
        associatedMenus.SetActive(false);
    }
}
