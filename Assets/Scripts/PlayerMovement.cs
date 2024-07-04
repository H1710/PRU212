using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator myAnim;

    [SerializeField]
    private float speed;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;


    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", body.velocity.x);
        myAnim.SetFloat("moveY", body.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {

            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }

        if (isAttacking) 
        {
            body.velocity = Vector2.zero;

            attackCounter -= Time.deltaTime;
            if (attackCounter < 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.T)) 
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
}
