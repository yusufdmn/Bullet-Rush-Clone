using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    [SerializeField] private float speedOfPlayer;
    static bool isGameOver;

    public Animator animatorPlayer;

    void Start()
    {
        isGameOver = false;
    }
  

    void Update()
    {

        if(isGameOver == true)
        {
            ChangeRunAnimation(false);
            return;
        }

        else {
            MoveAndRotatePlayer();
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

    public void ChangeRunAnimation(bool isRunning)
    {
        animatorPlayer.SetBool("isRunning", isRunning);
    }

    public void MoveAndRotatePlayer()
    {
        float x = joystick.Horizontal * speedOfPlayer * Time.deltaTime;
        float y = joystick.Vertical * speedOfPlayer * Time.deltaTime;

        if (x == 0 && y == 0)
        {
            ChangeRunAnimation(false);
        }
        else
        {
            ChangeRunAnimation(true);
        }

        Vector3 newPosition = new Vector3(x, 0, y);
        transform.position += newPosition;

        transform.rotation = Quaternion.LookRotation(newPosition);
    }

}