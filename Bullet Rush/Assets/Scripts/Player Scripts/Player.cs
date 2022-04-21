using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    [SerializeField] private float speedOfPlayer;
    static bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }
  
    void Update()
    {

        if(isGameOver == false) {
            float x = joystick.Horizontal * speedOfPlayer * Time.deltaTime;
            float y = joystick.Vertical * speedOfPlayer * Time.deltaTime;

            Vector3 newPosition = new Vector3(x, 0, y);
            transform.position += newPosition;

            transform.rotation = Quaternion.LookRotation(newPosition);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.PlayerLost();
        }
    }

    public static void StopMove()
    {
        isGameOver = true;
    }

}