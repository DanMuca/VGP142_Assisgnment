using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform Player;

    [SerializeField]
    Rigidbody projectilePrefab;

    [SerializeField]
    Transform ProjSpawnPoint;

    int MaxDist = 20;
    bool InRange = false;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {

            transform.LookAt(Player);
            InRange = true;
        } 
        else
        {
            InRange = false;
        }
    }

    void Shoot()
    {
        if (InRange == true)
        {

        Rigidbody temp = Instantiate(projectilePrefab, ProjSpawnPoint.position, ProjSpawnPoint.rotation);

        Destroy(temp.gameObject, 4.0f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
            Destroy(gameObject);
    }
}
