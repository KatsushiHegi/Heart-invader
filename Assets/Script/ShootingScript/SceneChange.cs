using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Inspector
    [SerializeField] private string _nextSceneName;
    private void ChangeScene()
    {
        SceneManager.LoadSceneAsync(_nextSceneName);
    }
}