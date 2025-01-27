using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

//J'ai mis Client au lieu de Customer, pas grave c'est du franglais 
public class ClientManager : MonoBehaviour
{
    static private ClientManager _instance;

    static public ClientManager Instance => _instance;

    [SerializeField] private SpriteRenderer _Renderer;
    [SerializeField] private SpriteRenderer _HandRenderer;

    [SerializeField] private List<ClientData> _ClientList = new List<ClientData>();
    private int _CurrentClient = 0;

    private DelegateDefinition.void_D_void _OnClientFinishWelcome;

    public DelegateDefinition.void_D_void OnClientFinishWelcome
    {
        get
        {
            return _OnClientFinishWelcome;
        }
        set
        {
            _OnClientFinishWelcome = value;
        }
    }
    

    //Yolo
    public ClientData CurrentClient 
    {
        get  {return _ClientList[_CurrentClient];}
    }
    void Awake()
    {
        _instance = this;
    }

    public void EnterClient()
    {
        _Renderer.material.SetFloat("_Fill", 0);
        _HandRenderer.material.SetFloat("_Fill", 0);
        ClientAnimator.Instance._trigger += EnterClientFinished;
        ClientAnimator.Instance.SetController(CurrentClient.Controller);
        ClientAnimator.Instance.Trigger();
    }

    private void EnterClientFinished()
    {
        ClientAnimator.Instance._trigger -= EnterClientFinished;
        DialogManager.Instance.OnDialogFinished += OnDialogFinished;
        DialogManager.Instance.LaunchDialog(CurrentClient.WelcomeDialog);
    }

    public void ClientLoseDialog()
    {
        ClientAnimator.Instance._trigger -= EnterClientFinished;
        DialogManager.Instance.OnDialogFinished += OnDialogFinished;
        DialogManager.Instance.LaunchDialog(CurrentClient.FailedDialog);
    }
    public void ClientWinDialog()
    {
        ClientAnimator.Instance._trigger -= EnterClientFinished;
        DialogManager.Instance.OnDialogFinished += OnDialogFinished;
        DialogManager.Instance.LaunchDialog(CurrentClient.SuccessDialog);
    }

    public void FillClient(float time, float percent)
    {
        float tw = 0;
        DOTween.To(() => tw, x => tw = x, percent, time).SetEase(Ease.InQuad)
            .OnUpdate(() =>
            {
                _Renderer.material.SetFloat("_Fill", tw);
                _HandRenderer.material.SetFloat("_Fill", tw);
            });
    }

    void OnDialogFinished()
    {
        OnClientFinishWelcome?.Invoke();
    }
    
    public void ExitClient()
    {
        DialogManager.Instance.OnDialogFinished -= OnDialogFinished;
        _CurrentClient++;
        if (_CurrentClient >= _ClientList.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //_CurrentClient = 0;
        }
    }
}
