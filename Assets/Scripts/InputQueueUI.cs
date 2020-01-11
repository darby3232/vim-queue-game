using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputQueueUI : MonoBehaviour
{

    public List<TextMeshProUGUI> texts;

    private Queue<char> inputText = new Queue<char>();

    private void Start()
    {
        for (int i = 0; i < texts.Count; i++)
            inputText.Enqueue(' ');
    }

    public void AddInput(char input){
        inputText.Enqueue(char.ToUpper(input));
    
        if(inputText.Count > texts.Count)
            inputText.Dequeue();

        for(int i = texts.Count - 1; i >= 0; i--){
            texts[texts.Count - (i + 1)].text = char.ToString(inputText.ToArray()[i]);
        }
    }
}
