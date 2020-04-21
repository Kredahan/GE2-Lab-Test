using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnTrafficLights : MonoBehaviour
{
    public int NoOfTrafficLights = 10;
    public GameObject[] TrafficLights; // An array of GameObjects that holds each traffic light
    public Vector3 carStartPoint;
    GameObject Car;

    // Start is called before the first frame update
    void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        carStartPoint = Car.transform.position;
        //carStartPoint = FindObjectOfType
        instantiateInCircle(TrafficLights, carStartPoint, NoOfTrafficLights);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //**public void instantiateInCircle(GameObject[] obj, Vector3 location, int NoLights)
    public void instantiateInCircle(GameObject[] obj, Vector3 location, int NoLights)
    {
        for (int i = 0; i < NoLights; i++)
        {
            float radius = NoLights; // ie: Radius == 10
            float angle = i * Mathf.PI * 2f / radius; // ex: 1 * 3.14 * 2f / 10
            //Vector3 newPos = transform.position + (new Vector3(Mathf.Cos(angle) * radius, -2, Mathf.Sin(angle) * radius));
            Vector3 newPos = location + (new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius));

            var lightRenderer = obj[i].GetComponent<Renderer>();
            int colorPicker = Random.Range(1, 4);

            if (colorPicker == 1)
            {
                lightRenderer.material.SetColor("_Color", Color.red);
                obj[i].GetComponent<ColorChange>().isRed = true;
            }
            else if (colorPicker == 2)
            {
                lightRenderer.material.SetColor("_Color", Color.green);
                obj[i].GetComponent<ColorChange>().isGreen = true;
            }
            else if (colorPicker == 3)
            {
                lightRenderer.material.SetColor("_Color", Color.yellow);
                obj[i].GetComponent<ColorChange>().isYellow = true;
            }

            Instantiate(obj[i], newPos, Quaternion.Euler(0, 0, 0));
        }
    }
}
