using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMove : MonoBehaviour
{
    /// <summary>
    /// Скорость поворота
    /// </summary>
    [SerializeField]private float speed = 13.0f;
    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    /// <summary>
    /// Поворот по оси Х
    /// </summary>
    [SerializeField][Range(-1,1)]
    private sbyte x = 0;
    /// <summary>
    /// Поворот по оси Х
    /// </summary>
    public sbyte X
    {
        get { return x; }
        set { x = value; }
    }

    /// <summary>
    /// Поворот по оси Y
    /// </summary>
    [SerializeField]
    [Range(-1, 1)]
    private sbyte y = 0;
    /// <summary>
    /// Поворот по оси Y
    /// </summary>
    public sbyte Y
    {
        get { return y; }
        set { y = value; }
    }

    /// <summary>
    /// Поворот по оси Z
    /// </summary>
    [SerializeField]
    [Range(-1, 1)]
    private sbyte z = 1;
    /// <summary>
    /// Поворот по оси Z
    /// </summary>
    public sbyte Z
    {
        get { return z; }
        set { z = value; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, z * speed * Time.deltaTime);
    }
}
