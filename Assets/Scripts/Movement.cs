using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Compilation;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float speedOfRocket = 100;
    [SerializeField] float rotationSpeedOfRocket =20;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    void ProcessThrust() {
        if (Input.GetKey(KeyCode.W)) {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * speedOfRocket);
            
        } else {
            audioSource.Stop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(rotationSpeedOfRocket);
        }
        else if (Input.GetKey(KeyCode.D)) {
            Rotate(-rotationSpeedOfRocket);
        }
    }

    void Rotate(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; 
    }
}
