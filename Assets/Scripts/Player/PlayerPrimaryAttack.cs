using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace.Players
{
    public class PlayerPrimaryAttackState : PlayerState
    {
        public int comboCounter { get; private set; }

        private float lastTimeAttacked;
        private float comboWindow = 2; // Time window for combo reset
        private float inputThreshold = 0.1f; // A small range to account for floating-point precision

        public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            xInput = 0;  // Reset xInput to fix bug on attack direction (when input direction changes unexpectedly)

            // Reset combo counter if too much time has passed since the last attack
            if (Time.time >= lastTimeAttacked + comboWindow)
            {
                comboCounter = 0;
            }

            // Ensure comboCounter is within the bounds of attackMovement array
            comboCounter = Mathf.Clamp(comboCounter, 0, player.attackMovement.Length - 1);

            player.anim.SetInteger("ComboCounter", comboCounter);

            float attackDir = player.facingDir; // Direction the player is facing

            // Use range to check if xInput is non-zero, accounting for floating point precision
            if (Mathf.Abs(xInput) > inputThreshold)
                attackDir = xInput; // Set the attack direction based on player input (if any)

            // Apply movement for the attack based on the current combo
            player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);

            stateTimer = 0.1f; // Timer for the attack state duration
        }

        public override void Exit()
        {
            base.Exit();

            player.StartCoroutine("BusyFor", 0.15f); // Coroutine to handle cooldown before the next state transition

            comboCounter++; // Increment combo counter for the next attack
            if (comboCounter > 2) comboCounter = 0; // Reset the combo counter after the third attack (if needed)
            lastTimeAttacked = Time.time; // Store the time of the attack to manage combo window
        }

        public override void Update()
        {
            base.Update();

            // Check if state timer has finished
            if (stateTimer < 0)
            {
                player.SetZeroVelocity(); // Stop player movement if the attack state is done
            }

            // If the trigger for transitioning to idle state is called, change the state
            if (triggerCalled)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                stateTimer -= Time.deltaTime; // Decrease state timer
            }
        }
    }
}
