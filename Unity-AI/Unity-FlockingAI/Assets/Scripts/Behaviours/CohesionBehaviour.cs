using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    /*  Cohesion Behaviour : How it works
     *  
     *      Same as Alignment and Avoidance, flock class the CalculateMove method and pass the current agent to it
     *      Retrieve all neighbors.
     *      
     *      We want our current agent to move to the average position of all neighbors so we have to sum all neighbors position
     *      AND
     *      average that result
     *      
     *      finally we substract our position to create the offset between our current position and the position we want to translate too
     * 
     */

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
