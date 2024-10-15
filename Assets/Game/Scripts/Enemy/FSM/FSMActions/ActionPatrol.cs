using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSMAction
{
    [SerializeField] private float speed;

    private Waypoints _waypoints;
    private int pointIndex;
    private Vector3 nextPos;

    private void Awake()
    {
        _waypoints = GetComponent<Waypoints>();
    }

    public override void Act()
    {
        followPath();
    }

    private void followPath()
    {

        transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, GetCurrentPosition()) <= 0.1f)
        {
            updateNextPosition();
        }
    }

    private void updateNextPosition()
    {
        pointIndex++;
        if (pointIndex > _waypoints.Points.Length - 1)
        {
            pointIndex = 0;
        }
    }

    private Vector3 GetCurrentPosition()
    {
        return _waypoints.getPos(pointIndex);
    }
}
