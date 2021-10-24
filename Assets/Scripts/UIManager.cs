using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    //pour accéder à la fonction plus facilement
    #region Singleton class: UIManager
    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    [Header("Level Progress UI")]
    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] Image progressFillImage;

    [Space]
    [SerializeField] TMP_Text levelCompletedText;

    [Space]
    [SerializeField] Image fadePanel;
    void Start()
    {
        fadeAtStart();
        progressFillImage.fillAmount = 0f;
        setLevelProgressText();
    }

    void setLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level+1).ToString();

    }

    // Update is called once per frame
    public void UpdateLevelProgress()
    {
        float val = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects); //to flip -1
        progressFillImage.DOFillAmount(val, .4f);
    }

    public void showLevelCompleted()
    {
        levelCompletedText.DOFade(1f, .6f).From(0f);
    }

    public void fadeAtStart()
    {
        fadePanel.DOFade(0f, 1.3f).From(1f);
    }
}
