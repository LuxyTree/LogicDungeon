using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;


    void Update()
    {
        GatherInput();
        Look();

        if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("Tutorial Level");
        }

        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene("MEDLevel");
        }

        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("HARDLevel");
        }

        if (Input.GetKey(KeyCode.X))
        {
            Application.Quit();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("Tutorial Level");
            Debug.Log("Detected Water");
        }
        if (collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("MEDLevel");
            Debug.Log("Detected Win");
        }
        if (collision.gameObject.tag == "Win2")
        {
            SceneManager.LoadScene("HARDLevel");
            Debug.Log("Detected Win");
        }
        if (collision.gameObject.tag == "Win3")
        {
            SceneManager.LoadScene("Menu");
            Debug.Log("Detected Win");
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot,_turnSpeed * Time.deltaTime);
        }

    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
}
