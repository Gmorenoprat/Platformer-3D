using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEffect : MonoBehaviour
{
    Animation Anim;
    AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animation>();
        _audio = this.GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerAttack")
        {
            //Anim.SetTrigger("Rotation Active");
            _audio.Play();
            Anim.Play("rotationActive");
        }
    }
}
