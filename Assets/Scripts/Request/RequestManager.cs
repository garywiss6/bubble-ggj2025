using UnityEngine;

public class RequestManager : SingletonBehaviour<RequestManager>
{
    private RequestData _request;
    public event DelegateDefinition.void_D_Request onAddRequest;

    public void AddRequest(RequestData request)
    {
        _request = request;
        onAddRequest?.Invoke(request);
    }

    public bool SendBubbleTea(BubbleTea bubbleTea)
    {
        return _request.AnswerRequest(bubbleTea);
    }
}
