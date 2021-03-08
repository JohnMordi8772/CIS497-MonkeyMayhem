using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDecorator : Score
{

    public override abstract int totalPoints { get; set; }
}
