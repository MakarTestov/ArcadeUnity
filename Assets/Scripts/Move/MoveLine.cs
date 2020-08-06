using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Move
{
    [RequireComponent(typeof(CharacterController))]
    class MoveLine : MonoBehaviour
    {
        /// <summary>
        /// Скорость движения
        /// </summary>
        [SerializeField]private float speed = 0;
        /// <summary>
        /// Скорость движения
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        [SerializeField] private float maxSpeed = 9.0f;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public float MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        /// <summary>
        /// Ускорение
        /// </summary>
        [SerializeField][Range(0.1f, 2.0f)] private float acceleration = 0.5f;
        /// <summary>
        /// Ускорение
        /// </summary>
        public float Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        /// <summary>
        /// Ссылка на контроль персонажа
        /// </summary>
        private CharacterController charcontr;

        void Start()
        {
            charcontr = GetComponent<CharacterController>();
        }
        public void FixedUpdate()
        {
            if (speed < maxSpeed)
            {
                Speed += acceleration;
            }
            Vector3 movement = new Vector3(0, speed, 0);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            charcontr.Move(movement);
        }
    }
}
