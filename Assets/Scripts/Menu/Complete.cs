using Assets.Scripts.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class Complete : MonoBehaviour
    {
        /// <summary>
        /// Объект концовки победителя
        /// </summary>
        [SerializeField]private GameObject goodEnd;
        /// <summary>
        /// Объект концовки победителя
        /// </summary>
        public GameObject GoodEnd
        {
            get { return goodEnd; }
            set { goodEnd = value; }
        }

        /// <summary>
        /// Объект концовки проигравшего
        /// </summary>
        [SerializeField] private GameObject badEnd;
        /// <summary>
        /// Объект концовки проигравшего
        /// </summary>
        public GameObject BadEnd
        {
            get { return badEnd; }
            set { badEnd = value; }
        }


        public void Start()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Assets.Scripts.Objects.Player>().isDead += GameOver;
            GetComponent<Point>().Add_Point += GameComplete;
        }

        public void GameOver(GameObject sender)
        {
            Time.timeScale = 0;
            Destroy(sender);
            badEnd.SetActive(true);
        }

        public void GameComplete(int count)
        {
            if (count >= GetComponent<Game_Control>().MaxCount)
            {
                Time.timeScale = 0;
                goodEnd.SetActive(true);
            }
        }

    }
}
