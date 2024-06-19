using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exam06_player : MonoBehaviour
{
    Animator animator;
    new Rigidbody2D rigidbody;
    Vector2 velocity;//방향+스칼라
    public float speed = 1.0f;
    [SerializeField] GameObject bodyObject;
    bool JumpStart = false;
    float jumpStartTime;
    void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        animator = bodyObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//논리적 처리
    {
        float _hozInput = Input.GetAxisRaw("Horizontal");//-1~1사이 이동
        velocity = new Vector2(_hozInput,0).normalized*speed;
        
        if(velocity.x != 0){
            animator.SetBool("isWalk", true);
        }
        else{
            animator.SetBool("isWalk",false);
        }
        if(_hozInput>0){
           transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(_hozInput<0){
           transform.rotation = Quaternion.Euler(0,180,0);
        }
        /////////
        if (rigidbody.velocity.y < 0.0f)
        {
            animator.SetBool("down", true);
        }
        else{
            animator.SetBool("down", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("1");
            animator.SetBool("isJumpStart", true);
            JumpStart=true;
            jumpStartTime = Time.time;
        }
        if(JumpStart&&Time.time-jumpStartTime>1.0f){
            rigidbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            animator.SetBool("Jump2", true);
            JumpStart=false;
            if(!JumpStart&&Time.time-jumpStartTime>1.0f){
                animator.SetBool("isJumpDown", true);
            }
        }     
    }
    void FixedUpdate(){//물리적 처리
        rigidbody.velocity=new Vector2(velocity.x,rigidbody.velocity.y);
    }
}
