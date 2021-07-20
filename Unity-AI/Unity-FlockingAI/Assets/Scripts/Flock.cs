using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flock : MonoBehaviour
{
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
        prefab = Utilities.FindResources<FlockAgent>(Globals.prefab_path).FirstOrDefault();
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
            agents.Add(newAgent);
        }
    }

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
