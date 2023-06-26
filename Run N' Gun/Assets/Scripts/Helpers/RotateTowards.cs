using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateTowards : MonoBehaviour
{
    private bool useMouse = true;
    private Camera _camera;

    private Vector2 _mousePos;
    private Vector2 _controllerPos;

    private Rigidbody2D _rb;


    private void OnEnable()
    {
        KeyboardManager.OnInputChanged += InputChanged;
    }

    private void OnDisable()
    {
        KeyboardManager.OnInputChanged -= InputChanged;
    }

    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (useMouse)
        {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            _controllerPos.x = -Input.GetAxisRaw("RHorizontal");
            _controllerPos.y = Input.GetAxisRaw("RVertical");
        }
    }

    private void FixedUpdate()
    {
        if (useMouse)
        {
            Vector2 lookDir = _mousePos - _rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            _rb.rotation = angle;
        }
        else
        {
            if (_controllerPos.x == 0 && _controllerPos.y == 0)
            {
                return;
            }

            Vector2 joystickDir = _controllerPos.normalized;
            float angle = Mathf.Atan2(joystickDir.y, joystickDir.x) * Mathf.Rad2Deg + 90f;
            
            _rb.rotation = angle;
        }
    }

    /// <summary>
    /// The default is mouse and keyboard on PC. This function is called when the Keyboard Manager fires the event OnInputChanged
    /// </summary>
    private void InputChanged()
    {
        // Swap the bool
        useMouse = !useMouse;
    }
}


