using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
/// 
[RequireComponent(typeof(Collider))]
public class BoulderActivator : MonoBehaviour
{
    public Boulder boulder;

    public void Start()
    {
        EventManager.SubscribeToEvent(EventsType.ACTIVATOR_TRIGGER, ActivateBoulder);
    }
    public void ActivateBoulder(params object[] parameterContainer)
    {
        Boulder boulder = (Boulder)parameterContainer[0];
        boulder.Activate();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        EventManager.TriggerEvent(EventsType.ACTIVATOR_TRIGGER, boulder);
    }
}
