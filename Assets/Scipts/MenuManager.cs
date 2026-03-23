using UnityEngine;
using UnityEngine.SceneManagement; 


public class MenuManager : MonoBehaviour
{
    public GameObject panelReglages;
    public GameObject panelCredits;


    public void Jouer()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void AfficherReglages()
    {
        panelReglages.SetActive(true);
    }

    public void CacherReglages()
    {
        panelReglages.SetActive(false);
    }

    public void AfficherCredits()
    {
        panelCredits.SetActive(true);
    }

    public void CacherCredits()
    {
        panelCredits.SetActive(false);
    }

    public void QuitterLeJeu()
    {
        Application.Quit();
        Debug.Log("Le jeu se ferme !");
    }
}
