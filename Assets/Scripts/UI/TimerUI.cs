using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private EnemySpawnTimer timer;

    [SerializeField]
    private Image timerBar;

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText;

    private void Update()
    {
        timerBar.fillAmount = 1 - 1 / timer.LevelTime * timer.ElapsedTime;
        timerText.text = $"{Mathf.Floor(timer.TimeLeft / 60)}:{Mathf.Round(timer.TimeLeft % 60)}";
    }
}
