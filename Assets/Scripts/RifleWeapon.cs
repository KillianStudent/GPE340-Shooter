using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon
{
    public float ammoCount;
    [SerializeField] private float bulletMoveSpeed = 100;
    [SerializeField] private GameObject prefabBullet;   // bullet prefab
    [SerializeField] private Transform FirePoint;   // point where the bullet comes from
    [SerializeField] private float fireRate = 20f; // time between each shot
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
    }

    public override void OnTriggerPull()
    {
        if (countdownToNextShot <= 0 && ammoCount > 0)  // checks if the time before the next shot has passed, and if the weapon has ammo
        {
            ammoCount--;
            ShootBullet();
            countdownToNextShot = fireRate;
        }
    }

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(prefabBullet, FirePoint.position, FirePoint.rotation) as GameObject;
        BulletData bulletData = bullet.GetComponent<BulletData>();
        GetComponent<AudioSource>().Play();
        if (bulletData != null)
        {
            bulletData.damageDone = damageDone;
            bulletData.moveSpeed = bulletMoveSpeed;
        }
    }

    public override void OnTriggerRelease()
    {

    }
}
