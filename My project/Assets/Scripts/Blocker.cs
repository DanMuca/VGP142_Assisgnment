using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{

    public int TargetPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if (TargetPoints >= 2)
            Destroy(gameObject);
    }
}
