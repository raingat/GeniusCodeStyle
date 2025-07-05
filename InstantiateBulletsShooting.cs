using System.Collections;
using UnityEngine;

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    [SerializeField] private Rigidbody _prefab;

    [SerializeField] private Transform _target;

    [SerializeField] private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_waitTime);

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Rigidbody bullet = Instantiate(_prefab, transform.position, Quaternion.identity);

            bullet.transform.up = direction;

            bullet.velocity = direction * _speed * Time.deltaTime;

            yield return waitForSeconds;
        }
    }
}