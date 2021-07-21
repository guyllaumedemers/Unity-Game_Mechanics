using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/StayInside")]
public class StayInsideRadiusBehaviour : FlockBehaviour
{
    Vector2 center;
    float radius = 15.0f;

    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        Vector2 center_offset = center - (Vector2)currAgent.transform.position;
        float t = center_offset.magnitude / radius;
        if (t < 0.9f)
        {
            return Vector2.zero;
        }
        return center_offset * t * t;
    }
}
