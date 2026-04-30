using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float delaiAvantReset = 1f;
    public Animator animator;

    private bool estMort = false;
    private Rigidbody2D rb;
    private PlayerController movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerController>();
    }

    public void Die()
    {
        if (estMort) return;
        estMort = true;

        if (movement != null)
            movement.enabled = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = false;
        }

        if (animator != null)
            animator.SetTrigger("Die");

        StartCoroutine(MortPuisReset());
    }

    IEnumerator MortPuisReset()
    {
        yield return new WaitForSeconds(delaiAvantReset);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}