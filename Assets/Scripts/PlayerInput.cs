using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
  public LineRenderer lineRenderer;
  public Material lineMaterial;
  private int numOfLines = 0;

  private Vector3 initialMouseDownPosition;
  private bool prevMouseDown = false;

  void Update()
  {
    bool isMouseDown = Input.GetMouseButton(0);
    if (isMouseDown && !prevMouseDown) {
      handleMouseDown();
    } else if (!isMouseDown && prevMouseDown) {
      handleMouseUp();
    } else if (isMouseDown && prevMouseDown) {
      handleDrag();
    }
    prevMouseDown = isMouseDown;
  }

  public void handleMouseDown()
  {
    if (lineRenderer == null) {
      initializeLineRenderer();
    }

    initialMouseDownPosition = getActualMousePosition();
    lineRenderer.SetPosition(0, initialMouseDownPosition);
    lineRenderer.SetPosition(1, initialMouseDownPosition);
  }

  public void handleDrag()
  {
    initialMouseDownPosition = getActualMousePosition();
    lineRenderer.SetPosition(1, initialMouseDownPosition);
  }

  public void handleMouseUp()
  {
    initialMouseDownPosition = getActualMousePosition();
    lineRenderer.SetPosition(1, initialMouseDownPosition);
    lineRenderer = null;
    numOfLines++;
  }

  private void initializeLineRenderer()
  {
    lineRenderer = new GameObject("PlayerWall-" + numOfLines).AddComponent<LineRenderer>();
    lineRenderer.material = lineMaterial;
    lineRenderer.positionCount = 2;
    lineRenderer.startWidth = 0.1f;
    lineRenderer.endWidth = 0.1f;
    lineRenderer.useWorldSpace = false;
  }

  private Vector3 getActualMousePosition()
  {
    Vector3 inputMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    inputMousePosition.z = 0;

    return inputMousePosition;
  }
}
