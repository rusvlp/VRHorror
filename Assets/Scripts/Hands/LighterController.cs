using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float _speedLimit;

    [SerializeField] private float _hinegeOpenSpeed;
    
    [Header("Utils")]
    [SerializeField] private Transform _hinge;
    [SerializeField] private Transform _hand;

    [SerializeField] private float _currentYPos;
    [SerializeField] private float _previousYPos;

    [SerializeField] private float _ySpeed;

    [SerializeField] private bool _isOpened = false;
    
    void Start()
    {
        print("Sass");
      //  StartCoroutine(RotateHinge2Open());
    }

    // Update is called once per frame
    void Update()
    {
        
        _currentYPos = _hand.transform.position.y;
        CalculateYSpeed();
        _previousYPos = _currentYPos;
        
        OpenCloseLighter();
       // print(_isOpened);
    }

    private void OpenCloseLighter()
    {
        if (_ySpeed > _speedLimit && _ySpeed > 0)
        {
            if (_isOpened)
            {
                _isOpened = false;
            }
            else
            {
                _isOpened = true;
                //StopCoroutine(RotateHinge2Open());
            }
        }
    }
    
    private void CalculateYSpeed()
    {
        _ySpeed = _currentYPos - _previousYPos;
    }


    private IEnumerator RotateHinge2Open()
    {
        print("Coroutines Started");
        
        if (_hinge.transform.rotation.eulerAngles.x <= 120)
        {
            yield break;
        }

        var rotation = _hinge.transform.rotation.eulerAngles;
        Vector3 eulerAngle = new Vector3(rotation.x - _hinegeOpenSpeed, 90, -90); // Новые углы Эйлера (в градусах)
        _hinge.transform.rotation = Quaternion.Euler(eulerAngle);
        yield return new WaitForSeconds(1f);


    }

    private void RotateHinge2Close()
    {
        
    }
}
