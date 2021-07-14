using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePot : Collectable
{
    public int hp = 1;
    public override void DarStats(Collider other)
    {
        other.gameObject.GetComponent<ICollector>().GetHp(this.hp);
    }
}
