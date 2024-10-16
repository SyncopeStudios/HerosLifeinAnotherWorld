using System;
using System.Collections;
using UnityEngine;

public class FishingBar : MonoBehaviour
{

    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private float maxSpeed = 10f;
    public Rigidbody rb;

    public bool atTop;

    public float targetTime = 4.0f;

    public float savedTargetTime;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;

    public bool onFish;

    public Player player;
    public Animator anim;
    [SerializeField] private GameObject _game;

    public GameObject bobber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetTime -= Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (onFish == true)
        {
            
            targetTime += Time.deltaTime;

        }

        if (onFish == false)
        {
            targetTime -= Time.deltaTime;
        }

        if (targetTime <= 0.0f)
        {
            transform.localPosition = new Vector3(0.3906f, -3.03f, 0);
            onFish = false;
            player.FishGameLossed();  
            anim.Play("Idle Tree");
            Destroy(GameObject.Find("Bobber(Clone)"));
            targetTime = 4.0f;
        }
        if (targetTime >= 10.0f)
        {
            transform.localPosition = new Vector3(0.3906f, -3.03f, 0);
            onFish = false;
            player.FishGameWon();
            StartCoroutine(Showoff());
           // _game.SetActive(false);
            Destroy(GameObject.Find("Bobber(Clone)"));
            targetTime = 4.0f;
        }

        if (targetTime>=0.0f)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }
        
        if (targetTime>=1.0f)
        {
            p1.SetActive(true);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }
        
        if (targetTime>=2.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }
        
        if (targetTime>=3.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }

        
        if (targetTime>=4.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }
        
        if (targetTime>=5.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }
        
        if (targetTime>=6.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(false);
            p8.SetActive(false);
            
        }   if (targetTime>=7.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(true);
            p8.SetActive(false);
            
        } if (targetTime>=8.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(true);
            p8.SetActive(true);
            
        }

      
        // If the player lets go of the space bar, the fishing bar falls due to gravity
     
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) // Only trigger on key press
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            // If the bar is falling too fast, clamp the downward velocity
            if (rb.linearVelocity.y < -maxSpeed)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, -maxSpeed, rb.linearVelocity.z);
            }
        }
    }
    
    IEnumerator Showoff()
    {
        anim.Play("Idle Tree");
        
        yield return new WaitForSeconds(showoffDuration);

        // Optionally, transition to another animation or perform other actions here
        // anim.Play("PreviousAnimation"); // Uncomment this if needed
    }
    public void OnTriggerEnter(Collider other)
    {
       
            onFish = true;
       
    }

    public void OnTriggerExit(Collider other)
    {
      
            onFish = false;
        
    }
    [SerializeField] private float showoffDuration = 2f; 


}
