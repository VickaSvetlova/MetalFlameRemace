using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GraundTest : MonoBehaviour {

    #region Deligates
    #endregion

    #region Propertes
    #endregion

    #region Fields
    #endregion

    #region Events
    public UnityEvent <bool> graunded;
    #endregion

    #region Metods
    private void OnTriggerStay(Collider other)
    {
        if(other.tag== "Graund")
        {
           graunded.Invoke(true);
        }
    }
    #endregion
}


