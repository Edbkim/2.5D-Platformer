using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;

    [SerializeField]
    private float _speed = 5.0f;

    private bool _goingA;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position == _pointB.position)
        {
            _goingA = true;
        }
        else if (transform.position == _pointA.position)
        {
            _goingA = false;
        }

        if (_goingA == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }
        else if (_goingA == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
