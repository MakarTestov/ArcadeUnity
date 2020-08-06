using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    /// <summary>
    /// Скорость вращения игрока
    /// </summary>
    [SerializeField]private float speed = 13.0f;
    /// <summary>
    /// Скорость вращения игрока
    /// </summary>
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Update()
    {
        if(Input.GetAxis("RotateRight") > 0)
        {
            gameObject.transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
        if(Input.GetAxis("RotateLeft") > 0)
        {
            gameObject.transform.Rotate(0, 0, +speed * Time.deltaTime);
        }
    }
}
