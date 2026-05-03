using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireReglages : MonoBehaviour
{
    public void Retour()
    {
        SceneManager.LoadScene("MainMenu");
    }
}