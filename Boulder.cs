using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
[RequireComponent(typeof(DamangerCollider))]
public class Boulder : MonoBehaviour
{

    private Rigidbody _rb;
    public originalPosition _originalPos;

    public float speed = -100f;
    public float maxSpeed = 8f;
    public bool canMove = false;

    AudioSource _movingSound;

    public void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _movingSound = this.GetComponent<AudioSource>();
        _originalPos.originalPos = this.transform.position;
        _originalPos.originalRot= this.transform.rotation;

    }
    void Update()
    {
        LimitateVelocity();
    }
    public void Activate()
    {
        canMove = true;
        Move();
    }

    public void Reset()
    {
        canMove = false;
        _rb.velocity = new Vector3();
        _rb.angularVelocity = new Vector3();
        this.transform.position = _originalPos.originalPos;
        this.transform.rotation = _originalPos.originalRot;
    }
    public void Move() {
        if (!canMove) return;
            _rb.AddForce(Vector3.forward * speed);
    }

    void LimitateVelocity()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

}

public struct originalPosition
{
    public Vector3 originalPos;
    public Quaternion originalRot;
}
