using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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
    private ClientData CurrentClient 
    {
        get  {return _ClientList[_CurrentClient];}
    }
    void Awake()
    {
        _instance = this;
    }

    public void EnterClient()
    {
        _Renderer.transform.DOMoveX(5.5f, 1.0f).OnComplete(() =>
        {
            DialogManager.Instance.OnDialogFinished += OnDialogFinished;
            DialogManager.Instance.LaunchDialog(CurrentClient.WelcomeDialog);
        });
        //Mettre une sinusoide sur le Y
    }

    void OnDialogFinished()
    {
        OnClientFinishWelcome?.Invoke();
    }
    
    public void ExitClient()
    {
        DialogManager.Instance.OnDialogFinished -= OnDialogFinished;
        _Renderer.transform.DOMoveX(12f, 1.0f);
        _CurrentClient++;
    }

    
    // Ouais j'aurais du faire un enum des State en fait, c'est crade, trop tard
    public void SetClientWelcomeSprite()
    {
        ChangeSprite(CurrentClient.WelcomeSprite);
    }

    public void StopTalking()
    {
        SetClientWelcomeSprite();
    }

    public void SetClientTalkingSprite()
    {
        ChangeSprite(CurrentClient.TalkSprite);
    }

    void ChangeSprite(Sprite sprite)
    {
        _Renderer.sprite = sprite;
    }

    
}
