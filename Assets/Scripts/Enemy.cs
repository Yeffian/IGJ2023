using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyState
    {
        Following, Attacking
    }
    
    [Header("Control")]
    [SerializeField] private float speed;

    [Header("Behaviour")]
    [SerializeField] private float playerShootRadius;
    [SerializeField] private float force;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float waitTime;

    private Rigidbody2D _rb;
    private Vector2 moveDir;
    private EnemyState _state;
    private float _timer;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _state = EnemyState.Following;
        _timer = waitTime;
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player) return;
        
        // check distance from player
        _state = Vector3.Distance(transform.position, _player.position) < playerShootRadius 
            ? EnemyState.Attacking : EnemyState.Following;

        _timer -= Time.deltaTime;
        
        switch (_state)
        {
            case EnemyState.Following:
                FollowPlayer();
                break;
            case EnemyState.Attacking:
                AttackPlayer();
                break;
        }
    }

    private void Rotate(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
    
    private void FollowPlayer()
    {
        var position = transform.position;
        Vector3 dir = _player.position - position;
        Rotate(dir);
        
        moveDir = Vector3.Normalize(dir);
        _rb.MovePosition((Vector2)transform.position + (moveDir * (speed * Time.deltaTime)));
    }

    private void AttackPlayer()
    {
        var position = transform.position;
        Vector3 dir = _player.position - position;
        Rotate(dir);

        if (_timer <= 0.0f)
        {
            ShootPlayer();
            _timer = waitTime;
        }
    }

    private void ShootPlayer()
    {
        GameObject firedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

        var rb = firedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
        
        Destroy(firedBullet, 10.0f);
    }
}
