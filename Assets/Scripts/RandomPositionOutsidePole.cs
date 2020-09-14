using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class RandomPositionOutsidePole : MonoBehaviour
    {
        #region Parameters
        /// <summary>
        /// Поле на котором играют
        /// </summary>
        [SerializeField]
        [Header("Playing field")]
        private GameObject pole;
        /// <summary>
        /// Поле на котором играют
        /// </summary>
        public GameObject Pole
        {
            get { return pole; }
            set { pole = value; }
        }

        /// <summary>
        /// Компонент для нахождения размера поля
        /// </summary>
        private RectTransform rectpole;

        /// <summary>
        /// Transform объекта генерации
        /// </summary>
        private RectTransform rectGenerobject;

        #region Places
        /// <summary>
        /// Координаты начала левой части поля
        /// </summary>
        private float left;
        /// <summary>
        /// Координаты начала правой части поля
        /// </summary>
        private float right;
        /// <summary>
        /// Координаты начала верхней части поля
        /// </summary>
        private float up;
        /// <summary>
        /// Координаты начала нижней части поля
        /// </summary>
        private float down;

        /// <summary>
        /// Половина высоты поля
        /// </summary>
        private float partHeight;
        /// <summary>
        /// Половина ширины поля
        /// </summary>
        private float partWidth;
        #endregion

        /// <summary>
        /// Для генерации случайных чисел
        /// </summary>
        private System.Random r;
        #endregion

        public void Start()
        {
            rectpole = pole.GetComponent<RectTransform>();
            rectGenerobject = GetComponent<RectTransform>();
            SetPartHeightandWidth();

            SetPlaces();

            r = new System.Random();
        }

        /// <summary>
        /// Установить половины размеров поля
        /// </summary>
        private void SetPartHeightandWidth()
        {
            partHeight = rectpole.rect.height / 2;
            partWidth = rectpole.rect.width / 2;
        }

        /// <summary>
        /// Установить боковые места
        /// </summary>
        private void SetPlaces()
        {
            /*left = rect.rect.x - partWidth;
            right = rect.rect.x + partWidth;
            up = rect.rect.y + partHeight;
            down = rect.rect.y - partHeight;*/
            left = pole.transform.localPosition.x - partWidth - rectGenerobject.rect.width;
            right = pole.transform.localPosition.x + partWidth + rectGenerobject.rect.width;
            up = pole.transform.localPosition.y + partHeight + rectGenerobject.rect.height;
            down = pole.transform.localPosition.y - partHeight - rectGenerobject.rect.height;
        }

        /// <summary>
        /// Установить новое случайное расположение объекта
        /// </summary>
        public void SetNewRandomPosition()
        {
            switch (r.Next(0, 2))
            {
                //Левая и правая сторона поля
                case 0:
                    {
                        int y = r.Next((int)(down), (int)(up));
                        switch (r.Next(0, 2))
                        {
                            //Правая сторона поля
                            case 0:
                                {
                                    gameObject.transform.localPosition = new Vector3(right - 50, y, 0);
                                    break;
                                }
                            //Левая сторона поля
                            case 1:
                                {
                                    gameObject.transform.localPosition = new Vector3(left + 50, y, 0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                //Верхняя и нижняя сторона поля
                case 1:
                    {
                        int x = r.Next((int)(left), (int)(right));
                        switch (r.Next(0, 2))
                        {
                            //Нижняя сторона поля
                            case 0:
                                {
                                    gameObject.transform.localPosition = new Vector3(x, down + 50, 0);
                                    break;
                                }
                            //Верхняя сторона поля
                            case 1:
                                {
                                    gameObject.transform.localPosition = new Vector3(x, up - 50, 0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
