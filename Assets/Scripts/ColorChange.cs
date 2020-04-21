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
            StartCoroutine(goGreen(randTime));
        }

        if(isGreen == true)
        {
            StartCoroutine(goYellow(4f));
        }

        if(isYellow == true)
        {
            StartCoroutine(goRed(randTime));
        }
        
    }

    IEnumerator goGreen(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(time);
        isRed = false;
        isGreen = true;
    }

    IEnumerator goYellow(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.yellow);
        yield return new WaitForSeconds(time);
        isGreen = false;
        isYellow = true;
    }

    IEnumerator goRed(float time)
    {
        var lightRenderer = this.gameObject.GetComponent<Renderer>();
        lightRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(time);
        isYellow = false;
        isRed = true;
    }
}
