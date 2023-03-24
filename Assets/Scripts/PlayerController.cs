using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _playerRenderer;
    private SpriteRenderer _crosshairRenderer;
    private float _dimensionSwitchTime;
    
    public Camera Camera { get; set; }
    
    private static GameObject instance;
    
    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("GFX")] 
    [SerializeField] private GameObject crosshair;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        _crosshairRenderer = crosshair.GetComponent<SpriteRenderer>();
        
        Camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        _rb.gravityScale = 0.0f;
        
        // Ensure there is only one instance of the object in each scene
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ControlCrosshair();
        StartCoroutine(ControlScenes());
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        _rb.velocity = new Vector3(x, y, 0.0f);
    }

    IEnumerator ControlScenes()
    {
        int sceneIndex = 0;

        if (SceneManager.GetActiveScene().buildIndex == 1)
            sceneIndex = 2;
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            sceneIndex = 1;
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FindObjectOfType<SoundManager>().PlaySound("DimensionSwitch");
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);
            

            // restart timer
            DimensionTimer.Instance.ResetTimer();
            
            // Wait until the asynchronous scene fully loads
            while (!op.isDone)
            {
                yield return null;
            }
        }
        
        // change colour based on dimension
        _playerRenderer.color = sceneIndex == 2 ? Color.green : Color.magenta;
        _crosshairRenderer.color = sceneIndex == 2 ? Color.green : Color.magenta;
    }

    void ControlCrosshair()
    {
        Vector3 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
