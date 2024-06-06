using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Скорость движения персонажа
    public float mouseSensitivity = 2f; // Чувствительность мыши
    public float verticalLookLimit = 80f; // Лимит вертикального вращения камеры

    private CharacterController characterController;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор в центре экрана
    }

    void Update()
    {
        Move();
        RotateCamera();
    }

    void Move()
    {
        // Получаем оси ввода
        float moveDirectionY = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");

        // Определяем направление движения
        Vector3 moveDirection = transform.forward * moveDirectionY + transform.right * moveDirectionX;
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Перемещаем персонажа
        characterController.Move(moveDirection);
    }

    void RotateCamera()
    {
        // Получаем значения по осям мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Поворачиваем персонажа по горизонтали (влево/вправо)
        transform.Rotate(0f, mouseX, 0f);

        // Поворачиваем камеру по вертикали (вверх/вниз)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        // Поворачиваем камеру по горизонтали (влево/вправо)
        horizontalRotation += mouseX;
        horizontalRotation %= 360; // Ограничиваем угол 0-360 градусов

        // Обновляем положение камеры
        Camera.main.transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0f);
    }
}
