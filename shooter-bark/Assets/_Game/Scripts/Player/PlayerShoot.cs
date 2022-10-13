using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Managers;
using UnityEngine;
using DG.Tweening;

public class PlayerShoot : MonoBehaviour
{

    private WeaponType currentweapon;
    private BulletType currentbullet;

    public GameObject bullet;
   [SerializeField]  private TargetTrigger targetTrigger;
   private EnemyController currentTarget = null;

   [SerializeField] private Transform firePoint;
   public Transform trial;

   private float defaultfireRate = 1f;
   private bool canShoot;
   public event Action<bool, int, EnemyController> FireBullet;



    private void Start()
    {
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
        targetTrigger.targetPicker += getTarget;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
        targetTrigger.targetPicker -= getTarget;

    }

    private void Update()
    {
        if (currentTarget == null) return;
        if (canShoot)
        {
            ShootSettings(currentTarget, WeaponType.Default, BulletType.Default);
            StartCoroutine(shootCounter());
        }
        
    }

    IEnumerator shootCounter()
    {
        canShoot = false;
        yield return new WaitForSeconds(defaultfireRate);
        canShoot = true;
    }
    private void ShootSettings(EnemyController target, WeaponType weaponType, BulletType bulletType)
    {
        /* var a = Instantiate(bullet, firePoint.position, Quaternion.identity);
        a.transform.DOMoveZ(5f, 1f); */
        if (target == null) return;
        transform.LookAt(target.transform);

        float fireRate;
        bool isFlame = false, isSpread = false;
        

        switch (weaponType)
        {
            case (WeaponType.Default):
                break;
            case(WeaponType.RPG):
                isFlame = true;
                break;
        }

        switch (bulletType)
        {
            case (BulletType.Default):
                fireRate = defaultfireRate;
                break;
            case(BulletType.MultipleShot):
                fireRate = defaultfireRate / 2;
                break;
            case(BulletType.SpreadShot):
                isSpread = true;
                break;
        }
        var a = Instantiate(bullet, firePoint.position, Quaternion.identity);
        a.GetComponent<Bullet>().GetFired(isFlame, 0, target);
        if (isSpread)
        {
            
        }
        
        
        
    }

   /* void Shoot(float fireRate, bool isFlame, bool isSpread, Transform target)
    {
        transform.LookAt(target);
        if (isSpread)
        {
            var bullet1 = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            var bullet2 = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            var bullet3 = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);

            bullet1.transform.DOMove(new Vector3(target.transform.position.x, 1f, target.transform.position.z), 5f);

            var bullet2pos = Mathf.Cos(30f) * (target.transform.position - firePoint.transform.position);
            bullet2pos.y = 1f;
            var bullet3pos = Mathf.Sin(30f) * (target.transform.position - firePoint.transform.position);
            bullet3pos.y = 1f;
                bullet2.transform.DOMove(bullet2pos, 5f);
               bullet3.transform.DOMove(bullet3pos, 5f);


        }
    }*/
    public void getTarget(EnemyController enemy)
    {
        currentTarget = enemy;
        Debug.Log(currentTarget);
    }
    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case (GameState.TapToStart):
                //do nothin
                break;
            case(GameState.Started):
                canShoot = true;
                break;
        }
        
    }
}
