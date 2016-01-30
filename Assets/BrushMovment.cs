using UnityEngine;
using System.Collections;

public class BrushMovment : MonoBehaviour
{

    public int timer;
    private int timerStart;
    public int speed;
    // Use this for initialization
    void Start()
    {
        timerStart = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            timer = timerStart;
            speed *= -1;
        }
        transform.Translate(speed, 0, 0);
        timer--;
    }
}
