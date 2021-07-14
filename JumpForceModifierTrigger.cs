using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
[RequireComponent(typeof(Collider))]
public class JumpForceModifierTrigger : MonoBehaviour
{
    public float modifiedJumpForce = 7f;
    public void Start()
    {
        EventManager.SubscribeToEvent(EventsType.JUMPFORCE_MODIFIER, modifyJumpForce);
    }
    public void modifyJumpForce(params object[] parameterContainer)
    {
        Player player = (Player)parameterContainer[0];
        player.ChangeJumpForce((float)parameterContainer[1]);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) { return; }
        EventManager.TriggerEvent(EventsType.JUMPFORCE_MODIFIER, other.GetComponent<Player>(), modifiedJumpForce );
    }
    public void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Player>()) { return; }
        Player player = other.GetComponent<Player>();
        EventManager.TriggerEvent(EventsType.JUMPFORCE_MODIFIER, player, player.baseJumpForce);
    }
}
