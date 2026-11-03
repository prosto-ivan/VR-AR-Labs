using TMPro;
using UnityEngine;

public class VRKeyboardController : MonoBehaviour
{
    [Header("Поле введення")]
    [SerializeField] private TMP_InputField targetInputField;

    [Header("Панель клавіатури")]
    [SerializeField] private GameObject keyboardPanel;

    [Header("Обмеження")]
    [SerializeField] private int maximumLength = 30;

    public void OpenKeyboard()
    {
        keyboardPanel.SetActive(true);

        targetInputField.Select();
        targetInputField.ActivateInputField();
        targetInputField.MoveTextEnd(false);
    }

    public void AddCharacter(string character)
    {
        if (targetInputField.text.Length >= maximumLength)
        {
            return;
        }

        targetInputField.text += character;
        MoveCaretToEnd();
    }

    public void AddSpace()
    {
        if (targetInputField.text.Length >= maximumLength)
        {
            return;
        }

        targetInputField.text += " ";
        MoveCaretToEnd();
    }

    public void Backspace()
    {
        string currentText = targetInputField.text;

        if (string.IsNullOrEmpty(currentText))
        {
            return;
        }

        targetInputField.text =
            currentText.Substring(0, currentText.Length - 1);

        MoveCaretToEnd();
    }

    public void ClearText()
    {
        targetInputField.text = "";
        MoveCaretToEnd();
    }

    public void CloseKeyboard()
    {
        targetInputField.DeactivateInputField();
        keyboardPanel.SetActive(false);
    }

    private void MoveCaretToEnd()
    {
        targetInputField.caretPosition =
            targetInputField.text.Length;

        targetInputField.ForceLabelUpdate();
    }
}