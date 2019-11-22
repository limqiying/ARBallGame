using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
	private Mode _mode;
    public Mode CurrentMode
	{
		get
		{
			return _mode;
		}
        set
		{
			_mode = value;
		}
	}

    void Start()
	{
		_mode = Mode.SetUp;
	}

    public void SetUp()
    {
        _mode = Mode.SetUp;
    }

    public void Playing()
    {
        _mode = Mode.Playing;
    }
}
