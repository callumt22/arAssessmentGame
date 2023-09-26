using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareNumber : MonoBehaviour
{
    public int answerNumber;
    public GameObject numberPrefab;
    GameObject instance;
    NumberSelector numSelector;
    public GameObject tryAgain;
    public GameObject wellDone;
    IEnumerator wait;
    float xPos;
    float yPos;
    float zPos;
    Vector3 spawnPos;
    public Transform camPosition;
    public List<int> numberList;
    public int numberIndex;
    public int selectedNumber;
    public GameObject winScreen;
    public float mistakeCount = 0;
    public AudioSource wellDoneAudio;
    public AudioSource correct;

    

    void Start()
    {
        numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //create list of values
        RandomizeSpawnPoint();
        SelectNumber();

        
    }


    void Update()
    {
        if (answerNumber == selectedNumber)
        {
            wait = WaitAndHide(wellDone); //pass message to function to display for a second

            correct.Play();
            wellDoneAudio.Play();

            StartCoroutine(wait);

            Destroy(instance); //destroy instance of the prefab object

            if (numberList.Count == 1)
            {
                winScreen.SetActive(true); //shows win screen when all the numbers have been correctly identified
            }

            else
            {
                numberList.RemoveAt(numberIndex); //removes number that was correctly guessed from the list
                RandomizeSpawnPoint();
                SelectNumber();
            }
            
        }

        else if (answerNumber != 0)
        {
            wait = WaitAndHide(tryAgain);
            mistakeCount++; //if answer is wrong then add to mistake count to be displayed at the end
            StartCoroutine(wait);
        }
        
    }

    private IEnumerator WaitAndHide(GameObject message)
    {
        message.SetActive(true); //displays correct/try again message
        answerNumber = 0; //resets answer number

        yield return new WaitForSeconds(1f);
        message.SetActive(false);
    }

    void RandomizeSpawnPoint()
    {
        xPos = Random.Range(-3, 3);
        yPos = Random.Range(-1.5f, 1.5f);
        zPos = Random.Range(-3, 3);

        spawnPos = new Vector3(xPos, yPos, zPos); //generates a randomized spawn point for the number to appear at

    }

    void SelectNumber()
    {
        numberIndex = Random.Range(0, numberList.Count); //selects a random index from the number list
        selectedNumber = numberList[numberIndex]; //assigns selectedNumber the int value

        instance = Instantiate(numberPrefab, camPosition.position + spawnPos, Quaternion.LookRotation(Vector3.up)); //instantiates game object in relation to the player
        numSelector = instance.GetComponentInChildren<NumberSelector>();
        numSelector.textNumber = selectedNumber;
    }
}
