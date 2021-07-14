using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipEffect : MonoBehaviour
{
    public float _slipForce;

    public void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(this.transform.right * -1 * _slipForce, ForceMode.VelocityChange);
        }
    }
}
