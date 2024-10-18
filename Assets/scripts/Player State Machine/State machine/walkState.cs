using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
namespace player
{

    public class walkState : StateP
    {
        
        float timer = 3f;
        bool isRunning = false;
        public walkState(playerscript pl, StateMachineP sm) : base(pl, sm)
        {
        }

        public override void Enter()
        {

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
            Vector3 forward = pl.transform.TransformDirection(Vector3.forward);
            Vector3 right = pl.transform.TransformDirection(Vector3.right);

            // Press Left Shift to run

            if (pl.Stamina > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                pl.Stamina -= Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.LeftShift) || pl.Stamina <= 0)
            {
                isRunning = false;
            }
            float curSpeedX = pl.canMove ? (isRunning ? pl.runSpeed : pl.walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = pl.canMove ? (isRunning ? pl.runSpeed : pl.walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = pl.moveDirection.y;
            pl.moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            StaminaRegen();

        }

        public override void PhysicsUpdate()
        {

        }
        public void StaminaRegen()
        {
            if (isRunning == true)
            {
                timer = 3f;
                pl.staminaWheel.fillAmount = pl.Stamina / 4;
            }

            if (isRunning == false)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0 && isRunning == false)
            {
                if (pl.Stamina <= 4)
                {
                    pl.Stamina += Time.deltaTime;
                    pl.staminaWheel.fillAmount = pl.Stamina / 4;
                }
            }
        }
    }
}
