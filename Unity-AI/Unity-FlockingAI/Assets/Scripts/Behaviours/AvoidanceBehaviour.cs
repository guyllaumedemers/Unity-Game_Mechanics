using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FilteredFlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (context.Count <= 0) return Vector2.zero;
        else
        {
            Vector2 avoidancemove = new Vector2();
            int n_avoid = 0;
            foreach (var item in filter != null ? filter.Filter(currAgent, context) : context)
            {
                if (Vector2.Distance(item.position, currAgent.transform.position) < flock.avoidanceRadiusMultipler)
                {
                    avoidancemove += (Vector2)(currAgent.transform.position - item.position);
                    ++n_avoid;
                }
            }
            if (n_avoid > 0) avoidancemove /= n_avoid;
            return avoidancemove;
        }
    }
}
