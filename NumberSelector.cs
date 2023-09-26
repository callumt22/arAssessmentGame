using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSelector : MonoBehaviour
{
    TextMeshProUGUI numberText;
    public int textNumber;

    // Start is called before the first frame update
    void Start()
    {
        numberText = GetComponent<TextMeshProUGUI>();

        SetNumber();

    }

    void SetNumber()
    {
        numberText.text = textNumber.ToString(); //sets selected random number to text object
        Debug.Log(textNumber);
    }
}
