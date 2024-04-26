using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ghosts))]
public class GhostBehavior : MonoBehaviour
{
    public Ghosts ghost {  get; private set; }
    public float duration;
    private void Awake()
    {
        this.ghost = GetComponent<Ghosts>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(this.duration);
    }

    public virtual void Enable(float duration)
    {
        this.enabled=true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }
    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();
    }
}
