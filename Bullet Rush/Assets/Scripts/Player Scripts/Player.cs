using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    [SerializeField] private float speedOfPlayer;


    void Start()
    {
        
    }

    void Update()
    {
        float x = joystick.Horizontal * speedOfPlayer * Time.deltaTime;
        float y = joystick.Vertical * speedOfPlayer * Time.deltaTime;

        Vector3 newPosition = new Vector3(x, 0, y);
        transform.position += newPosition;

    }
}
