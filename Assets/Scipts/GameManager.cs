using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Configuration")]
    public int objectifsRequis = 3;     // Nombre d'étoiles à remplir
    public GameObject pcObject;         // PC à débloquer
    public Image[] etoilesImages;       // Array des étoiles UI
    public Sprite etoileVide;           // Sprite étoile grise
    public Sprite etoilePleine;         // Sprite étoile dorée
    public TextMeshProUGUI compteurText; // "3/3"

    int objectifsCollectes = 0;
    bool pcDebloque = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void CollecterObjectif()
    {
        objectifsCollectes++;

        // Mettre l'étoile en doré
        if (objectifsCollectes <= objectifsRequis && objectifsCollectes - 1 < etoilesImages.Length)
        {
            etoilesImages[objectifsCollectes - 1].sprite = etoilePleine;
        }

        UpdateUI();

        // Débloquer PC
        if (objectifsCollectes >= objectifsRequis && !pcDebloque)
        {
            pcDebloque = true;
            if (pcObject != null)
            {
                Collider2D colliderPC = pcObject.GetComponent<Collider2D>();
                if (colliderPC != null)
                    colliderPC.enabled = true;
            }
            Debug.Log("✅ PC DÉBLOQUÉ !");
        }
    }

    void UpdateUI()
    {
        if (compteurText != null)
            compteurText.text = $"{objectifsCollectes}/{objectifsRequis}";
    }

    public bool EstPCDebloque()
    {
        return pcDebloque;
    }

    public int GetObjectifsCollectes()
    {
        return objectifsCollectes;
    }
}
