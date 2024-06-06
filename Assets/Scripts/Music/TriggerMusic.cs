using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    // Ссылка на компонент AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Вызывается при входе в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект игроком или другим нужным объектом
        if (other.CompareTag("MainCamera"))
        {
            // Генерируем случайное число от 0 до 1
            float randomValue = Random.value;

            // С вероятностью 50% проигрываем музыку
            if (randomValue < 0.5f)
            {
                PlayMusic();
            }
        }
    }

    // Метод для воспроизведения музыки
    private void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // Воспроизводим музыку
        }
    }
}
