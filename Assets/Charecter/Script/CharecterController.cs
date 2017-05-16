using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterController : MonoBehaviour 
{
    #region Enums
    #endregion

    #region Delegates
    #endregion

    #region Structures
    #endregion

    #region Classes
    #endregion

    #region Fields
    public Robot robot;
    #endregion

    #region Events
    #endregion

    #region Properties
    #endregion

    #region Methods
    private void Start()
    {
        robot = robot == null ? GetComponent<Robot>() : robot;
        if (robot == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }
    private void Update()
    {
        if (robot != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                robot.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                robot.MoveLeft();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                robot.Jump();
            }
            if (Input.GetKey(KeyCode.S))
            {
                robot.MoveDown();
            }
            if (Input.GetKey(KeyCode.W))
            {
                robot.MoveUp();
            }

        }
    }
    #endregion

    #region Event Handlers
    #endregion
}
