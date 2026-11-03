using System;
using TMPro;
using UnityEngine;

public class PCAssemblyController : MonoBehaviour
{
    [Serializable]
    public class AssemblyStep
    {
        [Header("Інформація")]
        public string partName;

        [TextArea(3, 6)]
        public string partDescription;

        [TextArea(2, 5)]
        public string instruction;

        [Header("Об'єкти сцени")]
        public GameObject highlightMarker;
    }

    [Header("Етапи складання")]
    [SerializeField] private AssemblyStep[] steps;

    [Header("InfoPanel")]
    [SerializeField] private TMP_Text partNameText;
    [SerializeField] private TMP_Text partDescriptionText;

    [Header("AssemblyPanel")]
    [SerializeField] private TMP_Text stepTitleText;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text resultText;

    private int currentStepIndex;

    private void Start()
    {
        if (steps == null || steps.Length == 0)
        {
            Debug.LogWarning("У PCAssemblyController не додано етапи.");
            return;
        }

        ShowStep(0);
    }

    public void ShowNextStep()
    {
        if (currentStepIndex >= steps.Length - 1)
        {
            resultText.text = "Це останній компонент.";
            return;
        }

        ShowStep(currentStepIndex + 1);
    }

    public void ShowPreviousStep()
    {
        if (currentStepIndex <= 0)
        {
            resultText.text = "Це перший компонент.";
            return;
        }

        ShowStep(currentStepIndex - 1);
    }

    private void ShowStep(int stepIndex)
    {
        currentStepIndex = stepIndex;

        // Вимикаємо всі маркери.
        foreach (AssemblyStep step in steps)
        {
            if (step.highlightMarker != null)
            {
                step.highlightMarker.SetActive(false);
            }
        }

        AssemblyStep currentStep = steps[currentStepIndex];

        // Вмикаємо маркер поточного компонента.
        if (currentStep.highlightMarker != null)
        {
            currentStep.highlightMarker.SetActive(true);
        }

        // Оновлюємо InfoPanel.
        partNameText.text = currentStep.partName;
        partDescriptionText.text = currentStep.partDescription;

        // Оновлюємо AssemblyPanel.
        stepTitleText.text =
            $"Етап {currentStepIndex + 1} із {steps.Length}";

        instructionText.text = currentStep.instruction;

        resultText.text =
            $"Поточний компонент: {currentStep.partName}";
    }
}