using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPot : Collectable
{
    public override void DarStats(Collider other)
    {
        other.gameObject.GetComponent<ICollector>().GetShield();

    }
}
