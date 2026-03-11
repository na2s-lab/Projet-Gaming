using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject settingsPanel;

    public string sceneJouer = "SampleScene";

    public void Jouer()
    {
        SceneManager.LoadScene(sceneJouer);
    }

    public void AfficherCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CacherCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void AfficherParametres()
    {
        settingsPanel.SetActive(true);
    }

    public void CacherParametres()
    {
        settingsPanel.SetActive(false);
    }
}
