using System;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof (AICharacterControl))]
public class PlayerMovement : MonoBehaviour
{
    // TODO dont hardcode, the const breaks the SerializeField
    [SerializeField] const int WalkableLayer = 8;
    [SerializeField] const int EnemyLayer = 9;

    ThirdPersonCharacter thirdPersonCharacter = null;
    CameraRaycaster cameraRaycaster = null;
    Vector3 currentDestination, clickPoint;
    AICharacterControl aiCharacterControl = null;
    GameObject walkTarget = null;

    bool isInDirectMode = false;

    void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
        aiCharacterControl = GetComponent<AICharacterControl>();
        walkTarget = new GameObject("Walk Target");

        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
    }

    void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        switch (layerHit)
        {
            case WalkableLayer:
                walkTarget.transform.position = raycastHit.point;
                aiCharacterControl.SetTarget(walkTarget.transform);
                break;
            case EnemyLayer:
                GameObject enemy = raycastHit.collider.gameObject;
                aiCharacterControl.SetTarget(enemy.transform);
                break;
            default:
                Debug.LogWarning("Don't know how to handle mouse click for this layer -- player movement");
                break;
        }
    }

    // TODO make this get called again
    void ProcessDirectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 Movement = v * CamForward + h * Camera.main.transform.right;
        thirdPersonCharacter.Move(Movement, false, false);
    }
}

