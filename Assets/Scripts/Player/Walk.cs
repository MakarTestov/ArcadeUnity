using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Control Script/Walk")]
    class Walk : MonoBehaviour
    {
        /// <summary>
        /// Скорость движения игрока
        /// </summary>
        [SerializeField]private float speed = 13.0f;
        /// <summary>
        /// Скорость движения игрока
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Ссылка на контроль персонажа
        /// </summary>
        private CharacterController charcontr;

        void Start()
        {
            charcontr = GetComponent<CharacterController>();
        }

        void Update()
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaY = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, deltaY, 0);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            charcontr.Move(movement);
            transform.localEulerAngles = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);
            //transform.position +=movement;
        }
    }
}
