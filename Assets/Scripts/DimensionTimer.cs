using System;
using TMPro;
using UnityEngine;

public class DimensionTimer : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private float maxAllowedTime;
    [SerializeField] private GameObject player;

    public TextMeshProUGUI ClockText { get; set; }
    
    public static DimensionTimer Instance { get; private set; }

    private float _timeLeft;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _timeLeft = maxAllowedTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetTimer()
    {
        _timeLeft = maxAllowedTime;
    }

    private void Tick()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
        else
        {
            _timeLeft = 0;
        }
    }

    private void Display()
    {
        if (_timeLeft < 15)
            ClockText.color = Color.yellow;

        if (_timeLeft < 10)
            ClockText.color = Color.red;
        
        ClockText.text = $"Seconds till switch: {Mathf.RoundToInt(_timeLeft)}";
    }

    private void Update()
    {
        if (_timeLeft == 0)
        {
            LoseManager.Instance.FailPlayer(player, 1);
        }
        else
        {
            Display();
            Tick();
        }
    }
}