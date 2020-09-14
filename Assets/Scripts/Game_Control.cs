using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Control : MonoBehaviour
{
    #region Parameters
    /// <summary>
    /// Ссылка на объект, содержащий генерацию объектов
    /// </summary>
    [SerializeField]
    private Generate_Object generateObject;
    /// <summary>
    /// Ссылка на объект, содержащий генерацию объектов
    /// </summary>
    public Generate_Object GenerateObject
    {
        get { return generateObject; }
        set { generateObject = value; }
    }

    

    /// <summary>
    /// Место генерации новых объектов
    /// </summary>
    [SerializeField]
    [Header("Place generation new object")]
    private Transform placeGeneration;
    /// <summary>
    /// Место генерации новых объектов
    /// </summary>
    public Transform PlaceGeneration
    {
        get { return placeGeneration; }
        set { placeGeneration = value; }
    }

    /// <summary>
    /// Родитель новых объектов
    /// </summary>
    [SerializeField]
    [Header("Parents of new objects")]
    private GameObject parent;
    /// <summary>
    /// Родитель новых объектов
    /// </summary>
    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    /// <summary>
    /// Объект меняющий свое положение положение
    /// </summary>
    [SerializeField]
    private RandomPositionOutsidePole objectChangePlace;
    /// <summary>
    /// Объект меняющий свое положение положение
    /// </summary>
    public RandomPositionOutsidePole ObjectChangePlace
    {
        get { return objectChangePlace; }
        set { objectChangePlace = value; }
    }

    /// <summary>
    /// Переодичность генерации новых объектов
    /// </summary>
    [SerializeField][Header("Frequency of occurrence (sec)")][Range(0.1f,5.0f)]
    private float periodicity = 1.0f;
    /// <summary>
    /// Переодичность генерации новых объектов
    /// </summary>
    public float Periodicity
    {
        get { return periodicity; }
        set { periodicity = value; }
    }

    /// <summary>
    /// Максималбьное количество объектов на сцене
    /// </summary>
    [SerializeField][Range(1,50)][Header("Maximum count of objects")]
    private byte maxCount = 20;
    /// <summary>
    /// Максималбьное количество объектов на сцене
    /// </summary>
    public byte MaxCount
    {
        get { return maxCount; }
        set { maxCount = value; }
    }

    /// <summary>
    /// Количество объектов на сцене
    /// </summary>
    private byte objectcount = 0;

    /// <summary>
    /// Отчет времени для генерации объектов
    /// </summary>
    private float timer = 0;
    #endregion

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= periodicity)
        {
            timer = 0;
            if(objectcount < maxCount)
            {
                generateObject.CreateMeteor(placeGeneration.position, parent);
                objectcount++;
            }
            objectChangePlace.SetNewRandomPosition();
        }
    }

    
}
