using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public enum FocusModes
{
    FOCUS_MODE_NORMAL,
    FOCUS_MODE_TRIGGERAUTO,
    FOCUS_MODE_CONTINUOUSAUTO,
    FOCUS_MODE_INFINITY,
    FOCUS_MODE_MACRO
}

public class SetCameraFocusMode : MonoBehaviour {

    public FocusModes focusMode;

    private bool mVuforiaStarted = false;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnApplicationPause);
    }

    /// <summary>
    /// Set focus mode as soon as Vuforia is loaded.
    /// </summary>
    private void OnVuforiaStarted()
    {
        mVuforiaStarted = true;
        SetFocusMode();
    }

    /// <summary>
    /// Restore focus mode after applications has been paused.
    /// </summary>
    /// <param name="pause">If applications is paused.</param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if (mVuforiaStarted)
            {
                SetFocusMode();
            }
        }
    }

    /// <summary>
    /// Set focus mode to selected mode.
    /// </summary>
    private void SetFocusMode()
    {
        switch (focusMode)
        {
            case FocusModes.FOCUS_MODE_NORMAL:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
                break;
            case FocusModes.FOCUS_MODE_TRIGGERAUTO:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
                break;
            case FocusModes.FOCUS_MODE_CONTINUOUSAUTO:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
                break;
            case FocusModes.FOCUS_MODE_INFINITY:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_INFINITY);
                break;
            case FocusModes.FOCUS_MODE_MACRO:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_MACRO);
                break;
            default:
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
                break;
        }
    }
}
