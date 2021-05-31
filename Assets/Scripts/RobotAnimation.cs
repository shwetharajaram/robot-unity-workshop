using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    public float rotSpeed = 40f;
    public float rollSpeed = 2.0f;
    public float scaleSpeed = 5.0f;

    private Animator anim;

    public bool onTeleportTarget = false;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T)) { TeleportToTarget(Vector3.zero); }    // FOR TESTING
    //}


    #region Rolling to Targets
    public void RollToTarget(Vector3 targetPosition)
    {
        StartCoroutine(RollToTargetAnim(targetPosition));
    }

    private IEnumerator RollToTargetAnim(Vector3 targetPosition)
    {
        // set landingTarget's y-value to same as robot's y-value 
        //Vector3 targetPosition = new Vector3(landingTarget.position.x, transform.position.y, landingTarget.position.z);

        ToggleWalkAnimation();

        // rotate robot towards target
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        while (Quaternion.Angle(targetRotation, transform.rotation) > 0.01)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
            yield return null;
        }
        // set rotation to perfect value
        transform.rotation = targetRotation;

        ToggleWalkAnimation();
        yield return new WaitForSeconds(0.5f);

        // roll into ball
        ToggleRollAnimation();
        yield return new WaitForSeconds(2.0f);

        // move towards target
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, rollSpeed * Time.deltaTime);
            yield return null;
        }

        // expand from ball
        ToggleRollAnimation();
    }
    #endregion


    #region Teleporting to Targets
    public void TeleportToTarget(Vector3 targetPosition)
    {
        // TODO: call coroutine
    }

    private IEnumerator TeleportToTargetAnim(Vector3 targetPosition)
    {
        Vector3 originalScale = this.transform.localScale;  // save the Robot's original scale

        // TODO: scale the robot down (localScale)
        

        // TODO: wait for 2 seconds


        // TODO: move the robot to the targetPosition


        // TODO: scale the robot back up to original (localScale)
        

        // TODO: set scale back to original (in case it hasn't scaled up all the way - this can happen if the speed is too fast)

        yield return null;
    }
    #endregion


    #region Asset animations
    private void ToggleRollAnimation()
    {
        if (anim.GetBool("Roll_Anim"))
        {
            anim.SetBool("Roll_Anim", false);
        }
        else
        {
            anim.SetBool("Roll_Anim", true);
        }
    }

    private void ToggleWalkAnimation()
    {
        if (anim.GetBool("Walk_Anim"))
        {
            anim.SetBool("Walk_Anim", false);
        }
        else
        {
            anim.SetBool("Walk_Anim", true);
        }
    }
    #endregion
}
