using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeaponFullAuto : Weapon
{
    public float ammoCount;
    [SerializeField] private float bulletMoveSpeed = 100; // bullet speed
    [SerializeField] private GameObject prefabBullet;   // bullet to shoot
    [SerializeField] private Transform FirePoint;   // position for the gun to shoot from
    private bool isShooting = false;   // bool for if the gun is firing
    [SerializeField] private float fireRate = 10; // time between each shot
    private float countdownToNextShot;  // counts down the time until the next shot

    // Start is called before the first frame update
    public override void Start()
    {
        countdownToNextShot = 0;    // sets the time until the next shot to be 0 so it can fire right away
    }

    // Update is called once per frame
    public override void Update()
    {
        if (countdownToNextShot > 0)
        {
            countdownToNextShot -= Time.deltaTime;  // increments time to the next shot by Time.deltaTime
        }

        if (isShooting && countdownToNextShot <= 0 && ammoCount > 0)    // checks if the gun the trigger is held, the countdown to the next shot is 0, and if the player has ammo
        {
            ammoCount--;
            ShootBullet();
            countdownToNextShot = fireRate;
        }
    }

    public override void OnTriggerPull()
    {
        isShooting = true;
    }

    public void ShootBullet()   // spanws a bullet
    {
        GameObject bullet = Instantiate(prefabBullet, FirePoint.position, FirePoint.rotation) as GameObject;
        BulletData bulletData = bullet.GetComponent<BulletData>();
        if (bulletData != null)
        {
            bulletData.damageDone = damageDone;
            bulletData.moveSpeed = bulletMoveSpeed;
        }
    }

    public override void OnTriggerRelease()
    {
        isShooting = false;
    }
}
