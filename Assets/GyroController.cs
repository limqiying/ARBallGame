using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    private Gyroscope gyro;

    public bool GyroEnabled { get; set; }

    void Start()
    {
        GyroEnabled = EnableGyro();
    }

    // Update is called once per frame
    public Vector3 GetGravityDirection()
    {
        if (GyroEnabled)
        {
            return gyro.gravity;
        }
        return new Vector3();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }
}
