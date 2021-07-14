using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleSheel : Enemy
{

    public Transform pos1, pos2;

    public override void Move()
    {
        if (canMove)
            transform.position += speed * Time.deltaTime * transform.forward;

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject == pos1.gameObject)
        {
            this.transform.LookAt(pos2);
        }
        if (other.gameObject == pos2.gameObject)
        {
            this.transform.LookAt(pos1);
        }
    }
    void Update()
    {
        Move();
    }

    //Debug
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}
