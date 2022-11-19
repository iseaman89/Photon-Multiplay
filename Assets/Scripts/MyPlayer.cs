using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;


public class MyPlayer : MonoBehaviour, IPunObservable
{
    #region Variables

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 _moveVector;
    private bool _died = false;

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private float _moveSpeed;
    [SerializeField] public int Health;
    [SerializeField] private int _damage;
    [SerializeField] private TextMeshProUGUI _label;
    private Vector3 _smoothMove;

    public Animator Animator { get => _animator; set => _animator = value; }

    #endregion

    #region Function

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _playerCamera.SetActive(_photonView.IsMine);
        _label.text = Health.ToString();
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            if (Input.GetButtonDown("Fire1") && !_died)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private void FixedUpdate()
    {
        if (_photonView.IsMine)
        {
            ProcessInputs();
        }
    }

    private void ProcessInputs()
    {

        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _moveVector.y = Input.GetAxisRaw("Vertical");
        if (_moveVector != Vector3.zero && !_died)
        {
            _moveVector.Normalize();
            Animator.SetFloat("moveX", _moveVector.x);
            Animator.SetFloat("moveY", _moveVector.y);
            Animator.SetBool("move", true);
            _rigidbody2D.MovePosition(transform.position + _moveVector * _moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Animator.SetBool("move", false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            _smoothMove = (Vector3)stream.ReceiveNext();
        }
    }

    private IEnumerator Attack()
    {
        Animator.SetTrigger("attack");
        yield return new WaitForSeconds(.41f);
        Animator.SetTrigger("idle");
    }

    public void Hit()
    {
        if (_photonView.IsMine)
        {
            if (Health <= 0)
            {
                _label.text = Health.ToString();
            }
            else
            {
                Health -= _damage;
                Debug.Log(Health);
                _label.text = Health.ToString();
                if (Health <= 0)
                {
                    Animator.SetBool("died", true);
                    _died = true;
                }
            }
        }
    }

    #endregion
}
