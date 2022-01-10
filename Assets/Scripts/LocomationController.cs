using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomationController : MonoBehaviour
{
    public XRController rightTelportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool EnableRightTeleport { get; set; } = true;


    // Update is called once per frame
    void Update()
    {
        if (rightTelportRay)
        {
            rightTelportRay.gameObject.SetActive(EnableRightTeleport && CheckIfActived(rightTelportRay));
        }
    }

    public bool CheckIfActived(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
