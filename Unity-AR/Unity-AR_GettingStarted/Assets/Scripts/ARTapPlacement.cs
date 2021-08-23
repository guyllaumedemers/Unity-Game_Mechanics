using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class ARTapPlacement : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject instance;

    private ARSessionOrigin arOrigin;
    private ARRaycastManager arRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private void Awake()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        if (!arOrigin)
        {
            LogWarning("There is no ARSessionOrigin script attach in this scene " + SceneManager.GetActiveScene().name);
            return;
        }
        else if (!arRaycastManager)
        {
            LogWarning("There is no ARRaycastManager script attach in this scene " + SceneManager.GetActiveScene().name);
            return;
        }
    }

    private void Update()
    {
        if (instance && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began))
        {
            ARPlaceObject();
        }
        else if (instance && placementPoseIsValid && Input.touchCount.Equals(2))
        {
            ARRotateObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator()
    {
        if (!placementIndicator)
        {
            LogWarning("There is no placement indicator gameobject");
            return;
        }
        else if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else if (!placementPoseIsValid)
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }

    private void ARPlaceObject()
    {
        instance.transform.position = placementPose.position;
        instance.transform.rotation = placementPose.rotation;
    }

    private void ARRotateObject()
    {
        instance.transform.Rotate(Vector3.up * 50.0f * Time.deltaTime, Space.Self);
    }

    private void LogWarning(string msg) => Debug.LogWarning("[ARTapPlacement] : " + msg);
}
