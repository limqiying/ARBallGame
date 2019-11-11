using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Camera firstPersonCamera;
    Touch touch;

    void Update()
    {
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = firstPersonCamera.transform.TransformPoint(0, 0, 0.5f);
        ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        ball.AddComponent<Rigidbody>();
        ball.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        ball.GetComponent<Rigidbody>().AddForce(firstPersonCamera.transform.TransformDirection(0, 1f, 2f), ForceMode.Impulse);

    }
}
