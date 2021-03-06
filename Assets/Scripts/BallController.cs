
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    public GameObject particle;
    public bool started;
    public bool gameOver;

    void Awake() {

        rb = GetComponent<Rigidbody> ();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, 1f, 0);

            Camera.main.GetComponent<camerafollows> ().gameOver = true;
        }
    
        if (Input.GetMouseButtonDown (0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "diamonds")
        {
            Destroy(col.gameObject);
        }
    }
}
