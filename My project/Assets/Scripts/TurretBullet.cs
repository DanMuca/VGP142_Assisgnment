using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{

    int MoveSpeed = 9;

    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
