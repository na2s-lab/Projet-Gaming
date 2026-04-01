using UnityEngine;

public class ObjectifFloat : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float vitesse = 2f;

    private Vector3 positionInitiale;

    void Start()
    {
        positionInitiale = transform.position;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * vitesse) * amplitude;
        transform.position = new Vector3(
            positionInitiale.x,
            positionInitiale.y + offsetY,
            positionInitiale.z
        );
    }
}