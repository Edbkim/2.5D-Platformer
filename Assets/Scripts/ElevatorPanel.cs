using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    private int _requiredCoins = 8;

    [SerializeField]
    private MeshRenderer _callButton;

    [SerializeField]
    private Elevator _elevator;

    private bool _elevatorCalled = false;


    private void Start()
    {

        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CoinCount() >= _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                }
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                }

                _elevator.CallElevatorDown();
            }
        }
    }
}
