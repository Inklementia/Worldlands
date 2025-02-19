﻿using _Sources.Scripts.Enemies.Data;
using _Sources.Scripts.Enemies.State_Mashine;
using _Sources.Scripts.Enemies.States;
using UnityEngine;

namespace _Sources.Scripts.Enemies.Units.MeleeEnemy
{
    public class MeleeEnemy_MoveState : MoveState
    {
        private MeleeEnemy _enemy;

        public MeleeEnemy_MoveState(Entity entity, FiniteStateMashine stateMachine, string animBoolName, D_MoveState stateData, MeleeEnemy enemy) : 
            base(entity, stateMachine, animBoolName, stateData)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            //_enemy.Core.Movement.SetVelocity(Direction, StateData.MovementSpeed);
      
            //bug.Log(Direction + " * " + StateData.MovementSpeed);
        }

        public override void Exit()
        {
            base.Exit();
        
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _enemy.Core.Movement.SetVelocity(Direction, StateData.MovementSpeed);

            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(_enemy.PlayerDetectedState);
            }
            else if (IsDetectingWall)
            {
                SpendTime += Time.deltaTime;
                if (SpendTime >= TimeBeforeDetectingWall || Direction == Vector2.zero)
                {
                    StateMachine.ChangeState(_enemy.IdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
