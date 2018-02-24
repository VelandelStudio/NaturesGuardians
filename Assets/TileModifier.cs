using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModifier : MonoBehaviour
{
    public TileModifierPanel TileModifierPanel;
    private void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        TileModifierPanel[] modifiers = Canvas.GetComponentsInChildren<TileModifierPanel>(true);
        TileModifierPanel = modifiers[0];
        DisableDisplayer();
    }

    public void DisplayTileModifier(BuildSystem system)
    {
        Debug.Log("hello");
        TileModifierPanel.gameObject.SetActive(true);
        TileModifierPanel.EnablePanel(system);
    }

    public void DisableDisplayer()
    {
        TileModifierPanel.DisablePanel();
    }
}
