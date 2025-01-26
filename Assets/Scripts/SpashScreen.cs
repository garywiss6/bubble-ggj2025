using UnityEngine;

public class SpashScreen : MonoBehaviour
{
    public void LaunchGame()
    {
        StateManager.Instance.Init();
    }
}
