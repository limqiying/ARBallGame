using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashController : MonoBehaviour
{
    Dictionary<string, Material> shaderDictionary;
    public Material highlightYellowMaterial;
    public Material highlightRedMaterial;

    void Start()
    {
        shaderDictionary = new Dictionary<string, Material>();
        RegisterOriginalColor();
    }


    public void RevertToOriginalColor()
    {
        ApplyToChildren((go) =>
        {
            go.GetComponent<Renderer>().material =
                shaderDictionary[go.name];
        }, transform);
    }

    public void HighlightYellow()
    {
        ApplyToChildren((go) =>
        {
            go.GetComponent<Renderer>().material = highlightYellowMaterial;
        }, transform);
    }

    public void HighlightRed()
    {
        ApplyToChildren((go) =>
        {
            go.GetComponent<Renderer>().material = highlightRedMaterial;
        }, transform);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void RegisterOriginalColor()
    {
        ApplyToChildren((go) =>
        {
            shaderDictionary[go.name] =
                go.GetComponent<Renderer>().material;
        }, transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash")
        {
            int otherAge = other.gameObject.GetComponent<BasketAge>().Age;
            int myAge = gameObject.GetComponent<BasketAge>().Age;
            if (myAge > otherAge)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void ApplyToChildren(Action<GameObject> action, Transform trans)
    {
        if (trans.childCount == 0 && trans.gameObject.CompareTag("BasketChild"))
        {
            action(trans.gameObject);
        }
        else
        {
            foreach (Transform child in trans)
            {
                ApplyToChildren(action, child);
            }
        }
    }
}
