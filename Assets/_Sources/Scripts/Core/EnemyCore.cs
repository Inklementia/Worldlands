using _Sources.Scripts.Core.Components;
using UnityEngine;

namespace _Sources.Scripts.Core
{
    public class EnemyCore : global::_Sources.Scripts.Core.Core
    {
        public CollisionSenses CollisionSenses { get; private set; }
        public PlayerDetectionSenses PlayerDetectionSenses { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            PlayerDetectionSenses = GetComponentInChildren<PlayerDetectionSenses>();

            if (!CollisionSenses || !PlayerDetectionSenses)
            {
                Debug.LogError("Missing Senses Component");
            }

        }
    }
}
