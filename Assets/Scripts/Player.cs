using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 20.0f;

    private int _coins;
    [SerializeField]
    private int _lives = 3;

    private float _yVelocity;

    private bool _haveDoubleJump;

    private CharacterController _controller;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("CharacterController is NULL");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UIManager is NULL");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalMovement, 0, 0);
        Vector3 velocity = direction * _speed;
        Debug.Log(_controller.isGrounded);

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _haveDoubleJump = true;
                Debug.Log(_controller.isGrounded);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_haveDoubleJump == true)
                {
                    _yVelocity = _jumpHeight;
                    _haveDoubleJump = false;
                }
            }

            _yVelocity -= _gravity;

        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

    }
    public void Coin()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }

    }

    
}
