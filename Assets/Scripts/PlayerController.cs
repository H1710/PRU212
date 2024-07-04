using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool facingRight = true;
    private bool isMoving = false;

    public LayerMask solidObjects;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            // Capture input from player
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Update animation parameters based on input
            UpdateAnimation();

            // StartCoroutine(Move(targetPos));        
            // Flip the player sprite based on direction
            if (movement.x < 0 && facingRight)
            {
                Flip();
            }
            else if (movement.x > 0 && !facingRight)
            {
                Flip();
            }
        }
    }

    // private void UpdateMovement()
    // {
    //     animator.SetFloat
    // }

    private void UpdateAnimation()
    {
        if (movement != Vector2.zero)
        {
            // UpdateMovement();
            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            var targetPos = transform.position;
            targetPos.x += movement.x;
            targetPos.y += movement.y;
            if(IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos) {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects) != null) {
            return false;
        }
        return true;
    }
}
