using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : PlayerDecorator
{
    public Score score;

    public Produce(Score score)
    {
        this.score = score;
    }

    public override int totalPoints
    {
        get
        {
            return score.totalPoints + 15;
        }
        set
        {
            score.totalPoints = value;
        }
    }

}
