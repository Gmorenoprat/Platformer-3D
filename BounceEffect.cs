using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public float _jumpForce;
    public AudioSource _audio;


    private void Start()
    {
        _audio = this.GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _audio.Play();
        }
        
    }
}
