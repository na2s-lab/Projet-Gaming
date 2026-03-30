using UnityEngine;
using UnityEngine.SceneManagement; // Obligatoire pour changer de scène

public class PiegeDommage : MonoBehaviour
{
    // Cette fonction se déclenche dès qu'un objet entre dans le collider de l'épée
    private void OnTriggerEnter2D(Collider2D other)
    {
        // On vérifie si l'objet qui nous touche a le Tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touché ! Le joueur est mort.");

            // On recharge la scène actuelle pour recommencer
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}