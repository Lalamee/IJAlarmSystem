using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _endPoint;
    

    private void Update()
    {
        if(transform.position.x != _endPoint.position.x)
            transform.position = Vector2.MoveTowards(transform.position, _endPoint.position, _speed * Time.deltaTime);
    }
}
