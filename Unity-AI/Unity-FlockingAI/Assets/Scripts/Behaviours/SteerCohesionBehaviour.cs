using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/SteerCohesion")]
public class SteerCohesionBehaviour : FlockBehaviour
{
    Vector2 current_velocity;
    float agent_smoothTime = 0.5f;

    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (context.Count <= 0) return Vector2.zero;
        else
        {
            Vector2 cohesionMove = new Vector2();
            foreach (var item in context)
            {
                cohesionMove += (Vector2)item.position;
            }
            cohesionMove /= context.Count;
            cohesionMove -= (Vector2)currAgent.transform.position;
            cohesionMove = Vector2.SmoothDamp(currAgent.transform.up, cohesionMove, ref current_velocity, agent_smoothTime);
            return cohesionMove;
        }
    }
}
