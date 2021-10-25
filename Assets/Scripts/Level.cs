using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Space]
    [SerializeField] ParticleSystem WinFx;
    public int objectsInScene, totalObjects;

    [SerializeField] Transform objectsParent;


    [Space]
    [Header ("Level Objects & Obstacles")]
    [SerializeField] Material groundMaterial;
    [SerializeField] Material objectMaterial;
    [SerializeField] Material obstacleMaterial;
    [SerializeField] SpriteRenderer groundBorderSprite;
    [SerializeField] SpriteRenderer groundSideSprite;
    [SerializeField] Image progressFillImage;

    [SerializeField] SpriteRenderer progressBarFadeSprite;

    [Space]
    [Header("Level Colors")]
    [Header("Ground")]
    [SerializeField] Color groundColor;
    [SerializeField] Color bordersColor;
    [SerializeField] Color sideColor;
    [Header("Objects & Obstacles")]
    [SerializeField] Color obstacleColor;
    [SerializeField] Color objectColor;
    [Header("UI (progress")]
    [SerializeField] Color progressFillColor;
    [Header("Background")]
    [SerializeField] Color cameraColor;
    [SerializeField] Color fadeColor;
    void Start()
    {
        countObjects();
        updateLevelColors();
    }

    // Update is called once per frame
    void countObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void playWinFx()
    {
        WinFx.Play();
    }

    void updateLevelColors()
    {
        //ground
        groundMaterial.color = groundColor;
        groundSideSprite.color = sideColor;
        groundBorderSprite.color = bordersColor;
        //obstacles & objects
        obstacleMaterial.color = obstacleColor;
        objectMaterial.color = objectColor;
        //progress bar
        progressFillImage.color = progressFillColor;

        Camera.main.backgroundColor = cameraColor;
        progressBarFadeSprite.color = progressFillColor;
    }

    private void OnValidate()
    {
        //quand on change les couleurs dans l'inspecteur
        updateLevelColors();
    }
}
