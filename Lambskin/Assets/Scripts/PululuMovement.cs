using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PululuMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int Speed = 5;
    private bool isMoving = false; // Variable para rastrear si el jugador se está moviendo.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MovePlayer(targetPosition);
        }
    }

    private void MovePlayer(Vector2 targetPosition)
    {
        if (!isMoving)
        {
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            rb.velocity = moveDirection * Speed;

            // Iniciar el movimiento y detenerlo cuando se alcance el objetivo.
            StartCoroutine(StopMovementOnArrival(targetPosition));
        }
    }

    private IEnumerator StopMovementOnArrival(Vector2 targetPosition)
    {
        isMoving = true;
        while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            yield return null;
        }
        rb.velocity = Vector2.zero;
        isMoving = false;
    }
}
