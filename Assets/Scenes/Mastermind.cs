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
    int[] imageNumber = new int[] { 2, 3, 4, 5};
    int[] randomNumbers = new int[] {6,6,6,6};

    
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
            CheckResult();
            actualImageIndex = 0;
            
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
            } while (CheckDuplicity(randomNumbers, random) != false);

            randomNumbers[n] = random;

            n++;

        }

    }

    bool CheckDuplicity(int[] array, int number)
    {
        bool isRepeated = false;
        for(int i = 0; i < array.Length; i++)
        {
            if (number == array[i])
            {
                isRepeated = true;
            }
        }
        

        return isRepeated;
    }

    void CheckResult()
    {
        int counter = 0;
        for (int i = 0; i < resultImage.Length; i++)
        {
            Image resultImageSlot = childObjects[actualSlot][resultImageNumber[i]].GetComponent<Image>();
            CheckColors(counter, resultImageSlot.color, resultImageSlot);

        }
 
    }

    void CheckColors(int startIndex, Color color,Image image)
    {
        for (int i = startIndex; i < resultImage.Length; i++)
        {
            Debug.Log(resultImage[i].color);
            if (resultImage[i].color == color)
            {
                if (i == startIndex)
                {
                    image.color = correctPlace;
                }
                image.color = correctColor;
            }
        }
    }
}