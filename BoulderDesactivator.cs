using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
/// 
[RequireComponent(typeof(Collider))]
public class BoulderDesactivator : MonoBehaviour
{
    public Boulder boulder;

    public void Start()
    {
        EventManager.SubscribeToEvent(EventsType.DESACTIVATOR_TRIGGER, DesactivateBoulder);
    }
    public void DesactivateBoulder(params object[] parameterContainer)
    {
        Boulder boulder = (Boulder)parameterContainer[0];
        boulder.Reset();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        EventManager.TriggerEvent(EventsType.DESACTIVATOR_TRIGGER, boulder);
    }
}
