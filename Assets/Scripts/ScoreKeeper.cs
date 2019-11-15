using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
	public int startScore;

    void Start()
	{
		startScore = 0;
	}

    public void AddOnePoint()
	{
		startScore++;
	}
}
