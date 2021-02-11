using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;
    


public class InputData : MonoBehaviour
{
    public TextMeshProUGUI takentext;
    TouchScreenKeyboard keyboard;
    static public string inputData;
    public string ChangeData()
    {
        return inputData;
    }
    public void ChangeDataType()
    {
        inputData = takentext.text.ToString();
       
    }
    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
    }
}
