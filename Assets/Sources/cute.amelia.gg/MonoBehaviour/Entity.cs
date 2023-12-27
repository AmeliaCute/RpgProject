using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Statistic health = new(100, 0);
    public Statistic attack = new(4, 0);
    public Statistic speed = new(10, 0);
    public Statistic defense = new(10, 0);
    public List<ItemInstance> inventory;
    public int level = 10;


}