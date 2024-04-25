using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedmultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstaclelayer;
    public Rigidbody2D rigidbody1 {  get; private set; }
    public Vector2 direction {  get; private set; }
    public Vector2 nextdirection { get; private set; }
    public Vector3 statingpostion { get; private set; }


    public void Awake()
    {
        this.rigidbody1 = GetComponent<Rigidbody2D>();
        this.statingpostion=this.transform.position;
    }

    private void Start()
    {

    }

    public void ResetState()
    {
        this.speedmultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextdirection = Vector2.zero;
        this.transform.position = this.statingpostion;
        this.rigidbody1.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        if(this.nextdirection != Vector2.zero) 
        {
            SetDirection(this.nextdirection);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody1.position;
        Vector2 translation = this.direction * this.speed * this.speedmultiplier * Time.fixedDeltaTime;

        this.rigidbody1.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (!Occupied(direction))
        {
            this.direction = direction;
            this.nextdirection = Vector2.zero;
        }
        else
        {
            this.nextdirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstaclelayer);
        return hit.collider != null;
    }
}
