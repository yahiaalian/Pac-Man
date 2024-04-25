
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

    private void FixedUpdate()
    {

    }
}
