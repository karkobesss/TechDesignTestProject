using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpineAnim : MonoBehaviour
{
     public float moveSpeed = 5f; // Скорость перемещения игрока

    private float screenWidth; // Ширина экрана в мировых координатах

    private bool movingRight = true; // Флаг для определения направления движения

    void Start()
    {
        // Получаем ширину экрана в мировых координатах
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Получаем текущий масштаб игрока
        Vector3 currentScale = transform.localScale;

        // Получаем текущую позицию игрока
        Vector3 currentPosition = transform.position;

        // Вычисляем новую позицию с учетом перемещения вдоль оси X
        float newXPosition = currentPosition.x + (movingRight ? moveSpeed : -moveSpeed) * Time.deltaTime;

        // Ограничиваем позицию по оси X в пределах экрана
        newXPosition = Mathf.Clamp(newXPosition, -screenWidth, screenWidth);

        // Применяем новую позицию к игроку
        transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);

        // Проверяем и меняем направление движения, если игрок достиг границы экрана
        if (newXPosition >= screenWidth || newXPosition <= -screenWidth)
        {
            movingRight = !movingRight;

            // Изменяем масштаб по оси X, чтобы отзеркалить персонажа
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
    }
}
