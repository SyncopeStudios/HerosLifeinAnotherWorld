using System;
using UnityEngine;

namespace Game.Scripts.Extra
{
    public class AttributeButton: MonoBehaviour
    {
        public static event Action<AttributeType> OnAttributeSelectedEvent;
    
        [Header("Config")]
        [SerializeField] private AttributeType attribute;

        public void SelectAttribute()
        {
            OnAttributeSelectedEvent?.Invoke(attribute);
        }
    }
}