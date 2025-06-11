using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarLamparaDireccional : MonoBehaviour
{
    // Distancia m�xima del Raycast
    public float distanciaInteraccion = 15f;

    void Update()
    {
        // Verifica si se presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Crea un rayo desde la c�mara hacia donde el jugador est� mirando (centro de pantalla)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lanza el rayo y verifica si choca con algo
            if (Physics.Raycast(ray, out hit, distanciaInteraccion))
            {
                // Verifica si el objeto golpeado tiene el tag "Lamp"
                if (hit.collider.CompareTag("Lamp"))
                {
                    // Busca una luz dentro del objeto golpeado
                    Light luz = hit.collider.GetComponentInChildren<Light>();

                    // Si encuentra una luz, la enciende o apaga
                    if (luz != null)
                    {
                        luz.enabled = !luz.enabled;
                        Debug.Log("L�mpara activada/desactivada: " + luz.name);
                    }
                    else
                    {
                        Debug.LogWarning("No se encontr� una luz en el objeto Lamp.");
                    }
                }
            }
        }
    }
}
