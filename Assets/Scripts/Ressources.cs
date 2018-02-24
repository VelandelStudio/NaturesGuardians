using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ressources : MonoBehaviour {

    [SerializeField] protected Text numberOfElement;
    public int number;

    public abstract void AddSeed(int i);
    public abstract bool RemoveSeed(int i);
}
