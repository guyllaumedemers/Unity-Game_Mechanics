using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FilteredFlockBehaviour
{
    /*  Avoidance Behaviour : How it works
     *  
     *      Same as Alignment, flock class the CalculateMove method and pass the current agent to it
     *      Retrieve all neighbors.
     *      
     *      We then check if the distnace between the current agent and his neighbors is less than the avoidance radius
     *      AND
     *      since we want to go in the opposite direction, we take the current agent position and substract it to the neighbors position
     *      
     *      finally we average the result of the sum and return that new vector
     * 
     */

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
