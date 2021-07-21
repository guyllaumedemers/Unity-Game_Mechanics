using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Client
public class Flock : MonoBehaviour
{
    [SerializeField]
    FlockAgent prefab;
    List<FlockAgent> agents;
    FlockBehaviour flockBehav;

    [Range(10, 500)]
    public int starting_count = 250;
    const float AgentDensity = 0.08f;

    [Range(1.0f, 100.0f)]
    public float driveFactor = 10.0f;
    [Range(1.0f, 100.0f)]
    public float maxSpeed = 5.0f;
    [Range(1.0f, 10.0f)]
    public float neighborRadius = 1.5f;
    [Range(0.0f, 1.0f)]
    public float avoidanceRadiusMultipler = 0.5f;

    private void Awake()
    {
        //prefab = Utilities.FindResources<FlockAgent>(Globals.prefab_path).FirstOrDefault();
        flockBehav = Utilities.FindResources<FlockBehaviour>(Globals.scriptable_path).FirstOrDefault();
        agents = new List<FlockAgent>();
    }

    private void Start()
    {
        for (int i = 0; i < starting_count; ++i)
        {
            FlockAgent newAgent = Instantiate(prefab, Random.insideUnitCircle * starting_count * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)), transform);
            newAgent.name = "Agent " + i;
            newAgent.InitializeFlock(this);
            agents.Add(newAgent);
        }
    }

    /*  What is happening here
     * 
     *      At instanciation all flock agents were added to a list which we now loop over in order to update the flock behaviours
     *      FOREACH agents
     *      We want to retrieve his neighbors and store them so we can pass them as arguments for the individual behaviours of the flocking AI
     *      
     *      Since we are using the Composite pattern, CompositeBehaviours aggregate the leaf behaviours that inherit from flockingbehaviours
     *      and retrieve the FINAL vector
     *      that represent the new position for the agent currently being processed
     *      
     *      we can then apply a "driveFactor" which represent the speed of the agent and update via the move function the agent itself
     * 
     */
    private void Update()
    {
        foreach (var agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move = flockBehav.CalculateMove(agent, context, this);
            move *= driveFactor;
            agent.Move(Vector2.ClampMagnitude(move, maxSpeed));
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        return contextColliders.Where(c => c != agent.AgentCollider).Select(c => c.transform).ToList();
    }
}
