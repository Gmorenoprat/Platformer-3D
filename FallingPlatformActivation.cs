using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformActivation : MonoBehaviour
{
    public FallingPlatform fallingPlatform;

    public void Start()
    {
        EventManager.SubscribeToEvent(EventsType.MOVINGPLATFORM_TRIGGER, ActivateFallingPlatform);
    }
    public void ActivateFallingPlatform(params object[] parameterContainer)
    {
        FallingPlatform fallingPlatform = (FallingPlatform)parameterContainer[0];
        fallingPlatform.Activate();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        EventManager.TriggerEvent(EventsType.MOVINGPLATFORM_TRIGGER, fallingPlatform);
    }
}
