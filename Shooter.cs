using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    [SerializeField] private GameObject _prefab;

    [SerializeField] private Transform _target;

    private Coroutine _coroutine;

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

            GameObject bullet = Instantiate(_prefab, transform.position, Quaternion.identity);

            bullet.transform.up = direction;

            bullet.GetComponent<Rigidbody>().velocity = direction * _speed * Time.deltaTime;

            yield return waitForSeconds;
        }
    }
}