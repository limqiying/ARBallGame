using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{

    public ScoreKeeper scoreKeeper;
   void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
		    scoreKeeper.AddOnePoint();
        }
	}
}
