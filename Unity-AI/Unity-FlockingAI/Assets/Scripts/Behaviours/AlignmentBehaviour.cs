using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    /*  Alignment Behaviour : How it works
     *  
     *      Flock is going to call CalculateMove for each of his behaviours set as arguments in the inspector.
     *      Upon calling Alignment behaviour, he will pass the current Agent he is comparing and retrieve all neighbors inside the radius of the circle collider
     *      
     *      Alignment then sum all "forward" position value, in our case since we are in 2D, we retrieve the up vector
     *      and than average the result by dividing with the number of neighbors he previously retrieved
     *      
     *      finally, he returns the new vector with the alignment so the current agent can face the proper direction
     * 
     */

    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (context.Count <= 0) return currAgent.transform.up;
        else
        {
            Vector2 alignmentMove = new Vector2();
            foreach (var item in filter != null ? filter.Filter(currAgent, context) : context)
            {
                alignmentMove += (Vector2)item.up;
            }
            alignmentMove /= context.Count;
            return alignmentMove;
        }
    }
}
