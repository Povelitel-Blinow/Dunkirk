using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _magReloadTime;
    [SerializeField] private float _magSize;
    [SerializeField] private float _shootingConeMaxAngle;

    private bool _readyToShoot = true;
    public void ShootGun()
    {
        if (_readyToShoot == false) return;

        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        float timer = 0f;
        int bulletShot = 1;

        _readyToShoot = false;

        ShootBullet();

        while (bulletShot < _magSize) 
        {
            timer += Time.deltaTime;
            if(timer >= _reloadTime) 
            {
                ShootBullet();

                bulletShot++;
                timer = 0f;
            }

            yield return new WaitForEndOfFrame();
        }

        while (timer < _magReloadTime)
        {
            timer += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        _readyToShoot = true;
    }

    private void ShootBullet()
    {
        Quaternion rot = Quaternion.Euler(0f, 0f, Random.Range(-_shootingConeMaxAngle, _shootingConeMaxAngle));

        Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation * rot).Shoot();
    }
}
