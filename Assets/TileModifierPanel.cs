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
        gameObject.SetActive(true);
    }

    private void UpdateButtons()
    {
        CreateButton.interactable = workingObject && (workingObject.IsBuildable && GameManagement.instance.ObjToCreate != null);
        RotateRightButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RotateLeftButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RotateAroundButton.interactable = workingObject && (!workingObject.IsBuildable && workingObject.NaturalElementInstance);
        RemoveButton.interactable = workingObject && (workingObject.IsBuildable || workingObject.NaturalElementInstance);
        Debug.Log(workingObject);
    }
}
