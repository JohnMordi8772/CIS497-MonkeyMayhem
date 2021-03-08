using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : PlayerDecorator
{

    public int pointsToAdd = 15;


    public override void AddPoints()
    {
        totalPoints += pointsToAdd;
    }
}
