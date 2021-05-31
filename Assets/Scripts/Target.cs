using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum TargetType { Rollable, Teleportable };
    public TargetType targetType;


    public void OnTargetSelected()
    {
        Debug.Log(targetType.ToString() + " target selected!");
        AppManager.Instance.OnTargetSelected(transform.position, targetType);
    }
}