using UnityEngine;
using UnityEngine.UI;

public class SimpleDifficultyManager : MonoBehaviour
{
    public Toggle easyToggle;
    public Toggle mediumToggle;
    public Toggle hardToggle;

    private string selectedDifficulty = "medio"; // Valor padrão inicializado

    void Start()
    {
        UpdateSelectedDifficulty(); // Atualiza a dificuldade com base nos toggles iniciais

        easyToggle.onValueChanged.AddListener(OnEasyToggleChanged);
        mediumToggle.onValueChanged.AddListener(OnMediumToggleChanged);
        hardToggle.onValueChanged.AddListener(OnHardToggleChanged);
    }

    void OnDisable()
    {
        // Remove os listeners quando o script é desativado
        easyToggle.onValueChanged.RemoveListener(OnEasyToggleChanged);
        mediumToggle.onValueChanged.RemoveListener(OnMediumToggleChanged);
        hardToggle.onValueChanged.RemoveListener(OnHardToggleChanged);
    }

    void UpdateSelectedDifficulty()
    {
        if (easyToggle.isOn)
        {
            selectedDifficulty = "facil";
        }
        else if (mediumToggle.isOn)
        {
            selectedDifficulty = "medio";
        }
        else if (hardToggle.isOn)
        {
            selectedDifficulty = "dificil";
        }

        PlayerPrefs.SetString("SelectedDifficulty", selectedDifficulty); // Salva a dificuldade selecionada
        PlayerPrefs.Save(); // Garante que os dados sejam salvos imediatamente

    }

    private void OnEasyToggleChanged(bool isOn)
    {
        if (isOn)
        {
            selectedDifficulty = "facil";
            UpdateSelectedDifficulty();
        }
    }

    private void OnMediumToggleChanged(bool isOn)
    {
        if (isOn)
        {
            selectedDifficulty = "medio";
            UpdateSelectedDifficulty();
        }
    }

    private void OnHardToggleChanged(bool isOn)
    {
        if (isOn)
        {
            selectedDifficulty = "dificil";
            UpdateSelectedDifficulty();
        }
    }

    public string GetSelectedDifficulty()
    {
        return selectedDifficulty;
    }

}
