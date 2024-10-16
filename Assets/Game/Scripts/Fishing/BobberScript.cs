using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BobberScript : MonoBehaviour
{
    public bool gameIsOver;
    public Animator bobberAnim;
    public float bobberTime;
   


    private void Update()
    {
       
        bobberTime += Time.deltaTime;
        if (bobberTime >= 4.0f)
        {
            bobberAnim.Play("BobberFish");
        }

        if (Input.GetKeyDown(KeyCode.P) && bobberTime <= 3)
        {
            Destroy(gameObject);
        }

        if (gameIsOver == true)
        {
            Destroy(gameObject);
            
        }
    }

    public void gameOver()
    {
        gameIsOver = true;
    }
}
