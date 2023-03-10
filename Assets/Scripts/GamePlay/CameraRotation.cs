using UnityEngine;

// ���� ��� ������� ������, �� ���� ���������� ��������
public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public float rotationTime = 2.0f;
    
    private float rotationTimer = 0.0f;
    private int rotationDirection = 1;
    
    void Update()
    {
        // ����������� ������
        rotationTimer += Time.deltaTime;
        
        // ���� ������ ������ ��������� �������, ������ ����������� ��������
        if (rotationTimer >= rotationTime)
        {
            rotationTimer = 0.0f;
            rotationDirection *= -1;
        }
        
        // ������� ������ ������ ��� Y
        transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
    }
}