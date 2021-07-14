using UnityEngine;

public class Shield : Collectable
{
    public override void DarStats(Collider other)
    {
        other.gameObject.GetComponent<ICollector>().GetShield();
    }
}
