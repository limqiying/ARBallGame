using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ThrowBall : MonoBehaviour
{
    public Camera firstPersonCamera;
    public GameObject ballPrefab;
    public List<Material> materials;
    public GameMode gameMode;
    public System.Random random;
    public LeanFingerSwipe swipe;
    public AudioClip throwSound;

    private void Start()
    {
        random = new System.Random();
        swipe = GetComponent<LeanFingerSwipe>();
        swipe.OnFinger.AddListener(ThrowABall);
        
    }

    private void ThrowABall(LeanFinger finger)
    {
        if (gameMode.CurrentMode == Mode.Playing)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = firstPersonCamera.transform.TransformPoint(0, 0, 0.5f);
            ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            ball.GetComponent<SphereController>().delay = 10;
            ball.GetComponent<Renderer>().material = materials[random.Next(0, 5)];

            float distance = Vector2.Distance(finger.StartScreenPosition, finger.LastScreenPosition);
            float force = GetForce(distance);
            ball.GetComponent<Rigidbody>().AddForce(firstPersonCamera.transform.TransformDirection(0, force, force), ForceMode.Impulse);
        }
    }

    public void PlayAudio()
    {
        if (gameMode.CurrentMode == Mode.Playing)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(throwSound);
        }
    }

    private float GetForce(float value)
    {
        float tempVal =  value / 135.0f;
        if (tempVal > 3.0f)
        {
            return 3.0f;
        }
        else
        {
            return Mathf.Round(tempVal * 10.0f) / 10.0f;
        }
    }

}
