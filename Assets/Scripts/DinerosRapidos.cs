using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DinerosRapidos : MonoBehaviour
{
    public DineroRapido[] dinerosRapidos;
    private System.Random random = new System.Random();

    public DineroRapido getDineroRapidoRandom()
    {
        int x = random.Next(0,dinerosRapidos.Length);
        while (!dinerosRapidos[x].esUsable())
        {
            x = random.Next(0,dinerosRapidos.Length);
        }
        dinerosRapidos[x].setUsable(false);
        return dinerosRapidos[x];
    }
}
