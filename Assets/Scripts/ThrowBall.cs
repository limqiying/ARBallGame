using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Camera firstPersonCamera;
    public GameObject ballPrefab;
    public List<Material> materials;
    public System.Random random;

    private void Start()
    {
        random = new System.Random();
    }

    public void ThrowButtonPressed()
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.position = firstPersonCamera.transform.TransformPoint(0, 0, 0.5f);
        ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        ball.GetComponent<SphereController>().delay = 3.0f;
        ball.GetComponent<Renderer>().material = materials[random.Next(0, 5)];
        ball.GetComponent<Rigidbody>().AddForce(firstPersonCamera.transform.TransformDirection(0, 1f, 2f), ForceMode.Impulse);
    }

}
