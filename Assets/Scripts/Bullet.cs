using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletType;

    [SerializeField] private float speed;

    public int BulletType { get; private set; }
    public float Speed { get; private set; }



   private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Damage if needed
        Destroy(gameObject);
    }









}
