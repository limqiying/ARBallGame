using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash")
        {
            int otherAge = other.gameObject.GetComponent<BasketAge>().Age;
            int myAge = gameObject.GetComponent<BasketAge>().Age;
            if (myAge < otherAge)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }
    }
}
