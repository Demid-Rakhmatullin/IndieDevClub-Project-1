using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;

    private float _fixedY;
    private Vector3 _offset;

    
    void Awake()
    {
        var initPos = transform.position;
        _offset = initPos - FollowTarget.position;
        _fixedY = initPos.y;
    }
  
    void LateUpdate()
    {
        var newPos = FollowTarget.position + _offset;
        newPos.y = _fixedY;
        transform.position = newPos;
    }
}
