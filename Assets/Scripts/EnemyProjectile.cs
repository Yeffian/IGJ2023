using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            LoseManager.Instance.FailPlayer(col.gameObject, 2);
        }
    }
}
