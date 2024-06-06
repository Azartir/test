using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // �������� �������� ���������
    public float mouseSensitivity = 2f; // ���������������� ����
    public float verticalLookLimit = 80f; // ����� ������������� �������� ������

    private CharacterController characterController;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // ��������� ������ � ������ ������
    }

    void Update()
    {
        Move();
        RotateCamera();
    }

    void Move()
    {
        // �������� ��� �����
        float moveDirectionY = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");

        // ���������� ����������� ��������
        Vector3 moveDirection = transform.forward * moveDirectionY + transform.right * moveDirectionX;
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

        // ���������� ���������
        characterController.Move(moveDirection);
    }

    void RotateCamera()
    {
        // �������� �������� �� ���� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������������ ��������� �� ����������� (�����/������)
        transform.Rotate(0f, mouseX, 0f);

        // ������������ ������ �� ��������� (�����/����)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        // ������������ ������ �� ����������� (�����/������)
        horizontalRotation += mouseX;
        horizontalRotation %= 360; // ������������ ���� 0-360 ��������

        // ��������� ��������� ������
        Camera.main.transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0f);
    }
}
