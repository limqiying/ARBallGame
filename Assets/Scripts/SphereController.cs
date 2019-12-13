using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

    public int delay;
    private int lifeTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scoreCounter"))
        {
            lifeTime = delay;
            StartCoroutine(MakeDisappear());
        }
    }

    IEnumerator MakeDisappear()
    {
        yield return new WaitForSeconds(1.0f);
        lifeTime--;
        CheckToDestroy();
    }

    private void CheckToDestroy()
    {
        if (lifeTime == 0)
        {
            Destroy(gameObject);
        }
    }

}
