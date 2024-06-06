using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    // ������ �� ��������� AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // ���������� ��� ����� � �������
    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ ������� ��� ������ ������ ��������
        if (other.CompareTag("MainCamera"))
        {
            // ���������� ��������� ����� �� 0 �� 1
            float randomValue = Random.value;

            // � ������������ 50% ����������� ������
            if (randomValue < 0.5f)
            {
                PlayMusic();
            }
        }
    }

    // ����� ��� ��������������� ������
    private void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // ������������� ������
        }
    }
}
