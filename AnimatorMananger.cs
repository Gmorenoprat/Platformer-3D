using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Gonzalo Moreno Prat
/// </summary>

public class AnimatorMananger 
{
    Player _player;
    Animator _anim;
    public AnimatorMananger(Player p)
    {
        _player = p;
        _anim = _player.GetComponent<Animator>();
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }

    public void Die()
    {
        _anim.SetBool("isDead", true);
    }

    public void GetHit()
    {
        _anim.SetTrigger("getHit");
    }

    public void Move(bool moviendo)
    {
        _anim.SetBool("Moving", moviendo);
    }
}
