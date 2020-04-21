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
        instantiateInCircle(TrafficLights,carStartPoint,NoOfTrafficLights); // Passing in the Traffic Light array, the start position and the number of lights
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateInCircle(GameObject[] obj, Vector3 location, int NoLights)
    {
        for (int i = 0; i < NoLights; i++)
        {
            float radius = NoLights; // ie: Radius == 10
            float angle = i * Mathf.PI * 2f / radius; // ex: 1 * 3.14 * 2f / 10
            //Vector3 newPos = transform.position + (new Vector3(Mathf.Cos(angle) * radius, -2, Mathf.Sin(angle) * radius));
            Vector3 newPos = location + (new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius));
            Instantiate(obj[i], newPos, Quaternion.Euler(0, 0, 0));
        }
    }
}
