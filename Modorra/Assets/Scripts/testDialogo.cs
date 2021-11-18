using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testDialogo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] setences;
    private int index;
    public float typingSpeed;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach(char letter in setences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
