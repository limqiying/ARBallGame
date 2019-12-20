using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeight : MonoBehaviour
{
    public GameMode gameMode;
    GameObject selectedObject;
    Vector2 prevPos;
    float timePassed;

    void Update()
    {

        if (Input.touchCount > 0 && gameMode.CurrentMode == Mode.SetUp)
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    prevPos = touch.position;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit2;
                    timePassed = 0.0f;
                    if (Physics.Raycast(ray, out hit2))
                    {
                        selectedObject = hit2.collider.gameObject;
                        if (isBasket())
                        {
                            selectedObject.GetComponent<TrashController>().HighlightYellow();
                        }
                    }
                    break;

                case TouchPhase.Stationary:
                    timePassed += Time.deltaTime;
                    if (timePassed > 2.0f && isBasket())
                    {
                        selectedObject.GetComponent<TrashController>().HighlightRed();
                        selectedObject.GetComponent<TrashController>().DestroyObject();
                    }
                    break;

                case TouchPhase.Moved:
                    if (isBasket())
                    {
                        float xDirection = (touch.position - prevPos).x;
                        float yDirection = (touch.position - prevPos).y;
                        prevPos = touch.position;

                        if (Mathf.Abs(xDirection) < Mathf.Abs(yDirection))  
                        {
                            // translate the basket vertically
                            selectedObject.transform.Translate(new Vector3(0, yDirection * 0.001f, 0));
                        }
                        else
                        {
                            // rotate the basket
                            selectedObject.transform.Rotate(new Vector3(0, -1 * xDirection, 0));
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (isBasket())
                    {
                        selectedObject.GetComponent<TrashController>().RevertToOriginalColor();
                        selectedObject = null;
                    }
                    break;
            }
        }
    }

    private bool isBasket()
    {
        return selectedObject.CompareTag("Trash");
    }
} 
