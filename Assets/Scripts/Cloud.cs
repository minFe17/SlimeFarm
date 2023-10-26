using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] float _minX;
    [SerializeField] float _maxX;
    [SerializeField] float _speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (transform.position.x >= _maxX)
            transform.position = new Vector2(_minX, transform.position.y);
    }
}
