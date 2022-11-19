using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class UIhandler : MonoBehaviourPunCallbacks
{
    #region Variables

    [SerializeField] private TMP_InputField _createRoomTF;
    [SerializeField] private TMP_InputField _joinRoomTF;

    #endregion

    #region Functions

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinRoomTF.text, null);
    }

    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createRoomTF.text, new RoomOptions{MaxPlayers = 4}, null);
    }

    public override void OnJoinedRoom()
    {
        print("Room Joined Sucess");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("RoomFaild" + returnCode + "Message" + message);
    }

    #endregion
}
