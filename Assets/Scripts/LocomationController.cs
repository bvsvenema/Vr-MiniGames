using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomationController : MonoBehaviour
{
    public XRController rightTelportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor rightRayInteractor;

    public bool EnableRightTeleport { get; set; } = true;


    // Update is called once per frame
    void Update()
    {
       /* Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;*/

        if (rightTelportRay)
        {
            //bool isRightInteractionRayHovering = rightRayInteractor.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            rightTelportRay.gameObject.SetActive(EnableRightTeleport && CheckIfActived(rightTelportRay) 
                && !rightRayInteractor.TryGetHitInfo(out Vector3 pos, out Vector3 norm, out int index, out bool validTarget));
        }
    }

    public bool CheckIfActived(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
