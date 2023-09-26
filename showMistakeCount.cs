using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showMistakeCount : MonoBehaviour
{
    public CompareNumber compNum;
    public TextMeshProUGUI mistakesText;
    // Start is called before the first frame update
    void Awake()
    {
        mistakesText = GetComponent<TextMeshProUGUI>();
        mistakesText.text = "You won the game with " + compNum.mistakeCount + " mistake(s)";
    }
}
