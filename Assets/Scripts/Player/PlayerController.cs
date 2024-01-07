using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _movementMask;

    private Camera _cam;

    private PlayerMotor _motor;

    // Start is called before the first frame update
    private void Start()
    {
        _cam = Camera.main;
        _motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                _motor.MoveToPoint(hitInfo.point);
            }
        }
    }
}
