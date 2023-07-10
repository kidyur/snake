using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaiseScore : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    private int _scoreAmount = 0;

    public void IncreaseScore()
    {
        _scoreAmount += 10;
        score.text = "Score: " + _scoreAmount.ToString();
    }
}
