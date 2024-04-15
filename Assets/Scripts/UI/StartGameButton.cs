using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    public void StartAutoGame()
    {
        NetworkRunnerHandler.Instance.StartGame(Fusion.GameMode.AutoHostOrClient, _sceneId);
    }
}
