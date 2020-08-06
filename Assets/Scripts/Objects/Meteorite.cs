using Assets.Scripts.Objects.Guns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Objects
{
    public delegate void Alive(GameObject sender);
    [RequireComponent(typeof(CharacterController))]
    class Meteorite : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на компонент жизни
        /// </summary>
        private Slider health;

        /// <summary>
        /// Цель для наведения
        /// </summary>
        [SerializeField]private Transform target;

        /// <summary>
        /// Цель для наведения
        /// </summary>
        public Transform Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// Ссылка на объект взрыва
        /// </summary>
        [SerializeField] private GameObject boom;
        /// <summary>
        /// Ссылка на объект взрыва
        /// </summary>
        public GameObject Boom
        {
            get { return boom; }
            set { boom = value; }
        }

        /// <summary>
        /// Событие изменения жизни
        /// </summary>
        public Alive Living;
        /// <summary>
        /// Уничтожен ли метеорит
        /// </summary>
        [SerializeField]private bool isAlive;
        /// <summary>
        /// Уничтожен ли метеорит
        /// </summary>
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; Living?.Invoke(gameObject); }
        }

        /// <summary>
        /// Скорость движения метеорита
        /// </summary>
        [SerializeField] private float speed = 13.0f;
        /// <summary>
        /// Скорость движения метеорита
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
        private float _currentT;

        public void Start()
        {
            health = gameObject.GetComponentInChildren<Slider>();
            charcontr = GetComponent<CharacterController>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Living += GenerateBoom;
        }

        public void Update()
        {
            if (Time.timeScale != 0)
            {//gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, target.localPosition, 0.5f) * speed*Time.deltaTime;
             //Vector3 destination = transform.position + delta;
                float step = speed * Time.deltaTime;
                Vector3 dir = target.position - transform.position;

                //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                charcontr.Move(dir * step);
                //transform.LookAt(Target);
            }
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.transform.tag == "Player")
            {
                hit.gameObject.GetComponent<Player>().Hit(1);
            }
        }

        public void GenerateBoom(GameObject sender)
        {
            Instantiate(boom, sender.transform.position, sender.transform.localRotation, sender.transform.parent);
        }
    }
}
