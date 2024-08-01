using UnityEngine;

public class PlayerController
{
    public Vector2 MoveDirection => _playerInput.Player.Move.ReadValue<Vector2>();

    private PlayerInput _playerInput;

    public PlayerController()
    {
        _playerInput = new PlayerInput();
    }

    public void OnEnable()
    {
        _playerInput.Enable();
    }

    public void OnDisable()
    {
        _playerInput.Disable();
    }

}


