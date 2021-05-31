using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Target;

public class AppManager : MonoBehaviour
{
    // ***** Singleton Pattern *****
    public static AppManager Instance { get; private set; }

    public GameObject Robot;
    private RobotAnimation robotScript;

    private void Awake()
    {
        // Singleton pattern --> ensures that there is only 1 running instance of the AppManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        robotScript = Robot.GetComponent<RobotAnimation>();
    }

    public void OnTargetSelected(Vector3 targetPosition, TargetType targetType)  // called when the user selects a target for the Robot to move to
    {
        if (targetType == TargetType.Rollable) { robotScript.RollToTarget(targetPosition); }

        else if (targetType == TargetType.Teleportable) {
            // TODO
        }
    }
}
