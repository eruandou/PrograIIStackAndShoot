using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private ShootingController playerShootingController;



    private void Start()
    {
        playerShootingController = GetComponent<ShootingController>();
    }


    private void ShootingLogic()
    {
        if (Input.GetButtonDown("Fire1"))
        {           
            playerShootingController.Shoot();            
            Debug.Log("Disparo");
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerShootingController.CombineBullets();
            Debug.Log("Combino balas");
        }
    }



    private void Update()
    {
        ShootingLogic();
    }



}
