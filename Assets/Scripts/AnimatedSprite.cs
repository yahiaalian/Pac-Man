using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites= new Sprite[0];
    public float AnimationTime = 0.25f;
    private int AnimationFrame;
    public bool loop = true;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled=false;
    }
    private void Start()
    {
        InvokeRepeating(nameof(Advance), AnimationTime, AnimationFrame);
    }   

    private void Advance()
    {
        if(!spriteRenderer.enabled)
        {
            return;
        }

        this.AnimationTime++;

        if(AnimationFrame >= sprites.Length && loop) 
        {
            AnimationFrame = 0;
        }

        if(AnimationFrame >= 0 && AnimationFrame < sprites.Length)
        {
            spriteRenderer.sprite= sprites[AnimationFrame];
        }
    }
    public void Restart()
    {
        AnimationFrame = -1;
        Advance();
    }
}
