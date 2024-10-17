using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
namespace Player
{

    public class attackstate : State
    {
        public GameObject player;
        public bool checkStarted = false;
        float timer = 5;

        public attackstate(AiscriptFSM AI, StateMachine sm) : base(AI, sm)
        {
        }

        public override void Enter()
        {
            timer = 5;
            AI.nav.speed = 5;
            checkStarted = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            AI.nav.destination = AI.player.transform.position;
            
        }

        public override void PhysicsUpdate()
        {
            if (timer > 0)
            {
                timer-= Time.deltaTime;
                Debug.Log(timer);
            }
            if (timer <= 0 && AI.seePlayer)
            {
                Debug.Log("Reset Timer");
                timer = 5;
            }
            if (timer <= 0 && !AI.seePlayer)
            {
                sm.ChangeState(AI.patrolState);
                Debug.Log("Reset to Patrol");
            }
        }
    }
}
