using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<SoundManager>().PlaySound("PlayerShoot");
            Shoot();   
        }
    }

    void Shoot()
    {
        GameObject firedBullet = Instantiate(bullet, transform.position, transform.rotation);
        
        var rb = firedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        
        Destroy(firedBullet, 15.0f);
    }
}
