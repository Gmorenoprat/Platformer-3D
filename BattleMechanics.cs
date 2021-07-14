using UnityEngine;

public class BattleMechanics 
{
    Player _player;
    public BattleMechanics(Player p)
    {
        _player = p;
    }

    public void Attack()
    {
        if (!_player.CanAttack) return;
        _player.CanAttack = false;
        _player.ResetTimerAttack();
        _player.AttackRange.enabled = true;

    }

}
