using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    #region Variables

    [SerializeField] private GameObject _connectedScreen;
    [SerializeField] private GameObject _disconnectedScreen;

    #endregion

    #region Funktions

    /// <summary>
    /// Connect to network with on button click
    /// </summary>
    public void OnClick_ConnectedButton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        _disconnectedScreen.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        _connectedScreen.SetActive(true);
        if (_disconnectedScreen.activeSelf)
        {
            _disconnectedScreen.SetActive(false);
            _connectedScreen.SetActive(true);
        }
    }

    #endregion
}
