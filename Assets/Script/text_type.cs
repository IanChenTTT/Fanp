using UnityEngine;  
using UnityEngine.UI;  
using System.Collections;  
public class Text_type : MonoBehaviour  
{  
    public float letterPause = 1f;  
    private string word;  
    private Text text;  
    void Start()  
    {  
        word = GetComponent<Text>().text;  
        text = GetComponent<Text>();  
        text.text = "";  
        StartCoroutine(TypeText());  
    }  
    private IEnumerator TypeText()  
    {  
        foreach (char letter in word.ToCharArray())  
        {  
            text.text += letter;  
            yield return new WaitForSeconds(letterPause);  
        } 
    }  
}  