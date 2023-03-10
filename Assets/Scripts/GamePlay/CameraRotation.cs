using UnityEngine;

// клас для анімації камери, та більш динамічного геймплею
public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public float rotationTime = 2.0f;
    
    private float rotationTimer = 0.0f;
    private int rotationDirection = 1;
    
    void Update()
    {
        // Увеличиваем таймер
        rotationTimer += Time.deltaTime;
        
        // Если таймер достиг заданного времени, меняем направление вращения
        if (rotationTimer >= rotationTime)
        {
            rotationTimer = 0.0f;
            rotationDirection *= -1;
        }
        
        // Вращаем камеру вокруг оси Y
        transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
    }
}