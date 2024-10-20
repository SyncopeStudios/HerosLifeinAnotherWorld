using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Checkpoint : MonoBehaviour
{
     public Transform spawnPosition;
    [SerializeField] private bool initialSavePoint = false;

    private BoxCollider2D _trigger;

    private void Start()
    {
        if (TryGetComponent(out _trigger))
        {
            _trigger.isTrigger = true;
        }

        if (initialSavePoint)
        {
            Debug.Log($"Setting {name} as initial Checkpoint.");
            CheckPointSystem.Instance.SaveCheckpoint(this);
        }
    }

    private void OnValidate()
    {
        _trigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            CheckPointSystem.Instance.SaveCheckpoint(this);
        }
    }

    public void Spawn(Player player)
    {
        Debug.Log($"Spawning {player} at {name}");
        player.transform.position = spawnPosition.position;
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPosition.position, 0.04f);
    }
}