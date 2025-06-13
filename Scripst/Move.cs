using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private float _speed;
    private int _pointIndex;

    public void Update()
    {
        Transform movePoint = _points[_pointIndex];

        if (transform.position != movePoint.position)
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, _speed * Time.deltaTime);
        else
            GetNextPoint();
    }

    public void GetNextPoint()
    {
        _pointIndex++;

        if (_pointIndex == _points.Length - 1)
            _pointIndex = 0;
    }
} 