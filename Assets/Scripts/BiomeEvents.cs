using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BiomeEvents : MonoBehaviour {

    private NatureEvolution natureEvolution;

    UnityEvent animalPop;
    UnityEvent fireBurn;

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

    }

    void AnimalSpawning()
    {
        Debug.Log("Fox spawn in game");
    }

    void FireStart()
    {
        Debug.Log("A fire has start to Burn trees");
    }
}
