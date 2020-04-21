using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon
{
    public float ammoCount;
    [SerializeField] private float bulletMoveSpeed = 100;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform FirePoint;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void OnTriggerPull()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        
        GameObject bullet = Instantiate(prefabBullet, FirePoint.position, FirePoint.rotation) as GameObject;
        BulletData bulletData = bullet.GetComponent<BulletData>();
        if (bulletData !=  null)
        {
            bulletData.damageDone = damageDone;
            bulletData.moveSpeed = bulletMoveSpeed;
        }
    }

    public override void OnTriggerRelease()
    {

    }
}
