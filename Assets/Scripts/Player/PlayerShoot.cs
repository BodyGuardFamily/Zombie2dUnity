using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField] private float _bulletSpeed;
    
    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;
    
    private bool _fireContinuously;
    //private bool _fireSingle;
    private float _lastFireTime;
    private int _currentAmmo;
    private int _minAmmo = 0;
    private int _maxAmmo = 10; 

    [SerializeField] private TextMeshProUGUI _ammoText;

    void Start()
    {
        _currentAmmo = _maxAmmo;
        UpdateAmmoText();
        Debug.Log("Called Ammo start");
    }
    
    private void Update()
    {

        if (_currentAmmo <= _minAmmo)
        {
            if (Keyboard.current.rKey.wasReleasedThisFrame)
            {
                Debug.Log("Reloading...");
                _currentAmmo = _maxAmmo;
                Debug.Log("Reload Complete");
            }
            else
            {
                Debug.Log("Player must reload");
            }
            return;
        }

        if (_fireContinuously /*|| _fireSingle*/) 
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                /*
                _fireSingle = false;
            */
            }
        }
    }

    private void FireBullet()
    {
        _currentAmmo--;
        UpdateAmmoText();

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f;

        // Calculate the direction from the player to the mouse cursor
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        // Instantiate the bullet and set its initial velocity
        
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, Quaternion.identity);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * _bulletSpeed;
    }

    private void OnFire(InputValue inputValue)
    {
        //_fireContinuously = inputValue.isPressed;
        _fireContinuously = inputValue.Get<float>() > 0;
        
        /*if (inputValue.isPressed)
        {
            _fireSingle = true;
        }*/
    }

    private void UpdateAmmoText()
    {
        Debug.Log("UpdateAmmoText() called");

        if (_ammoText != null)
        {
            _ammoText.text = "AMMO " + _currentAmmo.ToString();
            Debug.Log("Changed num: " + _currentAmmo.ToString());
        }
        else
        {
            Debug.Log("ammoText is null");
        }
    }

}