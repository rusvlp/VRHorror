using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimationController : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    [SerializeField] private float _gripValue;

    [SerializeField] private float _triggerValue;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Trigger", _triggerValue);
        _animator.SetFloat("Grip", _gripValue);
    }
}
