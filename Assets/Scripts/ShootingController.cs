using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    private Bullet bulletToFire = null;



    private Stack bulletsStack = new Stack();

    public Bullet BulletToFire { get => bulletToFire; set => bulletToFire = value;}

    private int maxStackedBullets = 10;

    private bool canCombine = true;




    public void Shoot()
    {        
        Bullet bullet = Instantiate(BulletToFire, this.transform);
    }
    

    public void AddBullet(Bullet newBullet)
    {
        if (bulletsStack.Count < maxStackedBullets)
        bulletsStack.Push(newBullet);
    }

    public void CombineBullets()
    {
        //Check Actual Combination
        //Call PowerUp function 

        if (bulletsStack.Count >= 4 && canCombine)
        {

            int[] bulletsCombined = new int[3];
            canCombine = false;
                
            for (int i = 0; i < 3; i++)
            {
                Bullet currentBullet = bulletsStack.Pop() as Bullet;
                bulletsCombined[i] = currentBullet.BulletType;                
            }
            SetPowerUp(bulletsCombined[0], bulletsCombined[1], bulletsCombined[2]);
            StartCoroutine(ChangeBulletType());
        }           

    }


    private void SetPowerUp(int bullet1, int bullet2, int bullet3)
    {
        //Add PowerUp to Player based on combinations
    }

    private IEnumerator ChangeBulletType()
    {
        for (int i = 0; i < bulletsStack.Count; i++)
        {
            bulletToFire = bulletsStack.Pop() as Bullet;
            yield return new WaitForSeconds(2);
        }

        BulletToFire = null;

        canCombine = true;
    }



}
