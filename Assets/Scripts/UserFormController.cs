using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserFormController : MonoBehaviour
{
    [Header("Поля форми")]
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Toggle experienceToggle;
    [SerializeField] private Slider knowledgeSlider;

    [Header("Текст")]
    [SerializeField] private TMP_Text sliderValueText;
    [SerializeField] private TMP_Text formStatusText;

    private const string NameKey = "UserName";
    private const string ExperienceKey = "HasPCExperience";
    private const string KnowledgeKey = "KnowledgeLevel";

    private void Start()
    {
        knowledgeSlider.wholeNumbers = true;
        knowledgeSlider.minValue = 0;
        knowledgeSlider.maxValue = 10;

        knowledgeSlider.onValueChanged.AddListener(UpdateSliderText);

        LoadForm();
        UpdateSliderText(knowledgeSlider.value);
    }

    private void OnDestroy()
    {
        knowledgeSlider.onValueChanged.RemoveListener(UpdateSliderText);
    }

    private void UpdateSliderText(float value)
    {
        sliderValueText.text =
            $"Рівень знань: {Mathf.RoundToInt(value)} із 10";
    }

    public void SaveForm()
    {
        string userName = nameInputField.text.Trim();

        if (string.IsNullOrEmpty(userName))
        {
            formStatusText.text = "Введіть ім’я";
            formStatusText.color = new Color(1f, 0.35f, 0.35f);
            return;
        }

        PlayerPrefs.SetString(NameKey, userName);
        PlayerPrefs.SetInt(
            ExperienceKey,
            experienceToggle.isOn ? 1 : 0
        );
        PlayerPrefs.SetInt(
            KnowledgeKey,
            Mathf.RoundToInt(knowledgeSlider.value)
        );

        PlayerPrefs.Save();

        formStatusText.text = "Дані успішно збережено";
        formStatusText.color = new Color(0.25f, 1f, 0.35f);
    }

    public void ResetForm()
    {
        nameInputField.text = "";
        experienceToggle.isOn = false;
        knowledgeSlider.value = 0;

        PlayerPrefs.DeleteKey(NameKey);
        PlayerPrefs.DeleteKey(ExperienceKey);
        PlayerPrefs.DeleteKey(KnowledgeKey);
        PlayerPrefs.Save();

        UpdateSliderText(0);

        formStatusText.text = "Форму очищено";
        formStatusText.color = Color.white;
    }

    private void LoadForm()
    {
        nameInputField.text =
            PlayerPrefs.GetString(NameKey, "");

        experienceToggle.isOn =
            PlayerPrefs.GetInt(ExperienceKey, 0) == 1;

        knowledgeSlider.value =
            PlayerPrefs.GetInt(KnowledgeKey, 0);
    }
}