using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    Animator animator;
    bool IamRunning = false;
    bool IamComeInBack = false;
    bool first = true;
    Vector3 dir = Vector3.zero;
    Vector3 startPosition ;
    Vector3 EndPosition = Vector3.zero;
    
    float speedAnimation =20f;
    float timer =0f;

    bool endHurt = false;
    bool endAttack = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);


    }
    private void Update()
    {
        if (IamRunning)
        {
            
            if (Vector2.Distance(transform.position, EndPosition) < 2f)
            {
               // dir = Vector3.zero;
                animator.SetBool("run", false);
                animator.SetBool("kick", true);
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    animator.SetBool("run", true);
                    animator.SetBool("kick", false);
                    IamRunning = false;
                    IamComeInBack = true;
                    timer = 0f;


                }
            }
            else
            {
                transform.position += dir * speedAnimation * Time.deltaTime;
            }
            
        }
        if (IamComeInBack)
        {
            if (first)
            {
                dir = startPosition - EndPosition;
                dir.Normalize();
                animator.SetBool("kick", false);
                animator.SetBool("run", true);
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                first = false;
            }
            else {
                transform.position += dir * speedAnimation * Time.deltaTime;
                if (Vector2.Distance(transform.position, startPosition) < 2f)
                {
                    transform.position = startPosition;
                    animator.SetBool("run", false);
                    dir = Vector3.zero;
                    GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                    IamComeInBack = false;
                }
            }
            
        }
        if (endHurt)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                animator.SetBool("hurt", false);
                endHurt = false;
                timer = 0f;
            }
        }
        if (endAttack)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                animator.SetBool("kick", false);
                endAttack = false;
                timer = 0f;
            }
        }
    }

    public void run(Vector3 posFinal)
    {
        first = true;
        IamRunning = true;
        EndPosition = posFinal;
        dir = EndPosition - startPosition;
        dir.Normalize();
        animator.SetBool("run", true);
    }

    public void getHurt()
    {
        animator.SetBool("hurt", true);
        endHurt = true;
    }

    public void attack()
    {
        animator.SetBool("kick", true);
        endAttack = true;
    }
    
}
