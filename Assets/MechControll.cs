using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechControll : MonoBehaviour
{

    #region Deligates
    #endregion

    #region Propertes
    [SerializeField]
    private float _speed = 0.1f;
    [SerializeField]
    private float _jumpForce = 20f;
    private bool _grauded=true;
    #endregion

    #region Fields
    private Rigidbody2D rb;
    [SerializeField]
    private GraundTest gt;

    #endregion

    #region Events
    #endregion

    #region Metods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * _speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _grauded)
        {
            rb.AddForce(Vector2.up * _jumpForce);
            //_grauded = false;
        }
    }
    private void FixedUpdate()
    {

    }
    private void boolSet(bool bools)
    {

        _grauded = true;
    }
    #endregion
}


