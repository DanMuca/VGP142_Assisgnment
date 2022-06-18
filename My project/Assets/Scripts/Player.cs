using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    Raycast playerFire;

    [SerializeField]
    public Transform Gun;

    public bool isGrounded = false;
    public bool launch = false;

    public int MaxHealth = 100;
    public int CurrentHealth;
    public HealthBar healthbar;


    [Header("Player Settings")]
    [Space(2)]
    [Tooltip("speed value between 1 and 25")]
    [Range(1.0f, 25.0f)]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public float gravity;

    [Header("Weapon Settings")]
    public float projectileForce;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        CurrentHealth = MaxHealth;

        try
        {
            controller = GetComponent<CharacterController>();
            playerFire = GetComponent<Raycast>();
            controller.minMoveDistance = 0.0f;

            if (speed <= 0)
            {
                speed = 6.0f;
            }

            if (jumpSpeed <= 0)
            {
                jumpSpeed = 6.0f;
            }

            if (rotationSpeed <= 0)
            {
                rotationSpeed = 10.0f;
            }

            if (gravity <= 0)
            {
                gravity = 9.81f;
            }

            moveDirection = Vector3.zero;

            if (projectileForce <= 0)
            {
                projectileForce = 10.0f;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            Debug.Log("Always Gets Called");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //speed = 6.0f;
        }


        if (isGrounded == false)
        {
            
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;

            isGrounded = false;
        }

        if (launch == false) {}
        else
        {
            moveDirection.y = 45;

            launch = false;
        }


        moveDirection.y -= (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
            Fire();


        //test health button
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(25);
        }

        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Fire()
    {
        Debug.Log("pew pew pew");
        FireProjectile();
    }

    [ContextMenu("Reset Stats")]
    void ResetStats()
    {
        speed = 6.0f;
    }


    //on trigger ENTER

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            TakeDamage(25);

        if (other.gameObject.tag == "EnemyBullet")
            TakeDamage(25);

        if (other.gameObject.tag == "SlowAura")
            speed = 3.0f;

        if (other.gameObject.tag == "Teleporter")
        {
            Debug.Log("Tele");
            StartCoroutine("Teleport");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SlowAura")
            speed = 6.0f;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthbar.HealthSet(CurrentHealth);
    }
    public void Heal(int Heal)
    {
        CurrentHealth += Heal;

        healthbar.HealthSet(CurrentHealth);
    }

    void FireProjectile()
    {
        Rigidbody temp = Instantiate(projectilePrefab, Gun.position, Gun.rotation);
        //temp.AddForce(transform.forward * projectileForce, ForceMode.Impulse);

        Destroy(temp.gameObject, 2.0f);
    }
    IEnumerator Teleport()
    {
        controller.enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(811, 279, 538);
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;
    }
}
