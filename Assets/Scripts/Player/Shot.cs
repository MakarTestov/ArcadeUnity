using Assets.Scripts.Objects.Guns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    class Shot : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на объект оружия
        /// </summary>
        [SerializeField]private Gun mygun;

        /// <summary>
        /// Ссылка на объект оружия
        /// </summary>
        public Gun MyGun
        {
            get { return mygun; }
            set { mygun = value; }
        }

        /// <summary>
        /// Ссылка на slider отображающий тайммаут выстрела
        /// </summary>
        [SerializeField]private Slider timeOut;
        /// <summary>
        /// Ссылка на slider отображающий тайммаут выстрела
        /// </summary>
        public Slider TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        public void FixedUpdate()
        {
            TimeOut.value += Time.deltaTime;
            if(Input.GetAxis("FireRocket") > 0)
            {
                if (TimeOut.value >= TimeOut.maxValue)
                {
                    mygun.ShotGun(gameObject.transform.localPosition, gameObject.transform.localRotation, gameObject.transform.parent);
                    TimeOut.value = 0;
                }
            }
        }
    }
}
