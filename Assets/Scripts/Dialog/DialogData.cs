using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public struct ChoiceText
{
    public string message;
    public DialogData response;
}

[Serializable]
public class DialogText 
{
    public enum SpeakerType
    {
        Barista,
        Customer
    }
    
    public SpeakerType speaker;
    [TextArea(4, 10)]
    public string message;
    public bool hasChoice;
    
    [ShowIf("hasChoice")]
    public List<ChoiceText> choices;
}


[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/DialogData")]
public class DialogData : SerializedScriptableObject
{
    [SerializeField] List<DialogText> _Dialogs = new List<DialogText>();
    public List<DialogText> Dialogs => _Dialogs;
}
