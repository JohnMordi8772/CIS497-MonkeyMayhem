using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : PlayerDecorator
{
    public static int pointsToAdd = 10;

    public override void AddPoints()
    {
        totalPoints += pointsToAdd;
    }
}
