using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    class DestroyBoom : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 1f);
        }
    }
}
