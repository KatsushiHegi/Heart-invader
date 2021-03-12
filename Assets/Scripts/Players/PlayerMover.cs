using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] float _movementSharpness = 15f;

    CharacterController _controller;
    PlayerInputHandller _playerInputHandller;

    public Vector3 _characterVelocity { get; set; }
    public bool _isStan { get; set; }

    void Start()
    {
        _playerInputHandller = GetComponent<PlayerInputHandller>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleCharacterMovement();
    }

    void HandleCharacterMovement()
    {
        if (_isStan) return;
        //向き
        {
            transform.LookAt(_playerInputHandller.GetMousePosition());
        }
        
        //移動
        {
            Vector3 targetVelocity = _playerInputHandller.GetMoveInput() * _maxSpeed;
            _characterVelocity = Vector3.Lerp(_characterVelocity, targetVelocity, _movementSharpness * Time.deltaTime);
            _characterVelocity = new Vector3(_characterVelocity.x, 0, _characterVelocity.z);
            _controller.Move(_characterVelocity * Time.deltaTime);
        }
    }
}
