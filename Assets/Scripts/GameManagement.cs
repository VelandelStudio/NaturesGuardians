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
    }

    public void AddResources(RessourcesProvider provider)
    {
        if(provider.TypeCost == "Seed")
        {
            for (int i = 0; i < ressources.Length; i++)
            {
                if(ressources[i] is SeedsGUI)
                {
                    ressources[i].AddSeed(provider.ValueCost);
                }
            }
        }
    }

    public bool HasEnoughResources(RessourcesConsummer consummer)
    {
        if (consummer.TypeCost == "Seed")
        {
            for (int i = 0; i < ressources.Length; i++)
            {
                if (ressources[i] is SeedsGUI)
                {
                   return ressources[i].number >=  consummer.ValueCost;
                }
            }
        }

        return true;
    }

    public void RemoveResources(RessourcesConsummer consummer)
    {
        if (consummer.TypeCost == "Seed")
        {
            for (int i = 0; i < ressources.Length; i++)
            {
                if (ressources[i] is SeedsGUI)
                {
                   ressources[i].RemoveSeed(consummer.ValueCost);
                }
            }
        }
    }
}
