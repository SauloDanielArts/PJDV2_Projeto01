using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    public float velocidade = 10f;
    public float forcaPulo = 10f;

    private bool noChao = false;
    private bool andando = false;
   // private bool caindo = false;
    
    void Start()
    {
        _transform = gameObject.transform;
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("chao")) //if (other.tag == "chao")
        {
            noChao = true;
        }
    }

    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("chao")) //if (other.tag == "chao")
        {
            noChao = false;
        }
    }
    
    void Update()
    {
        andando = false;
        //caindo = false;
        
        Debug.Log("No Chao: " + noChao);
        
        if(Input.GetKey(KeyCode.LeftArrow) )
        {
            _transform.position -= new Vector3(velocidade*Time.deltaTime,0,0);
           Debug.Log("LeftArrow");
           _spriteRenderer.flipX = true;

           if (noChao == true)
           {
               andando = true;
           }
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
           _transform.position += new Vector3(velocidade*Time.deltaTime,0,0);
           Debug.Log("RightArrow");
           _spriteRenderer.flipX = false;
           
           if (noChao == true)
           {
               andando = true;
           }
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
           // forcaPulo
           _rigidbody2D.AddForce(new Vector2(0,forcaPulo),ForceMode2D.Impulse);
        }
        
        _animator.SetBool("Andando", andando);
        _animator.SetBool("Caindo", !noChao);
    }
}
