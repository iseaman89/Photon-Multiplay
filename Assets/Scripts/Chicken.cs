using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Chicken : MonoBehaviour
{
    #region Variables

    [Inject] private MyPlayer _myPlayer;
    private Animator _animator;

    #endregion

    #region Functions

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Boom()
    {
        _animator.SetBool("boom", true);
        Debug.Log("animator");
        Destroy(gameObject, 1);
    }

    #endregion
}
