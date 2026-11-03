using UnityEngine;

public class UIPanelSwitcher : MonoBehaviour
{
    [Header("Панелі меню")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject formPanel;
    [SerializeField] private GameObject assemblyPanel;

    private void Start()
    {
        ShowInfoPanel();
    }

    public void ShowInfoPanel()
    {
        SetActivePanel(infoPanel);
    }

    public void ShowFormPanel()
    {
        SetActivePanel(formPanel);
    }

    public void ShowAssemblyPanel()
    {
        SetActivePanel(assemblyPanel);
    }

    private void SetActivePanel(GameObject selectedPanel)
    {
        infoPanel.SetActive(selectedPanel == infoPanel);
        formPanel.SetActive(selectedPanel == formPanel);
        assemblyPanel.SetActive(selectedPanel == assemblyPanel);
    }
}