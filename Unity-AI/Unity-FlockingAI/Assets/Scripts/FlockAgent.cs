using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public Flock MyFlock { get; private set; }

    //TODO Start by doing it like the tutorial than convert it to use a distance check instead
    public Collider2D AgentCollider { get; private set; }

    private void Awake() => AgentCollider = GetComponent<Collider2D>();

    public void InitializeFlock(Flock flock) => MyFlock = flock;

    public void Move(Vector2 pos)
    {
        transform.up = pos;
        transform.position += (Vector3)pos * Time.deltaTime;
    }
}
