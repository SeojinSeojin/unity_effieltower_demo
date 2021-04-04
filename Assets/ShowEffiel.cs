using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffiel : MonoBehaviour
{
    public float SightAngle = 1f;
    public Transform playerBody;
    private bool inSightFlag = false;
    public GameObject tooltip;

    bool IsTargetInSight()
    {
        Vector3 targetDir = (Vector3.zero - playerBody.position).normalized;
        float dot = Vector3.Dot(playerBody.forward, targetDir);

        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (theta <= 10f) {
            Debug.Log(theta);
            return true;
        }
        else return false;
    }

    void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        HideTooltip();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTargetInSight())
        {
            if(!inSightFlag)
            {
                inSightFlag = true;
                Debug.Log("In Sight Flag Changed to True");
                ShowTooltip();
            }
        } else
        {
            if (inSightFlag)
            {
                inSightFlag = false;
                Debug.Log("In Sight Flag Changed to False");
                HideTooltip();
            }
        }
    }
}
