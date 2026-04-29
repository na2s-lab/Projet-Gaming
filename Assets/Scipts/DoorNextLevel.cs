using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorNextLevel : MonoBehaviour
{
    public string nomSceneSuivante;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneFader.Instance.LoadSceneWithFade(nomSceneSuivante);
        }
    }
}