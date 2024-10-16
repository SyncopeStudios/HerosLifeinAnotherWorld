using System;
using UnityEngine;

public class IntroAnime : MonoBehaviour
{

    public Animator enemyAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemyAnim.Play("Min_dead");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyAnim.Play("Minitore");
    }
}
