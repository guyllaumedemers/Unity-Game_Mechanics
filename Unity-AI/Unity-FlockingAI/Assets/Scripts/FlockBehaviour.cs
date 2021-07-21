using System.Collections.Generic;
using UnityEngine;

// Component
public abstract class FlockBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock);
}
