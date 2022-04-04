using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    Animator _animator;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        // Flip image
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // move & animation
        float x = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(x));
        transform.position += new Vector3(x, 0f, 0f) * Time.deltaTime * speed;

        // flips sprite
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slip")
        {
            speed = 0;
        }
        else
        {
            speed = 3f;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
            speed = 3f;
    }
}
