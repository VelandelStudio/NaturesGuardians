using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

    public static GameManagement instance = null;

    public Ressources[] ressources;

    private GridCreator gridCreator;
    public GridCreator GridCreator
    {
        get { return gridCreator; }
    }

    private NatureEvolution natureEvolution;
    public NatureEvolution NatureEvolution
    {
        get { return natureEvolution; }
    }

    private GameObject objToCreate;
    public GameObject ObjToCreate
    {
        get { return objToCreate; }
        set { objToCreate = value; }
    }
    public string TypeCost;
    public int nbCost;

    private bool insideMenus = false;
    public bool InsideMenus
    {
        get { return insideMenus; }
        set { insideMenus = value; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }      
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        natureEvolution = GetComponent<NatureEvolution>();
    }

    private void Start()
    {
        gridCreator = GetComponentInChildren<GridCreator>();
        GameObject Canvas = GameObject.Find("Canvas");
        ressources = Canvas.GetComponentsInChildren<Ressources>();
        TypeCost = "Seed";
        nbCost = 5;
        AddResources();
        nbCost = 0;
    }

    public void AddResources()
    {
        if(TypeCost == "Seed")
        {
            for (int i = 0; i < ressources.Length; i++)
            {
                if(ressources[i] is SeedsGUI)
                {
                    Debug.Log("Hello");
                    ressources[i].AddSeed(nbCost);
                }
            }
        }
    }

    public bool RemoveResources()
    {
        if (TypeCost == "Seed")
        {
            for (int i = 0; i < ressources.Length; i++)
            {
                if (ressources[i] is SeedsGUI)
                {
                   return ressources[i].RemoveSeed(nbCost);
                }
            }
        }

        return true;
    }
}
