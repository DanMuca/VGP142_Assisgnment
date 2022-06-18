using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    int MoveSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * MoveSpeed * Time.deltaTime;
    }
}
