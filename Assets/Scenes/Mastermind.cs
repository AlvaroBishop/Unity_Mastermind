using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour
{
    public Image[] resultImage;
    public GameObject[] slots;
    public Color[] colors;
    public Color correctPlace, wrong, correctColor;
    public Text resultText;
    public GameObject mastermindPanel;
    
    private GameObject[][] childObjects;
    private int actualSlot = 0;
    private int actualImageIndex = 0;
    private int[] resultImageNumber = new int[] { 7, 8, 10, 11 };
    int[] randomNumbers = new int[] {6,6,6,6};

    int[] imageNumber = new int[] { 2, 3, 4, 5};
    
    void Start()
    {
        childObjects = new GameObject[slots.Length][];

        // Access child game objects of slots array
        for (int i = 0; i < slots.Length; i++)
        {
            Transform[] children = slots[i].GetComponentsInChildren<Transform>();
            childObjects[i] = new GameObject[children.Length];

            // Save the parent object itself
            childObjects[i][0] = slots[i];

            // Save the children of each slot
            for (int j = 1; j < children.Length; j++)
            {
                childObjects[i][j] = children[j].gameObject;
            }
        }
        
        SetUpResult();

    }
    public void AddCircle(GameObject button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Image gameImage = childObjects[actualSlot][imageNumber[actualImageIndex]].GetComponent<Image>();
        gameImage.color = buttonImage.color;

        actualImageIndex++;
        if (actualImageIndex == imageNumber.Length)
        {
            actualImageIndex = 0;
            actualSlot++;
        }
    }

    void SetUpResult()
    {
        Debug.Log("Setup");
        
        int n = 0;
        foreach (Image image in resultImage)
        {
            int random = Random.Range(0, colors.Length);    
        
            do
            {
                random = Random.Range(0, colors.Length);
                image.color = colors[random];
                Debug.Log(checkDuplicity(randomNumbers, random));
            } while (checkDuplicity(randomNumbers, random) != false);

            randomNumbers[n] = random;
            Debug.Log(randomNumbers[n]);

            n++;

        }

    }

    bool checkDuplicity(int[] array, int number)
    {
        bool isRepeated = false;
        for(int i = 0; i < array.Length; i++)
        {
            if (number == array[i])
            {
                Debug.Log("Number: " + number + " Array: " + array[i]);
                isRepeated = true;
            }
        }
        

        return isRepeated;
    }
}