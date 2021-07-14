using UnityEngine;
using System.Collections;

public class DamangerCollider : MonoBehaviour
{
    public int damage;
    public float knockback = 20f;
    public bool isLoadCheck = false;
    public bool isBoulder = false;
    public float secondsBeforeLoad = 0f;

    public void OnCollisionEnter(Collision collision)
    {
        if (isBoulder) return;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GetHit(damage);
            Knockback(collision);

            if(isLoadCheck == true)
            {
                collision.gameObject.GetComponent<Player>().LoadCheckPoint();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isBoulder == true && collision.gameObject.tag == "Player")
        {
            StartCoroutine(collision.gameObject.GetComponent<Player>().GetSmashedAndLoadCheckAfterSeconds(secondsBeforeLoad));
            return;

        }
    }

    public void Knockback(Collision collision)
    {
        Vector3 direction =collision.transform.position - transform.position;
        direction.y = 0.5f;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * knockback, ForceMode.Impulse);
    }

}
