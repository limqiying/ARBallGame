using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

    public float delay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scoreCounter"))
        {
            //gameObject.SetActive(false);
            StartCoroutine(MakeDisappear(delay));
        }
    }

    IEnumerator MakeDisappear(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Destroy(gameObject);
    }

}
