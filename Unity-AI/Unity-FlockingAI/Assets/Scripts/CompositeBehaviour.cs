using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptable", menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    [SerializeField]
    FlockBehaviour[] behaviours;
    public float[] weights = new float[3];

    private void Start()
    {
        behaviours = Utilities.FindResources<FlockBehaviour>(Globals.flockbehaviours_path);
    }

    public override Vector2 CalculateMove(FlockAgent currAgent, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviours.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero;
        }

        Vector2 move = new Vector2();
        for (int i = 0; i < behaviours.Length; ++i)
        {
            Vector2 partialMove = behaviours[i].CalculateMove(currAgent, context, flock) * weights[i];
            if (partialMove != Vector2.zero && partialMove.sqrMagnitude > (weights[i] * weights[i]))
            {
                partialMove.Normalize();
                partialMove *= weights[i];
            }
            move += partialMove;
        }
        return move;
    }

    public FlockBehaviour[] GetFlockBehaviours { get => behaviours; }
}
