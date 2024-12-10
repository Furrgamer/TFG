using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class DropdownController : MonoBehaviour
{
    [SerializeField] private List<LocalizedString> dropdownOptions;
    private TMP_Dropdown _tmpDropdown;

    private void Awake()
    {
        if (_tmpDropdown == null)
            _tmpDropdown = GetComponent<TMP_Dropdown>();

        OptionsLocale();

        LocalizationSettings.SelectedLocaleChanged += ChangedLocale;
    }

    private void ChangedLocale(Locale newLocale)
    {
        OptionsLocale();
    }

    private void OptionsLocale()
    {
        List<TMP_Dropdown.OptionData> tmpDropdownOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var dropdownOption in dropdownOptions)
        {
            tmpDropdownOptions.Add(new TMP_Dropdown.OptionData(dropdownOption.GetLocalizedString()));
        }
        _tmpDropdown.options = tmpDropdownOptions;
    }
}

