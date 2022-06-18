using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    Transform rayOrgin;

    public LayerMask CheckLayers;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrgin.transform.position, transform.forward, out hitInfo, 25.0f, CheckLayers))
        {
            Debug.Log("Hit : " + hitInfo.transform.gameObject.name);
        }

        Vector3 endPos = transform.forward * 25.0f;
        Debug.DrawRay(rayOrgin.transform.position, endPos, Color.red);
    }
}
