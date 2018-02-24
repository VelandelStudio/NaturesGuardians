using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

    public static GameManagement instance = null;

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
    }
}
