using System.Collections;
using Game.Scripts.Extra;
using UnityEngine;

public class FishGame : Singelton<FishGame>
{
    [SerializeField] private float showoffDuration = 2f; // Set a default duration
    public Animator anim;
    public GameObject fish;

    public bool isActive; // Indicates if the game object is active

    void Start()
    {
        // Any initialization logic
    }

    void Update()
    {
        // Check if the object is active and if isActive is true
        if (isActive && gameObject.activeInHierarchy)
        {
           // StartCoroutine(Showoff()); // Start the coroutine
           // isActive = false; // Prevent it from running multiple times
        }
    }

  

    public void Activate()
    {
        isActive = true; // Set isActive to true when you want to start showing off
    }
}
