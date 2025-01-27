using Sirenix.OdinInspector;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "ClientData", menuName = "Scriptable Objects/ClientData")]
public class ClientData : ScriptableObject
{
    [SerializeField] private AnimatorController _controller;
    public AnimatorController Controller => _controller;

    [SerializeField] private RequestData _requestData;
    public RequestData RequestData => _requestData;
    [SerializeField] private DialogData _welcomeDialog;
    public DialogData WelcomeDialog => _welcomeDialog;
    [SerializeField] private DialogData _successDialog;
    public DialogData SuccessDialog => _successDialog;
    [SerializeField] private DialogData _failedDialog;
    public DialogData FailedDialog => _failedDialog;
}
