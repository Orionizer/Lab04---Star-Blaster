using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftPos;
    [SerializeField] float rightPos;
    [SerializeField] float upPos;
    [SerializeField] float downPos;
    Shooter playerShooter;
    InputAction fireAction;
    InputAction moveAction;

    Vector3 moveVector;
    Vector3 minBound;
    Vector3 maxBound;

    void Start()
    {
        playerShooter = GetComponent<Shooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        MovePlayer();
        InBound();
        Fire();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBound.x + leftPos, maxBound.x - rightPos);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y + downPos, maxBound.y - upPos);

        transform.position = newPos;
    }
    void InBound()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Fire()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}