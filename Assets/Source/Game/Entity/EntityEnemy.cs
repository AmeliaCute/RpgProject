using System;
using UnityEngine;
using UnityEngine.AI;
using RpgProject.Framework.Thread;

namespace RpgProject.Game.Entity
{
    public class EntityEnemy : Entity
    {
        public virtual float detectionRange { get; set; } = 10f;
        public virtual float baseAttackRange { get; set; } = 2f;
        public virtual float baseAttackDamage { get; set; } = 10f;
        public virtual float baseMovementSpeed { get; set; } = 5f;
        public virtual float baseSpeedAttack { get; set; } = 600; // ms

        [SerializeField]
        private float distanceFromPlayer;
        [SerializeField]
        private float distanceFromSpawnPoint;
        private NavMeshAgent navMeshAgent;
        private Transform player = null;
        [SerializeField]
        private bool isFollowingPlayer = false;
        [SerializeField]
        private bool isAttackingPlayer = false;
        [SerializeField]
        private bool isReturningToSpawn = false;
        [SerializeField]
        private Vector3 spawnPoint;
        private ThreadedRedundantAction detectPlayer;

        public override void init()
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            spawnPoint = gameObject.transform.position;
        }

        public override void update()
        {
            DetectPlayer();
            if (isReturningToSpawn)
            {
                ReturnToSpawn();
            }
            else if (isFollowingPlayer)
            {
                FollowPlayer();
            }
            else if (isAttackingPlayer)
            {
                AttackPlayer();
            }
        }

        private void DetectPlayer()
        {
            distanceFromPlayer = Vector3.Distance(transform.position, player.position);
            distanceFromSpawnPoint = Vector3.Distance(transform.position, spawnPoint);

            if (distanceFromSpawnPoint >= detectionRange + 10f)
            {
                isReturningToSpawn = true;
                isFollowingPlayer = false;
                isAttackingPlayer = false;
                navMeshAgent.ResetPath();
                return;
            }

            if (distanceFromPlayer <= baseAttackRange)
            {
                isReturningToSpawn = false;
                isFollowingPlayer = false;
                isAttackingPlayer = true;
                navMeshAgent.ResetPath(); 
                return;
            }

            if (distanceFromPlayer <= detectionRange)
            {
                isReturningToSpawn = false;
                isFollowingPlayer = true;
                isAttackingPlayer = false;
            }
            else
            {
                isReturningToSpawn = false;
                isFollowingPlayer = false;
                isAttackingPlayer = false;
                navMeshAgent.ResetPath(); 
            }
        }

        public override void die()
        {
        }

        private void ReturnToSpawn()
        {
            navMeshAgent.SetDestination(spawnPoint);
        }

        private void FollowPlayer()
        {
            navMeshAgent.SetDestination(player.position);
        }

        private void AttackPlayer()
        {
            // Attaquer le joueur
        }

        private void OnDisable()
        {
            detectPlayer?.Stop();
            if (navMeshAgent != null)
                navMeshAgent.enabled = false;
        }
    }
}
