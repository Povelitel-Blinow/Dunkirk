using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PersonBody : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private float _ropeDropTime;
    [SerializeField] private float _climbOnBoatTime;
    [SerializeField] private float _hookingIncreaseRatio;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;

    private float _currentHookingSpeed = 0;

    private Person _person;

    public void Init(Person person)
    {
        _person = person;
    }

    public void MoveTo(Vector3 pos)
    {
        Debug.Log("Moving");

        Vector2 direction = pos - transform.position;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), _rotSpeed * Time.deltaTime);
        }

        transform.position += transform.up * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent(out SafeZone zone);

        if (zone != null)
            HookUp(zone.Boat);
    }

    private void HookUp(Boat boat)
    {
        StartCoroutine(PickingUp(boat));
    }

    private IEnumerator PickingUp(Boat boat)
    {
        Transform hookPoint = boat.HookPoint;

        _lineRenderer.enabled = true;

        yield return StartCoroutine(DroppingRope(hookPoint));

        yield return StartCoroutine(HookingUp(hookPoint));

        boat.PickUpPerson();

        _lineRenderer.enabled = false;

        transform.parent = hookPoint;

        ClimbOnBoat();
    }

    private IEnumerator DroppingRope(Transform hookPoint)
    {
        float timer = 0;

        while (timer < _ropeDropTime)
        {
            _lineRenderer.SetPosition(0, Vector3.Lerp(hookPoint.transform.position, transform.position, timer));
            _lineRenderer.SetPosition(1, hookPoint.position);

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    private IEnumerator HookingUp(Transform hookPoint)
    {
        while ((transform.position - hookPoint.position).magnitude >= 0.3f)
        {
            Vector2 direction = hookPoint.position - transform.position;

            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), _rotSpeed * Time.deltaTime);
            }

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, hookPoint.position);

            transform.position = Vector3.Lerp(transform.position, hookPoint.position, _currentHookingSpeed * Time.deltaTime);

            _currentHookingSpeed += Time.deltaTime * _hookingIncreaseRatio;
            yield return new WaitForEndOfFrame();
        }
    }

    private void ClimbOnBoat()
    {
        transform.DOScale(Vector3.zero, _climbOnBoatTime).OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
