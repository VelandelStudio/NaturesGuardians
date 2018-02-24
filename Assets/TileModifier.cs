using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModifier : MonoBehaviour
{
    private TileModifierPanel TileModifierPanel;

    private void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        TileModifierPanel[] modifiers = Canvas.GetComponentsInChildren<TileModifierPanel>(true);
        TileModifierPanel = modifiers[0];
        DisableDisplayer();
    }

    public void DisplayTileModifier(BuildSystem system)
    {
        TileModifierPanel.gameObject.SetActive(true);
        TileModifierPanel.EnablePanel(system);
    }

    public void DisableDisplayer()
    {
        TileModifierPanel.DisablePanel();
    }
}
