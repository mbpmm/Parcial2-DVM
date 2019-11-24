using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletEmitter;
    public float nextFire;
    public float fireRate;
    public int ammo;
    public int HP;

    public LayerMask rayCastLayer;
    public float rayDistance;

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRot = 0f;

    public CharacterController controller;
    public float speed;
    public float gravity=-9.81f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask ground;

    Vector3 vel;
    public bool isGrounded;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if (isGrounded && vel.y < 0)
        {
            vel.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        vel.y += gravity * Time.deltaTime;

        controller.Move(vel * Time.deltaTime);

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
                ammo--;
            }
        }
#endif


#if UNITY_ANDROID
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.left * 20, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "Enemies":
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Shoot();
                        ammo--;
                    }
                    break;
                case "Ammo":
                    if (ammo<100f)
                    {
                        ammo += 15;
                    }
                    hit.transform.gameObject.SetActive(false);
                    break;
                case "HP":
                    if (HP<100f)
                    {
                        HP += 10;
                    }
                    hit.transform.gameObject.SetActive(false);
                    break;
            }

        }
#endif

        if (HP<=0)
        {
            HP = 0;
            isDead = true;
        }
    }

    public void Shoot()
    {
        GameObject b = ObjectPool.instance.GetPooledObject("Bullet");
        b.transform.position = bulletEmitter.transform.position;
        b.transform.rotation = bulletEmitter.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Zombie" || collision.gameObject.tag == "Vampire")
        {
            HP -= 10;
        }
#if UNITY_STANDALONE
        if (collision.gameObject.tag == "Ammo")
        {
            collision.gameObject.SetActive(false);
            if (ammo < 100f)
            {
                ammo += 15;
            }
        }
        if (collision.gameObject.tag == "HP")
        {
            collision.gameObject.SetActive(false);
            if (HP<100f)
            {
                HP += 10;
            }
        }
#endif
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "Vampire")
        {
            HP -= 10;
        }
    }
}
