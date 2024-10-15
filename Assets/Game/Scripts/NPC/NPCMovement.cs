using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;


    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");

    private Waypoints _waypoints;
    private Animator _animator;
    private Vector3 previousPos;
    private int currentPointIndex;

    private void Awake()
    {
        _waypoints = GetComponent<Waypoints>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 nextPos = _waypoints.getPos(currentPointIndex);
        UpdateMoveValue(nextPos);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPos) <= 0.2)
        {
            previousPos = nextPos;
            currentPointIndex = (currentPointIndex + 1) % _waypoints.Points.Length;
        }
    }

    private void UpdateMoveValue(Vector3 nextPos)
    {
        Vector2 dir = Vector2.zero;
        if (previousPos.x < nextPos.x) dir = new Vector2(1f, 0f);
        if (previousPos.x < nextPos.x) dir = new Vector2(-1f, 0f);
        if (previousPos.x < nextPos.x) dir = new Vector2(0f, 1f);
        if (previousPos.x < nextPos.x) dir = new Vector2(0f, -1f);
        
        _animator.SetFloat(moveX,dir.x);
        _animator.SetFloat(moveY,dir.y);


    }
}
