using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

            FindObjectOfType<SoundManager>().PlaySound("EnemyHit");
            VCamShake.Instance.Shake(4.5f, 0.3f);
        }
    }
}
