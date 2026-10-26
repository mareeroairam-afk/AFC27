using UnityEngine;
using UnityEngine.Events;

// Coloca este script en una zona invisible detrás de la línea de gol.
// El collider de la zona debe tener Is Trigger activado.
public class AFC27GoalTrigger : MonoBehaviour
{
    public UnityEvent onGoal;
    private bool scored;

    void OnTriggerEnter(Collider other)
    {
        if (scored || !other.GetComponent<AFC27Ball>()) return;
        scored = true;
        Debug.Log("¡GOOOL! AFC 27");
        onGoal?.Invoke();
        Invoke(nameof(ResetGoal), 2f);
    }

    void ResetGoal() { scored = false; }
}
