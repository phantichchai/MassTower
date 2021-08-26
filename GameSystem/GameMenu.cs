using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;


public class GameMenu : Singleton<GameMenu>
{
    [SerializeField] private TMP_Text timeSpeedText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text starText;
    [SerializeField] private Image starBar;

    public TowerButton ClickButton { get; set; }
    public bool IsGameOver { get; set; }
    public static Vector3 OriginPosition = new Vector3(-80f, -45f, 0);
    public static int GridWidth = 16;
    public static int GridHeight = 9;
    public static float CellSize = 10f;
    public static float maxHealthValue;
    public static float maxStarValue;
    private Grid<Tiles> grid;

    public float HealthValue { get; set; }
    public float MoneyValue { get; set; }
    public int StarValue { get; set; }

    private bool spawnActive = false;
    private bool waveActive = false;
    private List<Wave> waves = new List<Wave>();

    private static Vector3 CENTER = new Vector3(-10f, 0f, 0f);
    private void Start()
    {
        HealthValue = 30f;
        MoneyValue = 500f;
        StarValue = 3;
        maxHealthValue = HealthValue;
        maxStarValue = StarValue;
        IsGameOver = false;
        foreach(Wave w in GetComponents<Wave>())
        {
            waves.Add(w);
        }
    }

    public void ClickStartWave()
    {
        StartWave();
        SoundManager.Instance().ClickButton();
    }

    public void StartWave()
    {
        UtilsClass.CreateWorldTextPopup("Wave is starting", CENTER, 1);
        waves[0].StartWave();
        spawnActive = true;
        waveActive = true;
    }

    public void EndWave()
    {
        UtilsClass.CreateWorldTextPopup("Wave is ending", CENTER, 1);
        Destroy(waves[0]);
        waves.RemoveAt(0);
        spawnActive = false;
    }

    private void Update()
    {
        UpdateText();
        if (!waveActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartWave();
            }
        }
        else
        {
            if (!spawnActive && !GameObject.FindGameObjectWithTag("Enemy"))
            {
                waveActive = false;
                if (waves.Count == 0 && HealthValue > 0)
                {
                    Debug.Log("victory" + (waves.Count == 0 && HealthValue > 0));
                    GetComponent<ReportMenu>().Victory();
                }
            }
        }

        if (HealthValue <= 0 && !IsGameOver)
        {
            IsGameOver = true;
            GetComponent<ReportMenu>().Gameover();
        }
    }

    public void MultiplyTime()
    {
        if (Time.timeScale > 2f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale++;
        }
        timeSpeedText.text = string.Format("{0}x", Time.timeScale);
        SoundManager.Instance().ClickButton();
    }

    public void PickButton(TowerButton towerButton)
    {
        SoundManager.Instance().ClickButton();
        ClickButton = towerButton;
        Hover.Instance().Activate(towerButton.Sprite);
    }

    public void PlaceTower()
    {
        ClickButton = null;
    }

    public void UpdateText()
    {
        healthText.text = HealthValue.ToString() + "/" + maxHealthValue;
        healthBar.fillAmount = HealthValue / maxHealthValue;
        moneyText.text = MoneyValue.ToString();
        starText.text = CalculateStar() + "/" + maxStarValue;
        starBar.fillAmount = StarValue / maxStarValue;
    }

    public string CalculateStar()
    {
        StarValue = (int) (HealthValue / (maxHealthValue / maxStarValue));
        return StarValue.ToString();
    }
}
