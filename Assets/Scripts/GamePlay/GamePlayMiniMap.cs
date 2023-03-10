using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMiniMap : MonoBehaviour
{
    public GameObject objectOnPlate;
    public Image objectOnPlateIndicator;
    public Camera mainCamera; // ������� ������, ������������ ������� ����� �������������� ����������
    public RectTransform miniMapRectTransform; // RectTransform ����-�����

    public Vector2 worldToMiniMap(Vector3 worldPosition)
    {
        Vector3 positionInViewport = mainCamera.WorldToViewportPoint(worldPosition); // �������� ������� ������� �� Viewport
        Vector2 size = miniMapRectTransform.rect.size; // �������� ������� ����-�����
        Vector2 miniMapCenter = miniMapRectTransform.anchoredPosition; // �������� ����� ����-�����
        Vector2 positionInMiniMap = new Vector2(
            miniMapCenter.x + (positionInViewport.x - 0.5f) * size.x,
            miniMapCenter.y + (positionInViewport.z - 0.5f) * size.y); // ������������ ������� ������� �� ����-�����

        return positionInMiniMap;
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            objectOnPlateIndicator.transform.position = worldToMiniMap(objectOnPlate.transform.position);
        }
    }
}
