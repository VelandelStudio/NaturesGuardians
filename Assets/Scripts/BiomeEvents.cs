using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BiomeEvents : MonoBehaviour {

    private NatureEvolution natureEvolution;

    UnityEvent animalPop;
    UnityEvent fireBurn;
    UnityEvent seedPop;

    private bool seedPopLaunched;

    private void Start()
    {
        natureEvolution = GameManagement.instance.NatureEvolution;

        if(animalPop == null)
        {
            animalPop = new UnityEvent();
            animalPop.AddListener(AnimalSpawning);
        }

        if (fireBurn == null)
        {
            fireBurn = new UnityEvent();
            fireBurn.AddListener(FireStart);
        }

        if (seedPop == null)
        {
            seedPop = new UnityEvent();
            seedPop.AddListener(SeedPop);
        }
    }

    private void Update()
    {
        if (natureEvolution.eventCondition[0] && animalPop != null)
        {
            animalPop.Invoke();
        }

        if (natureEvolution.eventCondition[1] && fireBurn != null)
        {
            fireBurn.Invoke();
        }

        if (natureEvolution.eventCondition[2] && seedPop != null && !seedPopLaunched)
        {
            seedPop.Invoke();
        }
    }

    void AnimalSpawning()
    {
        Debug.Log("Fox spawn in game");
    }

    void FireStart()
    {
        Debug.Log("A fire has start to Burn trees");
    }

    void SeedPop()
    {
        seedPopLaunched = true;
        InvokeRepeating("MakeASeedPop", 0f, 30f);
    }

    private void MakeASeedPop()
    {
        GameObject seed =(GameObject) Resources.Load("MagicSeed");
        Instantiate(seed, new Vector3(10, 1, 10), Quaternion.identity);
    }
}
