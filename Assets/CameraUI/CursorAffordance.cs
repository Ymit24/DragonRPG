using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D targetCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotspot = Vector2.zero;

    // TODO dont hardcode, the const breaks the SerializeField
    [SerializeField] const int WalkableLayer = 8;
    [SerializeField] const int EnemyLayer = 9;

	void Start () {
        GetComponent<CameraRaycaster>().notifyLayerChangeObservers += OnLayerChanged;
	}

    void OnLayerChanged(int newLayer) {
        switch (newLayer)
        {
            case WalkableLayer:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case EnemyLayer:
                Cursor.SetCursor(targetCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                break;
        }
	}
}
