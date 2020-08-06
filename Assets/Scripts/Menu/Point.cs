using Assets.Scripts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public delegate void ChangePoint(int point);
    class Point : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на текст очков сцены
        /// </summary>
        [SerializeField]private Text pointText;
        /// <summary>
        /// Ссылка на текст очков сцены
        /// </summary>
        public Text PointText
        {
            get { return pointText; }
            set { pointText = value; }
        }

        /// <summary>
        /// Вызывается при увеличении очков
        /// </summary>
        public ChangePoint Add_Point;
        /// <summary>
        /// Количество текущих очков
        /// </summary>
        [SerializeField]private byte countPoint = 0;
        /// <summary>
        /// Количество текущих очков
        /// </summary>
        public byte CountPoint
        {
            get { return countPoint; }
            set { countPoint = value; Add_Point?.Invoke(countPoint); }
        }

        public void Start()
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Generate_Object>().CreateNewMeteor += AddEventDeadMeteorite;
        }

        private void AddEventDeadMeteorite(GameObject sender)
        {
            sender.GetComponent<Meteorite>().Living += AddPoint;
        }

        private void AddPoint(GameObject sender)
        {
            CountPoint++;
            Debug.Log("Point = " + CountPoint);
            PointText.text = countPoint.ToString();
        }
    }
}
