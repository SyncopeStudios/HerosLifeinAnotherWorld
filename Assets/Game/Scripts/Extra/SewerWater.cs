using System;
using UnityEngine;

public class SewerWater : MonoBehaviour
{

   public float Damage;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Water"))
      {

         other.GetComponent<IDamagable>()?.TakeDamage(Damage);
         
         
      }
   }
}
