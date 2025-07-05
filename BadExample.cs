using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _wayPoints;

    private int _currentWayPoint = 0;

    private void Update()
    {
        Vector3 positionCurrentWayPoint = _wayPoints[_currentWayPoint].position;

        transform.position = Vector3.MoveTowards(transform.position, positionCurrentWayPoint, _speed * Time.deltaTime);

        if (transform.position == positionCurrentWayPoint)
            TakeNextPlace();
    }

    private void TakeNextPlace()
    {
        _currentWayPoint++;

        int indexLastWayPoint = _wayPoints.Length - 1;

        if (_currentWayPoint == indexLastWayPoint)
            _currentWayPoint = 0;
    }
}