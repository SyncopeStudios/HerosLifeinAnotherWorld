using System;
using System.Collections;
using Game.Scripts.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Player
{
        public class PlayerAttack : MonoBehaviour
    {
        [Header("Config")] 
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Weapon initialWeapon;
        [SerializeField] private Transform[] attackPositions;

        [Header("Melee Config")] 
        [SerializeField] private ParticleSystem slashFX;
        [SerializeField] private float minDistanceMeleeAttack;

        public Weapon CurrentWeapon { get; set; }

        private PlayerActions actions;
        private PlayerAnimations playerAnimations;
        private PlayerMovement playerMovement;
        private PlayerMana playerMana;
        private EnemyBrain enemyTarget;
        private Coroutine attackCoroutine;

        private Transform currentAttackPosition;
        private float currentAttackRotation;

        private void Awake()
        {
            actions = new PlayerActions();
            playerMana = GetComponent<PlayerMana>();
            playerMovement = GetComponent<PlayerMovement>();
            playerAnimations = GetComponent<PlayerAnimations>();
        }

        private void Start()
        {
            // Check for WeaponManager instance and set if not initialized
            if (WeaponManager.Instance == null)
            {
                WeaponManager instance = FindObjectOfType<WeaponManager>();
                if (instance == null)
                {
                    Debug.LogError("WeaponManager not found in the scene!");
                    return;
                }
                WeaponManager.Instance = instance;
            }

            // Equip the initial weapon
            WeaponManager.Instance.EquipWeapon(initialWeapon);
            
            // Hook up the attack input
            actions.Attack.ClickAttack.performed += ctx => Attack();
        }

        private void Update()
        {
            GetFirePosition();
        }

        private void Attack()
        {
            if (enemyTarget == null)
            {
                Debug.LogWarning("No enemy selected for attack.");
                return;
            }

            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }

            attackCoroutine = StartCoroutine(IEAttack());
        }

        private IEnumerator IEAttack()
        {
            if (currentAttackPosition == null)
            {
                Debug.LogWarning("Current attack position is null.");
                yield break;
            }

            if (CurrentWeapon == null)
            {
               
                WeaponManager.Instance.EquipWeapon(initialWeapon);
                CurrentWeapon = initialWeapon; // Assign the weapon to CurrentWeapon after equipping it
             
                
                
            }

            if (CurrentWeapon.WeaponType == WeaponType.Magic)
            {
                if (playerMana.CurrentMana < CurrentWeapon.RequiredMana)
                {
                    Debug.LogWarning("Not enough mana to cast magic.");
                    yield break;
                }

                MagicAttack();
            }
            else
            {
                MeleeAttack();
            }

            playerAnimations.SetAttackAnimation(true);
            yield return new WaitForSeconds(0.5f);
            playerAnimations.SetAttackAnimation(false);
        }

        private void MagicAttack()
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
            Projectile projectile = Instantiate(CurrentWeapon.ProjectilePrefab, currentAttackPosition.position, rotation);
            projectile.Direction = Vector3.up;
            projectile.Damage = GetAttackDamage();
            playerMana.UseMana(CurrentWeapon.RequiredMana);
        }

        private void MeleeAttack()
        {
            if (slashFX != null)
            {
                slashFX.transform.position = currentAttackPosition.position;
                slashFX.Play();
            }

            float currentDistanceToEnemy = Vector3.Distance(enemyTarget.transform.position, transform.position);
            if (currentDistanceToEnemy <= minDistanceMeleeAttack)
            {
                IDamagable damageable = enemyTarget.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(GetAttackDamage());
                }
            }
        }

        public void EquipWeapon(Weapon newWeapon)
        {
            CurrentWeapon = newWeapon;
            stats.TotalDamage = stats.BaseDamage + CurrentWeapon.Damage;
        }

        private float GetAttackDamage()
        {
            float damage = stats.BaseDamage + CurrentWeapon.Damage;
            float randomPerc = Random.Range(0f, 100f);
            if (randomPerc <= stats.CriticalChance)
            {
                damage += damage * (stats.CriticalDamage / 100f);
            }
            return damage;
        }

        private void GetFirePosition()
        {
            Vector2 moveDirection = playerMovement.MoveDirection;
            if (moveDirection.x > 0f)
            {
                currentAttackPosition = attackPositions[1];
                currentAttackRotation = -90f;
            }
            else if (moveDirection.x < 0f)
            {
                currentAttackPosition = attackPositions[3];
                currentAttackRotation = -270f;
            }
            else if (moveDirection.y > 0f)
            {
                currentAttackPosition = attackPositions[0];
                currentAttackRotation = 0f;
            }
            else if (moveDirection.y < 0f)
            {
                currentAttackPosition = attackPositions[2];
                currentAttackRotation = -180f;
            }
        }

        private void EnemySelectedCallback(EnemyBrain enemySelected)
        {
            enemyTarget = enemySelected;
        }

        private void NoEnemySelectionCallback()
        {
            enemyTarget = null;
        }

        private void OnEnable()
        {
            actions.Enable();
            SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
            SelectionManager.OnNoSelectionEvent += NoEnemySelectionCallback;
            EnemyHealth.OnEnemyDeadEvent += NoEnemySelectionCallback;
        }

        private void OnDisable()
        {
            actions.Disable();
            SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
            SelectionManager.OnNoSelectionEvent -= NoEnemySelectionCallback;
            EnemyHealth.OnEnemyDeadEvent -= NoEnemySelectionCallback;
        }
    }
}