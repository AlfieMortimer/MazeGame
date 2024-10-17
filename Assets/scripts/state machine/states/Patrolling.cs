using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
namespace Player
{

    public class Patrolling : State
    {
        public int destNode;
        public Patrolling(AiscriptFSM AI, StateMachine sm) : base(AI, sm)
        {
        }

        public override void Enter()
        {
            AI.nav.destination = AI.nodes[0].position;
            AI.nav.speed = 3.5f;
            destNode = 0;
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
            AI.nav.destination = AI.nodes[destNode].position;
            if (!AI.nav.pathPending && AI.nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();
                Console.WriteLine("NextPoint");
            }
            lookforPlayer();
        }

        public override void PhysicsUpdate()
        {

        }
        public void GoToNextPoint()
        {
            if (AI.nodes.Length == 0)
            {
                return;
            }
            AI.nav.destination = AI.nodes[destNode].position;
            destNode = (destNode + 1) % AI.nodes.Length;
        }

        public void lookforPlayer()
        {
            if (AI.seePlayer)
            {
                sm.ChangeState(AI.attackState);
            }
        }

    }
}
