using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _liveTime;
    [SerializeField] private int _damage;

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        float timer = 0f;

        while(timer < _liveTime)
        {
            timer += Time.deltaTime;

            transform.position += transform.up * _flySpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        Explode();

        Destroy(gameObject);
    }

    private void Explode()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();

        if (collision.gameObject.TryGetComponent(out PlaneHull plane)) 
        {
            plane.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
