using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Generate_Object : MonoBehaviour
    {
        #region Parameters
        /// <summary>
        /// Для генерации объема здоровья метеорита
        /// </summary>
        private System.Random r;
        /// <summary>
        /// Ссылка на prefab требуемого объекта
        /// </summary>
        [SerializeField] private GameObject generateObject;
        /// <summary>
        /// Ссылка на prefab требуемого объекта
        /// </summary>
        public GameObject GenerateObject
        {
            get { return generateObject; }
            set { generateObject = value; }
        }

        /// <summary>
        /// Событие вызывающееся, когда создан новый экземпляр метеорита
        /// </summary>
        public Alive CreateNewMeteor;
        #endregion

        public void Start()
        {
            r = new System.Random();
        }

        /// <summary>
        /// Создать экземпляр prefab на сцене
        /// </summary>
        /// <param name="position">Место появления</param>
        /// <param name="parent">Объект требуемого родителя</param>
        public void CreateMeteor(Vector3 position, GameObject parent)
        {
            GameObject newMeteor = Instantiate(generateObject,position,Quaternion.identity,parent.transform);
            newMeteor.GetComponentInChildren<Slider>().value = newMeteor.GetComponentInChildren<Slider>().maxValue = r.Next(20, 100);
            CreateNewMeteor?.Invoke(newMeteor);
        }
    }
}
