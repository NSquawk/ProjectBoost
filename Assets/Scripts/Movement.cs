using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Movement : MonoBehaviour {
    Rigidbody _rb;
    [SerializeField] float thrust = 1.0f;
    [SerializeField] float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            Vector3 thrustVector = Vector3.up * thrust * Time.deltaTime;
            _rb.AddRelativeForce(thrustVector);
        }
    }

    void ProcessRotate() {
        if (Input.GetKey(KeyCode.A)) {
            Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            Rotate(Vector3.back);
        }
    }

    void Rotate(Vector3 rotateVectorDirection) {
        // freezing physics rotation before manual rotation
        _rb.freezeRotation = true;
        Vector3 rotateVector = rotateVectorDirection * rotateSpeed * Time.deltaTime;
        transform.Rotate(rotateVector);
        // unfreezing rotation so physics can take back over
        _rb.freezeRotation = false;
    }
}