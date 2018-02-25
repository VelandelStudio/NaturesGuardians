using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileModifierPanel : MonoBehaviour {

    private BuildSystem workingObject;
    [SerializeField] private Button CreateButton;
    [SerializeField] private Button RotateRightButton;
    [SerializeField] private Button RotateLeftButton;
    [SerializeField] private Button RotateAroundButton;
    [SerializeField] private Button RemoveButton;

    public void Rotate(float angle)
    {
        workingObject.NaturalElementInstance.transform.Rotate(Vector3.up, angle);
        UpdateButtons();
    }

    public void Remove()
    {
        workingObject.RemoveNaturalElemt();
        UpdateButtons();
        DisablePanel();
    }

    public void Create()
    {
        workingObject.TryPlaceNaturalElem(GameManagement.instance.ObjToCreate);
        UpdateButtons();
    }

    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }


    public void EnablePanel(BuildSystem system)
    {
        workingObject = system;
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        GameObject objToCreate = GameManagement.instance.ObjToCreate;
        CreateButton.interactable = workingObject && (workingObject.IsBuildable && GameManagement.instance.ObjToCreate != null
                                    && GameManagement.instance.HasEnoughResources(objToCreate.GetComponent<RessourcesConsummer>()));
        RotateRightButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RotateLeftButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RotateAroundButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RemoveButton.interactable = workingObject && !workingObject.IsTileBase
                                 || (workingObject.IsTileBase && !workingObject.IsBuildable);

        if(!CreateButton.interactable &&
           !RotateRightButton.interactable &&
           !RotateLeftButton.interactable &&
           !RotateAroundButton.interactable &&
           !RemoveButton.interactable)
        {
            DisablePanel();
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
