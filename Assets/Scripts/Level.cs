using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Singleton class: Level
    public static Level Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    public int objectsInScene, totalObjects;

    [SerializeField] Transform objectsParent;
    void Start()
    {
        countObjects();
    }

    // Update is called once per frame
    void countObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }
}
