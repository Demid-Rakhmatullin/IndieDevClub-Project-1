using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCoin : MonoBehaviour
{
    public int ScorePoints = 10;
    public bool Rotate;
    public bool Move;
    public float RotationSpeed = 1f;
    public float MovementSpeed = 0.5f;
    public float MovementShift;

    private float _initY;
    private bool _moveUp;

    void Awake()
    {
        _initY = transform.position.y;
        _moveUp = true;
    }

    void Update()
    {
        if (Rotate)
            transform.Rotate(0, 50 * Time.deltaTime * RotationSpeed, 0);

        if (Move)
        {
            CheckMovementShift();
            transform.position += GetMoveDirection() * Time.deltaTime * MovementSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin");
            GameManager.Instance.IncreaseScore(ScorePoints);
            Destroy(gameObject);
        }
    }

    private Vector3 GetMoveDirection() =>
        _moveUp ? Vector3.up : Vector3.down;

    private void CheckMovementShift()
    {
        if (_moveUp && transform.position.y - _initY >= MovementShift)
            _moveUp = false;
        else if (!_moveUp && transform.position.y <= _initY)
            _moveUp = true;
    }
}
