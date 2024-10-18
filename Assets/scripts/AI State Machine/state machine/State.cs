
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemy
{
    public abstract class State
    {
        protected AiscriptFSM AI;
        protected StateMachine sm;


        // base constructor
        protected State(AiscriptFSM AI, StateMachine sm)
        {
            this.AI = AI;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}