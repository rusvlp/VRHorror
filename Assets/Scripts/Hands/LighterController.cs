using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LighterController : MonoBehaviour
{


    [Header("Settings")]
    [SerializeField] private float _speedUpperLimit;

    [SerializeField] private float _speedLowerLimit;

    [SerializeField] private float _hinegeOpenSpeed;

    [Header("Utils")] [SerializeField] private TMP_Text _isOpenedText;
    
    [SerializeField] private Transform _hinge;
    [SerializeField] private Transform _hand;

    [SerializeField] private float _currentYPos;
    [SerializeField] private float _previousYPos;

    [SerializeField] private float _ySpeed;

    [SerializeField] private bool _isOpened = false;
    [SerializeField] private float _delayTime;
    [SerializeField] private bool _isOpenedLocked = false;
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

        _isOpenedText.SetText(_isOpened.ToString());
        // print(_isOpened);
    }

    public IEnumerator StartDelay()
    {
        _isOpenedLocked = true;
        yield return new WaitForSeconds(_delayTime);
        _isOpenedLocked = false;
    }
    
    private void OpenCloseLighter()
    {
        if ((Mathf.Abs(_ySpeed) < _speedUpperLimit && Mathf.Abs(_ySpeed) > _speedLowerLimit) &&  !_isOpenedLocked)
        {
            if (_isOpened)
            {
                _isOpened = false;
                StartCoroutine(StartDelay());
            }
            else
            {
                _isOpened = true;
                StartCoroutine(StartDelay());
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
