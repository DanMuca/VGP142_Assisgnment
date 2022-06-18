using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    bool Right = true;

    public float Timer;

    int MoveSpeed = 4;

    private void Start()
    {
        if (Timer == 0)
            Timer = 3;

        InvokeRepeating("Switch", 0f, Timer);
    }

    void Update()
    {
        if (Right == true)
        {
            transform.position += transform.right * MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.right * MoveSpeed * Time.deltaTime;
        }
    }

    void Switch()
    {
        Right = !Right;
    }
}
