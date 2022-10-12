using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class StatModifier
{
    public string Name;
    public int Value;

    public StatModifier(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public string getName() { return Name; }
    public int getValue() { return Value; }
}