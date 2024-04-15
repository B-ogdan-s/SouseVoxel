using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class NetworkRunnerHandler : MonoBehaviour
{
    [SerializeField] private NetworkRunner _runnerPrefab;
    private NetworkRunner _runner;

    public static NetworkRunnerHandler Instance { get; private set; }
    public NetworkRunner Runner => _runner;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    async public void StartGame(GameMode gameMode, int sceneId)
    {
        _runner = Instantiate(_runnerPrefab);
        _runner.ProvideInput = true;

        var scene = SceneRef.FromIndex(sceneId);
        var sceneInfo = new NetworkSceneInfo();

        if (scene.IsValid)
        {
            sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
        }

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            SessionName = "TestRoom",
            Scene = scene,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }
}
