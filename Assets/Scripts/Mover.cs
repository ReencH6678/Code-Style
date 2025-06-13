using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private float _speed;
    private int _pointIndex;
    private float _offset = 0.1f;

    public void Update()
    {
        if ((transform.position - _points[_pointIndex].position).sqrMagnitude > _offset)
            transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].position, _speed * Time.deltaTime);
        else
            _pointIndex = ++_pointIndex % _points.Length;
    }
} 