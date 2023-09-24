using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharControllerNew : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ChekingGround();
    }

    [SerializeField] private LayerMask groundMask; // Маска слоя, устанавливается в Испекторе
    [SerializeField] private Vector2 groundCheckSize = Vector2.one; // Размер "квадрата", проверяющего слой земли
    [SerializeField] private Transform groundCheckTransform; // Компонент Трансформ, объекта GroundCheck
    [SerializeField] private bool onGround = false;

    private void ChekingGround()
    {
        if (onGround == false)
        {
            onGround = rb.IsTouchingLayers(groundMask) && Physics2D.OverlapBox(groundCheckTransform.position, groundCheckSize, 0f, groundMask);
        }
        else
        {
            onGround = Physics2D.OverlapBox(groundCheckTransform.position, groundCheckSize, 0f, groundMask);
        }
    }

    private void OnDrawGizmos() // Отрисовка "квадрата", проверяющего слой земли
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckTransform.position, groundCheckSize);
    }
}
