using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : PlayerDecorator
{
    public Score score;

    public Containers(Score score)
    {
        this.score = score;
    }

    public override int totalPoints
    {
        get
        {
            return score.totalPoints + 50;
        }
        set
        {
            score.totalPoints = value;
        }
    }
}
