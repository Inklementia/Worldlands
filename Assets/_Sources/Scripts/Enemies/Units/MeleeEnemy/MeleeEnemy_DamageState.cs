﻿using _Sources.Scripts.Enemies.Data;
using _Sources.Scripts.Enemies.State_Mashine;
using _Sources.Scripts.Enemies.States;

namespace _Sources.Scripts.Enemies.Units.MeleeEnemy
{
    public class MeleeEnemy_DamageState : DamageState
    {
        private MeleeEnemy _enemy;
        public MeleeEnemy_DamageState(Entity entity, FiniteStateMashine stateMachine, string animBoolName, D_DamageState stateData, MeleeEnemy enemy) : 
            base(entity, stateMachine, animBoolName, stateData)
        {
            _enemy = enemy;
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            _enemy.Core.Movement.StopMovement();
        

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsDamageTimeOver)
            {
                //StateMachine.ChangeState(_enemy.PatrolState);
                //StateMachine.ChangeState(_enemy.MoveState);

                if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(_enemy.PlayerDetectedState);
                }
                else
                {
                    //StateMachine.ChangeState(_enemy.PatrolState);
                    StateMachine.ChangeState(_enemy.MoveState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
