using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public string objName;
    public int number;


    public void Test()
    {
        print("Ik werk.");
    }

    public virtual void WhatAmI()
    {
        print("A");
    }
}
