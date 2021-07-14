using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isFalling = false;
    public float downSpeed;

    void Update()
    {
        Move();
    }
    public void Activate()
    {
        isFalling = true;
    }
    public void Move()
    {
        if (isFalling)
            transform.position += downSpeed * Time.deltaTime * Vector3.down;
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
