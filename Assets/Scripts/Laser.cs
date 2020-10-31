using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);

        float yTopBound = 8f;
        if (transform.position.y > yTopBound) {
            Destroy(this.gameObject);
        }
    }
}
