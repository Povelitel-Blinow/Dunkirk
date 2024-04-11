using UnityEngine;

public class PlaneHull : MonoBehaviour
{
    [SerializeField] private Plane _plane;

    [SerializeField] private int _hp; 

    [SerializeField] private GameObject _fuelLeak;
    [SerializeField] private GameObject _fire;
    private int _MaxHp;

    private void Start()
    {
        _MaxHp = _hp;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if(_hp < 0.8 * _MaxHp)
            _fuelLeak.SetActive(true);
        if (_hp < 0.3 * _MaxHp)
            _fire.SetActive(true);

        if (_hp < 0)
            Destroy(gameObject);
    }
}
