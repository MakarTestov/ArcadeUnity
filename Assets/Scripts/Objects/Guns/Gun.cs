using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects.Guns
{
    abstract class Gun : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на prefab оружия
        /// </summary>
        [SerializeField] private GameObject mygun;
        /// <summary>
        /// Ссылка на prefab оружия
        /// </summary>
        public GameObject MyGun
        {
            get { return mygun; }
            set { mygun = value; }
        }

        /// <summary>
        /// Количества наносимого урона
        /// </summary>
        [SerializeField]private byte damage = 9;

        /// <summary>
        /// Количество наносимого урона
        /// </summary>
        public byte Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        /// <summary>
        /// Максимальное количество выстрелов
        /// </summary>
        [SerializeField][Range(1,20)][Header("Maximum count rocket in space")]
        private byte maxCount;

        /// <summary>
        /// Максимальное количество выстрелов
        /// </summary>
        public byte MaxCount
        {
            get { return maxCount; }
            set { maxCount = value; }
        }

        /// <summary>
        /// Выстрел орудием
        /// </summary>
        /// <param name="startposition">Позиция начала выстрела</param>
        /// <param name="rotationposition">Поворот выстрела</param>
        public virtual void ShotGun(Vector3 startposition, Quaternion rotationposition, Transform parent)
        {

        }
    }
}
