using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGroundCheck : MonoBehaviour
{
    [SerializeField]
    Transform rayOrgin;

    public LayerMask CheckLayers;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrgin.transform.position, -transform.up, out hitInfo, 0.7f, CheckLayers))
        {
            Debug.Log("Hit : " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.gameObject.layer == 3)
            {
                player.isGrounded = true;
            }
            if (hitInfo.transform.gameObject.layer == 6)
            {
                player.TakeDamage(100);
            }
            if (hitInfo.transform.gameObject.layer == 7)
            {
                player.launch = true;
            }
        }

        Vector3 endPos = -transform.up * 0.7f;
        Debug.DrawRay(rayOrgin.transform.position, endPos, Color.green);
    }
}
