using UnityEngine;
using UnityEngine.SceneManagement; 

public class degat_eppe : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        Debug.Log("L'épée a été touchée par : " + collision.gameObject.name);

       
        if (collision.CompareTag("Player"))
        {
            Debug.Log("MORT : Le joueur a touché l'épée ! Rechargement...");

            
            string nomDeLaScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nomDeLaScene);
        }
    }
}