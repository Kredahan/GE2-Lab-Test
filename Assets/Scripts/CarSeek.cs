using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSeek : MonoBehaviour
{
    public LightState[] lightStates; // An array that holds all the lights coordinates, as well as a boolean value that determines whether
    //they are currently green or not
    public GameObject MovingCar;
    public float speed;
    public bool loopCompleted;
    // Start is called before the first frame update
    void Start()
    {
        loopCompleted = false;
        lightStates = new LightState[10];
    }

    // Update is called once per frame
    void Update()
    {
        if(loopCompleted == false)
        {
            loopCompleted = true;
            seekGreen();
            loopCompleted = false;
        }
    }

    public void seekGreen()
    {
        float step = speed * Time.deltaTime;
        for (int i = 0; i < 10; i++)
        {
            if(lightStates[i].GreenToGo == true)
            {
                MovingCar.transform.position = Vector3.MoveTowards(transform.position, lightStates[i].greenLightPos, step);
            }
        }
    }

    public void addToArray(int num, bool green, Vector3 position)
    {
        lightStates[num] = new LightState();
        lightStates[num].GreenToGo = green;
        lightStates[num].greenLightPos = position;
    }
}
