using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModifier : MonoBehaviour
{
    public GameObject TileModifierPanel;
    private void Start()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        Transform[] trs = Canvas.GetComponentsInChildren<Transform>(true);
        for(int i = 0; i < trs.Length; i++)
        {
            if (trs[i].name == "TileModifierPanel")
            {
                TileModifierPanel = trs[i].gameObject;
            }
        }
    }

    public void DisplayTileModifier()
    {
        TileModifierPanel.SetActive(true);
    }

    public void DisableDisplayer()
    {
        TileModifierPanel.SetActive(false);
    }
}
