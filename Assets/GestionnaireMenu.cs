using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelReglages;
    public GameObject panelCredits;

    void Start()
    {
        // S'assurer que les panels sont fermés au démarrage
        panelReglages.SetActive(false);
        panelCredits.SetActive(false);
    }

    // Bouton JOUER
    public void Jouer()
    {
        SceneManager.LoadScene("Level-1");
    }

    // Bouton RÉGLAGES
    public void OuvrirReglages()
    {
        panelReglages.SetActive(true);
        panelCredits.SetActive(false);
    }

    // Bouton CRÉDITS
    public void OuvrirCredits()
    {
        panelCredits.SetActive(true);
        panelReglages.SetActive(false);
    }

    // Bouton FERMER (dans chaque panel)
    public void FermerPanels()
    {
        panelReglages.SetActive(false);
        panelCredits.SetActive(false);
    }
}
