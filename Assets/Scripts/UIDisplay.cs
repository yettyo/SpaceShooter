using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.getHealth();
    }
    void Update()
    {
        healthSlider.value = playerHealth.getHealth();
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}
