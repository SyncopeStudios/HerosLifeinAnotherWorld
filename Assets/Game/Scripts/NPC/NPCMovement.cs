using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
 [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance = 0.2f; // Distance considered "reached"
    [SerializeField] private float timeoutDuration = 3f; // Time allowed to reach the waypoint

    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");

    private Waypoints _waypoints;
    private Randomwaypoints _randomWaypoints;
    private Animator _animator;
    private Vector3 previousPos;
    private int currentPointIndex;
    private float timer; // Timer to track time spent moving

    private void Awake()
    {
        _waypoints = GetComponent<Waypoints>();
        _randomWaypoints = GetComponent<Randomwaypoints>();
        _animator = GetComponent<Animator>();

        // Check for null references
        if (_waypoints == null && _randomWaypoints == null)
        {
            Debug.LogError("Neither Waypoints nor RandomWaypoints component found!");
        }
        if (_animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    private void Update()
    {
        // Determine which waypoint system to use
        if (_waypoints != null && _waypoints.Points.Length > 0)
        {
            MoveTowardsNextPoint(_waypoints.getPos(currentPointIndex), _waypoints.Points.Length);
        }
        else if (_randomWaypoints != null && _randomWaypoints.Points.Length > 0)
        {
            MoveTowardsNextPoint(_randomWaypoints.GetPos(currentPointIndex), _randomWaypoints.Points.Length);
        }
    }

    private void MoveTowardsNextPoint(Vector3 nextPos, int totalPoints)
    {
        timer += Time.deltaTime; // Increment timer each frame

        UpdateMoveValue(nextPos);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);

        // Check if within stop distance
        if (Vector3.Distance(transform.position, nextPos) <= stopDistance)
        {
            previousPos = nextPos;
            currentPointIndex = (currentPointIndex + 1) % totalPoints;
            timer = 0; // Reset timer when moving to the next point
        }
        // Check if timeout duration exceeded
        else if (timer >= timeoutDuration)
        {
            Debug.Log($"Timeout reached at point {currentPointIndex}, moving to next point.");
            previousPos = nextPos; // Update previous position to current nextPos
            currentPointIndex = (currentPointIndex + 1) % totalPoints; // Move to next point
            timer = 0; // Reset timer
        }
    }

    private void UpdateMoveValue(Vector3 nextPos)
    {
        Vector2 dir = Vector2.zero;

        // Calculate direction
        if (previousPos.x < nextPos.x) dir.x = 1f; // Move right
        else if (previousPos.x > nextPos.x) dir.x = -1f; // Move left
        if (previousPos.z < nextPos.z) dir.y = 1f; // Move up
        else if (previousPos.z > nextPos.z) dir.y = -1f; // Move down

        // Set animator parameters
        _animator.SetFloat(moveX, dir.x);
        _animator.SetFloat(moveY, dir.y);
    }
}
