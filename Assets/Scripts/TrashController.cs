using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash")
        {
            int otherAge = other.gameObject.GetComponent<BasketAge>().Age;
            int myAge = gameObject.GetComponent<BasketAge>().Age;
            if (myAge > otherAge)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
