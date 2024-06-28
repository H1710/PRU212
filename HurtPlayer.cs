using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;



    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        if (isTouching) 
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0) 
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player") 
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player") 
        {
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player") 
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
