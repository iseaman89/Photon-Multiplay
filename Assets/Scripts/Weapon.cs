using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables

    #endregion

    #region Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<Chicken>().Boom();
            Debug.Log("weapon");
            collision.GetComponent<MyPlayer>().Health -= 50;
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MyPlayer>().Hit();
        }
    }

    #endregion
}
