using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    private GameObject LinePrefab = null;

    private Camera Camera = null;

    private bool isDrawing = false;

    private float minDist = 0.2f;

    private LineRenderer currentLine = null;
    private EdgeCollider2D currentEdgeCollider = null;

    [SerializeField]
    private GameObject TitleText = null;

    [SerializeField]
    private GameObject ExplanationText = null;

    List<Vector2> points = new List<Vector2>();

    private void Start()
    {
        Camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TitleText.SetActive(false);
            ExplanationText.SetActive(false);

            if (currentLine != null)
                Destroy(currentLine.gameObject);

            points = new List<Vector2>();
            Vector2 currentPos = Camera.ScreenToWorldPoint(Input.mousePosition);

            var line = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
            currentLine = line.GetComponent<LineRenderer>();
            currentEdgeCollider = line.GetComponent<EdgeCollider2D>();

            currentLine.positionCount = 1;
            currentLine.SetPosition(0, currentPos);

            points.Add(currentPos);

            isDrawing = true;
        }

        if (isDrawing && Input.GetMouseButtonUp(0))
            isDrawing = false;
    }

    private void FixedUpdate()
    {
        if (isDrawing)
            DrawLine();
    }

    public void DrawLine()
    {
        Vector2 currentPos = Camera.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(currentPos, points.Last()) > minDist)
        {
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, currentPos);

            points.Add(currentPos);
        }

        if (points.Count >= 2)
        {
            currentEdgeCollider.points = points.ToArray();
        }
    }
}
