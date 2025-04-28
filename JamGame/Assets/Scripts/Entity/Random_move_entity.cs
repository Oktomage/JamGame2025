using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entitys
{
    public class Random_move_entity : MonoBehaviour
    {
        [Header("Configs")]
        public float Speed;
        public float RotationSpeed;

        private Vector2 targetDirection;

        private void Start()
        {
            PickNewDirection();
        }

        private void Update()
        {
            RotateTowardsTarget();
            MoveForward();
        }

        private void PickNewDirection()
        {

        }

        private void RotateTowardsTarget()
        {

        }

        private void MoveForward()
        {

        }
    }
}