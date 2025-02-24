using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    [Header("Flight Settings")]
    public float pitchSpeed = 50f;
    public float rollSpeed = 50f;
    public float yawSpeed = 20f;
    public float throttleSpeed = 10f;
    public float maxSpeed = 100f;
    public float minSpeed = 10f;
    //Shooting mechanic
    public GameObject bulletPrefab;
    public float timer = 0;
    public float attackCooldown = 0.25f;

    private float throttleInput = 0f;
    private Vector2 pitchRollInput; // Left Thumbstick or WASD
    private float yawInput;         // Right Thumbstick or Q/E
    private float throttleDelta;    // Right Trigger or R/F

    [Header("Input Actions")]
    public InputActionReference pitchRollAction; // Vector2 for pitch and roll
    public InputActionReference yawAction;      // Axis for yaw
    public InputActionReference throttleAction; // Axis for throttle

    private void OnEnable()
    {
        pitchRollAction.action.Enable();
        yawAction.action.Enable();
        throttleAction.action.Enable();
    }

    private void OnDisable()
    {
        pitchRollAction.action.Disable();
        yawAction.action.Disable();
        throttleAction.action.Disable();
    }

    private void Update()
    {
        ReadInput();
        HandleThrottle();
        HandleFlightControls();
        if (Input.GetMouseButton(0))
        {
            AttackCooldown();
        }
    }

    private void ReadInput()
    {
        pitchRollInput = pitchRollAction.action.ReadValue<Vector2>(); // Left Thumbstick or WASD
        yawInput = yawAction.action.ReadValue<float>();               // Right Thumbstick or Q/E
        throttleDelta = throttleAction.action.ReadValue<float>();     // Left Thumbstick or R/F
    }

    private void HandleThrottle()
    {
        throttleInput += throttleDelta * throttleSpeed * Time.deltaTime;
        throttleInput = Mathf.Clamp(throttleInput, minSpeed, maxSpeed);
    }

    private void HandleFlightControls()
    {
        float pitch = pitchRollInput.y * pitchSpeed * Time.deltaTime;
        float roll = pitchRollInput.x * rollSpeed * Time.deltaTime;
        float yaw = yawInput * yawSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, pitch);
        transform.Rotate(Vector3.up, yaw);
        transform.Rotate(Vector3.forward, -roll);

        transform.position += transform.forward * throttleInput * Time.deltaTime;
    }
    //shooting mechanic
    //public void ShootBullet()
    //{
    //    GameObject b = Instantiate(bulletPrefab) as GameObject;
    //    b.transform.position = gameObject.transform.position;

    //}

    public void AttackCooldown()
    {
        if (timer < attackCooldown)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ShootBullet();
            timer = 0;
        }
    }
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().damage = bulletDamage;

        timer = 1;
    }
}
