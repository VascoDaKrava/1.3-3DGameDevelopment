using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    private Animator _animator;

    private bool _activateIK = false;
    private Transform _pickupObj = null;

    public bool ActivateIK { get { return _activateIK; } set { _activateIK = value; } }

    public Transform PickUpTransform { set { _pickupObj = value; } }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_activateIK)
        {
            if (_pickupObj != null)
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(_pickupObj.position);
            }

            if (_pickupObj != null)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                _animator.SetIKPosition(AvatarIKGoal.RightHand, _pickupObj.position);
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pickupObj.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, _pickupObj.rotation);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pickupObj.rotation);
            }
        }

        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetLookAtWeight(0);
        }
    }
}
