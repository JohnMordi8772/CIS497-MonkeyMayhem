/*
 * Luke Alcazar, John Mordi
 * Score.cs
 * Project 2
 * holds players points, using decorator pattern
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public virtual int totalPoints { get; set; } = 0;
}
