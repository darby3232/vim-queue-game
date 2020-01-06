using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputQueueUI : MonoBehaviour
{

    public List<TextMeshPro> texts;

    private Queue<char> inputText = new Queue<char>();

    public void AddInput(char input){
        inputText.Enqueue(char.ToUpper(input));
    
        if(inputText.Count > texts.Count)
            inputText.Dequeue();

        for(int i = 0; i < texts.Count; i++){
            texts[i].text = char.ToString(inputText.ToArray()[i]);
        }
    }
}
