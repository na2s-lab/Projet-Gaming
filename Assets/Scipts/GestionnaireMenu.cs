using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireMenu : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("Niveau 1");
    }

    public void OuvrirReglages()
    {
        SceneManager.LoadScene("SceneReglages");
    }

    public void OuvrirCredits()
    {
        SceneManager.LoadScene("SceneCredits");
    }
}