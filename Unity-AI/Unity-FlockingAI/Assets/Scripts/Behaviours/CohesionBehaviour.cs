using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (context.Count <= 0) return Vector2.zero;
        else
        {
            Vector2 cohesionMove = new Vector2();
            foreach (var item in filter != null ? filter.Filter(currAgent, context) : context)
            {
                cohesionMove += (Vector2)item.position;
            }
            cohesionMove /= context.Count;
            cohesionMove -= (Vector2)currAgent.transform.position;
            return cohesionMove;
        }
    }
}
