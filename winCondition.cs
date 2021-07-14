using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    public GameObject winMenu, buttons;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().enabled = false;

            winMenu.gameObject.SetActive(true);

            StartCoroutine(mostrarBotones());
        }
    }

    public IEnumerator mostrarBotones()
    {
        yield return new WaitForSeconds(10);
        buttons.gameObject.SetActive(true);
        yield return null;
    }
}
