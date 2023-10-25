using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public Slider hungerSlider; // Referencia al objeto Slider de la barra de hambre.
    public float maxHunger = 100.0f; // Valor máximo de hambre.
    public float hungerDecreaseRate = 1.0f; // Tasa de disminución del hambre por segundo.

    private float currentHunger; // Valor actual de hambre.

    private void Start()
    {
        currentHunger = maxHunger;
        UpdateHungerBar();
        // Iniciar una rutina para disminuir el hambre con el tiempo.
        StartCoroutine(DecreaseHungerOverTime());
    }

    private void UpdateHungerBar()
    {
        // Actualizar la barra de estado de hambre.
        hungerSlider.value = currentHunger / maxHunger;
    }

    private IEnumerator DecreaseHungerOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // Disminuir el hambre cada segundo.

            // Disminuir el hambre.
            currentHunger -= hungerDecreaseRate;

            // Asegurarse de que el hambre no sea menor que 0.
            currentHunger = Mathf.Max(currentHunger, 0);

            // Actualizar la barra de estado.
            UpdateHungerBar();
        }
    }

    // Método para aumentar el hambre al alimentar a Pululu.
    public void FeedPululu(float foodAmount)
    {
        currentHunger += foodAmount;

        // Asegurarse de que el hambre no sea mayor que el valor máximo.
        currentHunger = Mathf.Min(currentHunger, maxHunger);

        // Actualizar la barra de estado.
        UpdateHungerBar();
    }
}
