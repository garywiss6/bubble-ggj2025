using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/DialogData")]
public class DialogData : ScriptableObject
{
    [SerializeField] List<string> _Dialogs = new List<string>();
    public List<string> Dialogs => _Dialogs;
}
