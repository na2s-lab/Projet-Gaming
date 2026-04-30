using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Niveau")]
    public int objectifsRequis = 2;
    public int objectifsCollectes = 0;

    [Header("PC")]
    public GameObject pcObject;

    [Header("UI Etoiles")]
    public Image[] etoilesImages;
    public Sprite etoileVide;
    public Sprite etoilePleine;
    public TextMeshProUGUI compteurText;

    [Header("UI Victoire")]
    public GameObject panneauVictoire;
    public TextMeshProUGUI texteVictoire;

    private bool pcDebloque = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InitialiserEtoiles();
        InitialiserUI();

        if (pcObject != null)
        {
            Collider2D col = pcObject.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }
    }

    void InitialiserEtoiles()
    {
        for (int i = 0; i < etoilesImages.Length; i++)
        {
            if (etoilesImages[i] != null)
            {
                etoilesImages[i].gameObject.SetActive(i < objectifsRequis);
                etoilesImages[i].sprite = etoileVide;
            }
        }
    }

    void InitialiserUI()
    {
        if (panneauVictoire != null)
            panneauVictoire.SetActive(false);
        UpdateUI();
    }

    public void CollecterObjectif()
    {
        if (objectifsCollectes >= objectifsRequis)
            return;

        objectifsCollectes++;
        UpdateUI();

        if (objectifsCollectes - 1 < etoilesImages.Length && etoilesImages[objectifsCollectes - 1] != null)
            etoilesImages[objectifsCollectes - 1].sprite = etoilePleine;

        if (objectifsCollectes >= objectifsRequis)
        {
            Victoire();
        }
    }

    void UpdateUI()
    {
        if (compteurText != null)
            compteurText.text = objectifsCollectes + "/" + objectifsRequis;
    }

    public void Victoire()
    {
        // PAS DE Time.timeScale = 0 → le jeu continue normalement
        if (panneauVictoire != null)
        {
            panneauVictoire.SetActive(true);
            texteVictoire.text = "Objectifs récoltés !\nPC disponible !";

            // Cache le message après 3 secondes
            StartCoroutine(CacherMessageVictoire());
        }

        // Débloque le PC
        pcDebloque = true;
        if (pcObject != null)
        {
            Collider2D col = pcObject.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = true;
        }
    }

    IEnumerator CacherMessageVictoire()
    {
        yield return new WaitForSeconds(3f);
        if (panneauVictoire != null)
            panneauVictoire.SetActive(false);
    }

    public bool EstPCDebloque()
    {
        return pcDebloque;
    }
}