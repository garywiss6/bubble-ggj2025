using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ClientData", menuName = "Scriptable Objects/ClientData")]
public class ClientData : ScriptableObject
{
  [FoldoutGroup("Sprites"), SerializeField] private Sprite _WelcomeSprite;
  public Sprite WelcomeSprite => _WelcomeSprite;
  [FoldoutGroup("Sprites"),SerializeField] private Sprite _TalkSprite;
  public Sprite TalkSprite => _TalkSprite;
  [FoldoutGroup("Sprites"),SerializeField] private Sprite _SipSprite;
  public Sprite SipSprite => _SipSprite;
  [FoldoutGroup("Sprites"),SerializeField] private Sprite _SipHand;
  public Sprite SipHand => _SipHand;
  [FoldoutGroup("Sprites"),SerializeField] private Sprite _HappySprite;
  public Sprite HappySprite => _HappySprite;
  [FoldoutGroup("Sprites"),SerializeField] private Sprite _HappyHand;
  public Sprite HappyHand => _HappyHand;
  
  [SerializeField] private RequestData _requestData;
  public RequestData RequestData => _requestData;
  [SerializeField] private DialogData _welcomeDialog;
  public DialogData WelcomeDialog => _welcomeDialog;
  [SerializeField] private DialogData _successDialog;
  public DialogData SuccessDialog => _successDialog;
  [SerializeField] private DialogData _failedDialog;
  public DialogData FailedDialog => _failedDialog;
}
