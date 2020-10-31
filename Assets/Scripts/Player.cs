using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.5f;

    [SerializeField]
    private int _lives = 3;

    private float _canFire = -1f;
    private float _zPosition = 0f;
    private float _yTopBound = 0f;
    private float _yBottomBound = -3.8f;
    private float _xLeftBound = -11f;
    private float _xRightBound = 11f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
            Fire();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, _zPosition);
        transform.Translate(direction * Time.deltaTime * _speed);


        if (transform.position.y >= _yTopBound) {
            transform.position = new Vector3(transform.position.x, _yTopBound, _zPosition);
        } else if (transform.position.y <= _yBottomBound) {
            transform.position = new Vector3(transform.position.x, _yBottomBound, _zPosition);
        }

        if (transform.position.x >= _xRightBound) {
            transform.position = new Vector3(_xLeftBound, transform.position.y, _zPosition);
        } else if (transform.position.x <= _xLeftBound) {
           transform.position = new Vector3(_xRightBound, transform.position.y, _zPosition);
        }
    }

    void Fire()
    {
        _canFire = Time.time + _fireRate;

        float yOffset = 0.8f;
        Vector3 position = new Vector3(
          transform.position.x,
          transform.position.y + yOffset,
          transform.position.z
        );
        Instantiate(_laserPrefab, position, Quaternion.identity);
    }

    public void Damage()
    {
        _lives --;

        if (_lives < 1) {
            Destroy(this.gameObject);
        }
    }
}
