using UnityEngine;

public class Randomwaypoints : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;
    [SerializeField] private int numberOfPoints = 10; // Number of random waypoints to generate
    [SerializeField] private Vector3 areaSize = new Vector3(10f, 0f, 10f); // Size of the area for random points

    public Vector3 EntityPosition { get; set; }

    private bool gameStarted;

    private void Start()
    {
        EntityPosition = transform.position;
        gameStarted = true;
        GenerateRandomPoints();
    }

    private void GenerateRandomPoints()
    {
        points = new Vector3[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            // Generate random positions within the specified area
            float randomX = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
            float randomy = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);
            points[i] = new Vector3(randomX, randomy, 0f ); // Adjust Y as needed
        }
    }

    public Vector3 GetPos(int pointIndex)
    {
        return EntityPosition + points[pointIndex];
    }

    private void OnDrawGizmos()
    {
        if (!gameStarted && transform.hasChanged)
        {
            EntityPosition = transform.position;
        }

        // Draw the waypoints in the editor
        if (points != null)
        {
            Gizmos.color = Color.red;
            foreach (var point in points)
            {
                Gizmos.DrawSphere(EntityPosition + point, 0.5f);
            }
        }
    }
}
