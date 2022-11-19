using Photon.Pun;
using UnityEngine;

public class Manager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _sceneCamera;

    #endregion

    #region Function

    private void Start()
    {
        CreatePlayer();
        _sceneCamera.SetActive(false);
    }

    public void CreatePlayer()
    {
        PhotonNetwork.Instantiate(_playerPrefab.name,
            _playerPrefab.transform.position + new Vector3(Random.Range(-5, 5), 0),
            Quaternion.identity);
    }

    #endregion
}
