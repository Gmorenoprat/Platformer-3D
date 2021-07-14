using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    protected Rigidbody _rb;
    public float speed = 1f;
    public bool canMove = true;
    public Animator anim;
    AudioSource _dieSound;

    public void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _dieSound = this.GetComponent<AudioSource>();
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerAttack") { Die(collision.transform); canMove = false; }
    }

    public  abstract void Move();
    public void Die(Transform tr)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        Vector3 direction = transform.position - tr.position ;
        direction.y = 0.1f;
        anim.SetTrigger("Death");
        _rb.AddForce(direction.normalized * 20f, ForceMode.Impulse);
        _dieSound.Play();
        Destroy(this.gameObject, 2f);
    }


}
