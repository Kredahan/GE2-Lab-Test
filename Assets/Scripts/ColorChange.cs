using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public bool isGreen = false;
    public bool isRed = false;
    public bool isYellow = false;
    GameObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randTime = Random.Range(5, 10);

        if(isRed == true)
        {
            isRed = false;
            StartCoroutine(goGreen(randTime));
        }

        else if(isGreen == true)
        {
            isGreen = false;
            StartCoroutine(goYellow(4f));
        }

        else if(isYellow == true)
        {
            isYellow = false;
            StartCoroutine(goRed(randTime));
        }
        
    }

    IEnumerator goGreen(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(time);
        isRed = false;
        isYellow = false;
        isGreen = true;
        yield break;
    }

    IEnumerator goYellow(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.yellow);
        yield return new WaitForSeconds(time);
        isGreen = false;
        isRed = false;
        isYellow = true;
        yield break;
    }

    IEnumerator goRed(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(time);
        isYellow = false;
        isGreen = false;
        isRed = true;
        yield break;
    }
}
