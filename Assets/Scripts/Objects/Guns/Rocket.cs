using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Objects.Guns
{
    class Rocket : Gun
    {
        /// <summary>
        /// Время до уничтожения объекта (время жизни)
        /// </summary>
        [SerializeField]private float timeLive = 4.0f;
        /// <summary>
        /// Время до уничтожения объекта (время жизни)
        /// </summary>
        public float TimeLive
        {
            get { return timeLive; }
            set { timeLive = value; }
        }

        /// <summary>
        /// Выстрел ракетой
        /// </summary>
        /// <param name="startposition">Позиция старта ракеты</param>
        /// <param name="rotationposition">Позиция начального положения ракеты</param>
        public override void ShotGun(Vector3 startposition, Quaternion rotationposition, Transform parent)
        {
            GameObject ob = Instantiate(MyGun, parent);
            ob.transform.localPosition = startposition;
            ob.transform.localRotation = rotationposition;
            Destroy(ob, 3f);
        }

        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponentInChildren<Slider>().value -= Damage;//hit.transform.GetComponent<Gun>().Damage;
                //Destroy(hit.transform);
                if (hit.transform.GetComponentInChildren<Slider>().value <= 0)
                {
                    hit.transform.GetComponentInChildren<Meteorite>().IsAlive = false;
                    Destroy(hit.gameObject);
                }
                Destroy(gameObject);
            }
            if(hit.transform.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}
