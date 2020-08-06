using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scene
{
    class Timer : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на текст со временем
        /// </summary>
        [SerializeField]private Text textTime;
        public Text TextTime
        {
            get { return textTime; }
            set { textTime = value; }
        }

        /// <summary>
        /// Внутренний счетчик времени
        /// </summary>
        private float t = 0;

        public void Update()
        {
            t += Time.deltaTime;

            int sec = (int)t;
            int min = sec / 60;

            string time = min.ToString() + " : " + (sec % 60).ToString() + " : " + ((int)((t - sec) * 100)).ToString();

            TextTime.text = time;

        }
    }
}
