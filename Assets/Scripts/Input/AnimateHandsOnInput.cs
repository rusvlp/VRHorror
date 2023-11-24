using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandsOnInput : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private InputActionProperty _triggerInputAction;

    [SerializeField] private InputActionProperty _gripInputAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = _triggerInputAction.action.ReadValue<float>();
        _animator.SetFloat("Trigger", triggerValue);

        float gripValue = _gripInputAction.action.ReadValue<float>();
        _animator.SetFloat("Grip", gripValue);
    }
}
