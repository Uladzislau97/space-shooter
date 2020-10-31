using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private Random _rand = new Random();

    private float _xLeftBound = -9f;
    private float _xRightBound = 9f;
    private float _yBottomBound = -5f;
    private float _yTopBound = 7f;
    private float _zPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float xPosition = Random.Range(_xLeftBound, _xRightBound);
        transform.position = new Vector3(xPosition, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 ms
        // if bottom of screen respown at top with a new random x position
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= _yBottomBound) {
            float xPosition = Random.Range(_xLeftBound, _xRightBound);
            transform.position = new Vector3(xPosition, _yTopBound, _zPosition);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Destroy(this.gameObject);

            Player player = other.transform.GetComponent<Player>();

            if (player) {
                player.Damage();
            }
        }

        if (other.tag == "Laser") {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
