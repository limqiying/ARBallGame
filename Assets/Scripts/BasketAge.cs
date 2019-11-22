using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketAge : MonoBehaviour
{
    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }

        set
        {
            _age = value;
        }
    }

    private void Start()
    {
        _age = 0;
    }
}
