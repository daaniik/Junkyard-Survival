using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDing : MonoBehaviour
{
    public A[] hierKanEenAIn;
    // Start is called before the first frame update
    void Start()
    { 
        foreach(A a in hierKanEenAIn)
        {
            a.WhatAmI();
        }
    }
}
