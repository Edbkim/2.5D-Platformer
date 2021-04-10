using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 9f;
    private float _gravity = 30f;
    private float _jumpHeight = 12f;

    private bool _jumping = false;
    private bool _onLedge;
    private Ledge _activeLedge;

    private Vector3 _direction;

    private CharacterController _controller;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (_onLedge == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetTrigger("ClimbUp");
            }
        }
    }

    private void Movement()
    {
        if (_controller.isGrounded == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(0, 0, horizontal) * _speed;
            _anim.SetFloat("Speed", Mathf.Abs(horizontal));

            if (horizontal != 0)
            {
                Vector3 facing = transform.localEulerAngles;
                facing.y = _direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facing;
            }




            if (_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y = _jumpHeight;
                _jumping = true;
                _anim.SetBool("Jumping", _jumping);
            }

        }

        _direction.y -= _gravity * Time.deltaTime;

        _controller.Move(_direction * Time.deltaTime);

    }

    public void GrabLedge(Vector3 handPos, Ledge currentLedge)
    {
        _controller.enabled = false;
        _anim.SetBool("GrabLedge", true);
        _anim.SetFloat("Speed", 0f);
        _anim.SetBool("Jumping", false);
        _onLedge = true;
        transform.position = handPos;
        _activeLedge = currentLedge;
    }

    public void ClimbUpComplete()
    {
        transform.position = _activeLedge.GetStandPos();
        _anim.SetBool("GrabLedge", false);
        _controller.enabled = true;
    }

}
