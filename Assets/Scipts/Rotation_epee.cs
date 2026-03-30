using UnityEngine;

public class RotationPiege : MonoBehaviour
{
    public float vitesse = 150f;

    void Update()
    {
        // On fait tourner le PIVOT, l'enfant suit automatiquement !
        transform.Rotate(0, 0, vitesse * Time.deltaTime);
    }
}