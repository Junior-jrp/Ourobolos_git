using UnityEngine;

public class HeightLimiter : MonoBehaviour
{
    public float maxHeight = 10.0f;   // Raio máximo permitido
    public float minHeight = 1.0f;    // Raio mínimo permitido
    public Transform worldCenter;     // Centro do mundo esférico

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        LimitCharacterHeight();
    }

    void LimitCharacterHeight()
    {
        // Verificar a distância do personagem ao centro do mundo esférico
        float distanceToCenter = Vector3.Distance(transform.position, worldCenter.position);

        if (distanceToCenter > maxHeight)
        {
            // Ajustar a posição do personagem para estar dentro do raio máximo permitido
            Vector3 directionToCenter = (worldCenter.position - transform.position).normalized;
            Vector3 targetPosition = worldCenter.position + directionToCenter * maxHeight;

            // Movendo suavemente o personagem para a posição alvo
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);

            // Parar a velocidade vertical para evitar que continue subindo
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
        else if (distanceToCenter < minHeight)
        {
            // Ajustar a posição do personagem para estar dentro do raio mínimo permitido
            Vector3 directionToCenter = (worldCenter.position - transform.position).normalized;
            Vector3 targetPosition = worldCenter.position + directionToCenter * minHeight;

            // Movendo suavemente o personagem para a posição alvo
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);

            // Parar a velocidade vertical para evitar que continue descendo
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
    }
}
