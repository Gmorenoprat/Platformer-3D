using UnityEngine;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
[RequireComponent(typeof(Collider))]
public class SpeedModifierTrigger : MonoBehaviour
{
    public float modifiedSpeed = 3.5f;
    public void Start()
    {
        EventManager.SubscribeToEvent(EventsType.SPEED_MODIFIER, ModifySpeed);
    }
    public void ModifySpeed(params object[] parameterContainer)
    {
        Player player = (Player)parameterContainer[0];
        player.ChangeMovementSpeed((float)parameterContainer[1]);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Player>()) { return; }
        EventManager.TriggerEvent(EventsType.SPEED_MODIFIER,other.GetComponent<Player>(), modifiedSpeed);
    }
    public void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Player>()) { return; }
        Player player = other.GetComponent<Player>();
        EventManager.TriggerEvent(EventsType.SPEED_MODIFIER, player, player.baseSpeed);
    }
}
