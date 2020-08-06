using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Objects
{
    class Player : MonoBehaviour
    {
        /// <summary>
        /// Вызывается, если персонаж потерял все здоровье
        /// </summary>
        public Alive isDead;

        /// <summary>
        /// Время до возможного урона
        /// </summary>
        [SerializeField]private float timeouthit = 1.0f;
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            //Debug.Log("Yes");
            if (hit.transform.tag == "Enemy")
            {
                Hit(1);
            }
            
        }
        public void Update()
        {
            if(timeouthit > 0)
            {
                timeouthit -= Time.deltaTime;
            }
        }

        public void Hit(int damage)
        {
            if (timeouthit <= 0)
            {
                gameObject.GetComponent<Slider>().value -= damage;
                timeouthit = 2.0f;
                if(gameObject.GetComponent<Slider>().value <= 0)
                {
                    isDead?.Invoke(gameObject);
                }
            }
        }
    }
}
