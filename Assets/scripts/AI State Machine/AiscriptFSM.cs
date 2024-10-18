using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;
using Unity.IO.LowLevel.Unsafe;
using Enemy;
using UnityEngine.AI;
using System;

namespace Enemy
{

    public class AiscriptFSM : MonoBehaviour
    {
        public Patrolling patrolState;
        public attackstate attackState;
        public StateMachine sm;

        public NavMeshAgent nav;
        public Transform[] nodes;
        public int destNode;
        public bool seePlayer = false;

        public Animator anim;
        public GameObject player;
        public GameObject checkSphere;
        public LayerMask playerMask;

        private void Start()
        {
            anim = GetComponent<Animator>();
            sm = gameObject.AddComponent<StateMachine>();
            patrolState = new Patrolling(this, sm);
            attackState = new attackstate(this, sm);

            sm.Init(patrolState);
        }
        private void Update()
        {
            sm.CurrentState.LogicUpdate();
            CheckForPlayer();
        }
        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void CheckForPlayer()
        {
            seePlayer = Physics.CheckSphere(checkSphere.transform.position, 10f, playerMask);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(checkSphere.transform.position, 10f);
        }

    }

}
