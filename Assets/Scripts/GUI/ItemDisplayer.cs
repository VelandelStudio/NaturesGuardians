using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemDisplayer : ToucheableElement
{

    [SerializeField] protected GameObject chevron;
    [SerializeField] protected Text description;
    [SerializeField] protected GameObject descriptionPanel;
    [SerializeField] protected GameObject GameObjectToInvoke;
    protected Button ItemButton;

    protected RessourcesConsummer RessourcesConsummer;
    public bool IsActivated = false;

    protected void Start()
    {
        ItemButton = GetComponent<Button>();
        RessourcesConsummer = GameObjectToInvoke.GetComponent<RessourcesConsummer>();
        chevron.SetActive(false);
        descriptionPanel.SetActive(false);
    }

    public override void ActionOnTouch()
    { 
        if(!IsActivated)
        {
            EnableItem();
        }
        else
        {
            DisableItem();
        }
    }

    protected void Update()
    {
        ItemButton.interactable = !RessourcesConsummer || GameManagement.instance.HasEnoughResources(RessourcesConsummer);
    }

    protected void EnableItem()
    {
        ItemDisplayer[] itemDisplayers = transform.parent.GetComponentsInChildren<ItemDisplayer>();
        for(int i = 0; i < itemDisplayers.Length; i++)
        {
            if(itemDisplayers[i] != this && itemDisplayers[i].IsActivated)
            {
                itemDisplayers[i].DisableItem();
            }
        }
        IsActivated = true;
        chevron.SetActive(true);
        description.text = GetDescription();
        descriptionPanel.GetComponentInChildren<CreationItemButton>().PassObjectToCreate(GameObjectToInvoke);
        descriptionPanel.SetActive(true);
    }

    public void DisableItem()
    {
        IsActivated = false;
        chevron.SetActive(false);
        description.text = "";
        descriptionPanel.GetComponentInChildren<CreationItemButton>().PassObjectToCreate(null);
        descriptionPanel.SetActive(false);
    }

    public GameObject GetGameObjectToInvoke()
    {
        return GetGameObjectToInvoke();
    }

    protected abstract string GetDescription();
}
