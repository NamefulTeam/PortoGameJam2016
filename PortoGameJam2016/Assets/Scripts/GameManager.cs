﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Mode CurrentMode = Mode.TopDown;
    public bool AllowTwisting = true;

    CameraController cameraController;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        cameraController = GetComponent<CameraController>();

        if (CurrentMode == Mode.TopDown)
        {
            cameraController.SwitchToTopDown();
        }
        else
        {
            cameraController.SwitchToSideScroller();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Twist") && AllowTwisting)
        {
            if (CurrentMode == Mode.TopDown)
            {
                cameraController.RotateToSideScroller();
                GetComponent<TransitionManager>().Twist(Mode.SideScroller);

            } else if(CurrentMode == Mode.SideScroller) {
                GetComponent<TransitionManager>().Twist(Mode.TopDown);
                cameraController.RotateToTopDown();
            }
        }

    }
}

public enum Mode
{
    SideScroller,
    TopDown,
    TransitioningToSideScroller,
    TransitioningToTopDown
}
