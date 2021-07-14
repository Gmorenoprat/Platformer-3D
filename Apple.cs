using UnityEngine;

public class Apple : Collectable
{
    public override void DarStats(Collider other)
    {
        other.gameObject.GetComponent<ICollector>().GetApple();
    }
}
