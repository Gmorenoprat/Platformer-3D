using UnityEngine;

public class Heart : Collectable
{
    private int hp = 1;
    public override void DarStats(Collider other)
    {
        other.gameObject.GetComponent<ICollector>().GetHp(this.hp);
    }
}
