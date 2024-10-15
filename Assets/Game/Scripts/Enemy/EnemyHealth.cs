using System;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamagable
    {
        public static event Action OnEnemyDeadEvent;

        [Header("Config")] [SerializeField] private float health;

        public float CurrentHealth { get; private set; }

        private Animator animator;
        private Rigidbody2D rd2d;
        private EnemyBrain enemyBrain;
        private EnemyLoot enemyLoot;
        private EnemySelector enemySelector;

        private void Awake()
        {
            rd2d = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            enemyLoot = GetComponent<EnemyLoot>();
            enemyBrain = GetComponent<EnemyBrain>();
            enemySelector = GetComponent<EnemySelector>();
        }

        private void Start()
        {
            CurrentHealth = health;
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0f)
            {
                DisableEnemy();
                QuestManager.Instance.AddProgress("Kill10Enemies", 1);
            }
            else
            {
                DmgManager.Instance.ShowDamageText(amount, transform);
            }
        }

        private void DisableEnemy()
        {
            animator.SetTrigger("Dead");
            enemyBrain.enabled = false;
            enemySelector.NoSelectionCallback();
            rd2d.bodyType = RigidbodyType2D.Static;
            OnEnemyDeadEvent?.Invoke();
            GameManager.Instance.AddPlayerExp(enemyLoot.ExpDrop);
        }
    }
}