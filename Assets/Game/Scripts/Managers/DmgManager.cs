using System;
using Game.Scripts.Extra;
using UnityEngine;

namespace Game.Scripts
{
    public class DmgManager : Singelton<DmgManager>
    {
        
        [SerializeField] private DmgText _dmgTextPrefab;

 


        public void ShowDamageText(float dmgAmount, Transform parent)
        {

           DmgText text = Instantiate(_dmgTextPrefab, parent);
           text.transform.position += Vector3.right * .5f;
           text.SetDamgeText(dmgAmount);
        }

    }
}