using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    public float lifetime;
    public GameMode mode;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (mode.CurrentMode != Mode.SetUp)
        {
            Destroy(gameObject);
        }
    }
}
