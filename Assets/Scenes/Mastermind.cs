using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour
{
    public GameObject result;
    public GameObject[] slots;
    private GameObject[][] childObjects;
    private int actualSlot = 0;
    private int actualImageIndex = 0;
    int[] numeros = new int[] { 2, 3, 4, 5, 7, 8, 10, 11 };

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

    }

    void ShowChildObjectNames()
    {
        // Show the names of child objects and children of child objects
        for (int i = 0; i < childObjects.Length; i++)
        {
            Debug.Log("Slot " + (i + 1) + ":");
            for (int j = 2; j < childObjects[i].Length; j++)
            {
                if (childObjects[i][j] != null)
                {
                    Debug.Log("Child " + j + " name: " + childObjects[i][j].name);
                }
            }
        }
        Debug.Log((childObjects[0][2]));
    }

    public void AddCircle(GameObject button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Image gameImage = childObjects[actualSlot][numeros[actualImageIndex]].GetComponent<Image>();
        gameImage.color = buttonImage.color;

        actualImageIndex++;
        if (actualImageIndex == numeros.Length)
        {
            actualImageIndex = 0;
            actualSlot++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}