using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Zoom")]
    [SerializeField] private float _currentZoom = 20.0f;
    [SerializeField] private float _minZoom = 10.0f;
    [SerializeField] private float _maxZoom = 30.0f;
   
    private float _zoomSpeed = 4.0f;
    
    private float _rotationY;

    private void Update() {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
    }

    private void LateUpdate() {
        transform.position = _target.position - transform.forward * _currentZoom;
    }
}
