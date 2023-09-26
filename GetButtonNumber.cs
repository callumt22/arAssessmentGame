using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetButtonNumber : MonoBehaviour
{
    public CompareNumber compareNum;


    public void NumberChoice()
    {
        compareNum.answerNumber = int.Parse(GetComponentInChildren<TextMeshProUGUI>().text);
    }
}
