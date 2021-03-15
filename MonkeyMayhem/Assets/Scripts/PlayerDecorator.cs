/*
 * Luke Alcazar, John Mordi
 * PlayerDecorator.cs
 * Project 2
 * abstract class for the decorators of score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDecorator : Score
{

    public override abstract int totalPoints { get; set; }
}
