using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (context.Count <= 0) return currAgent.transform.up;
        else
        {
            Vector2 alignmentMove = new Vector2();
            foreach (var item in context)
            {
                alignmentMove += (Vector2)item.up;
            }
            alignmentMove /= context.Count;
            return alignmentMove;
        }
    }
}
