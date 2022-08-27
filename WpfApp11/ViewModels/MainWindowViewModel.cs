using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using CV19.Models;
using CV19.Services.Interface;
using Microsoft.Win32;
using WpfApp11.Infrastructure.Commands.Base;
using WpfApp11.ViewModels.Base;


namespace WpfApp11.ViewModels;

internal class MainWindowViewModel : ViewModel
{

    #region Сервисы

    private IDataService _DataService;

    #endregion

    #region Свойства

    #region Title : string - Заголовок окна

    private string _Title = "Статистика COVID-19 в мире";

    public string Title
    {
        get => _Title;
        set => SetField(ref _Title, value);
    }

    #endregion

    #region Filter : string - Фильтр

    private string _Filter = String.Empty;

    public string Filter
    {
        get => _Filter;
        set
        {
            if(!SetField(ref _Filter, value)) return;
            FilteredCountries.Refresh();
            OnPropertyChanged(nameof(FilteredCountries));

        }
    }

    #endregion

    #region FilteredCountries : CollectionViewSource - Отфильтрованные страны

    private CollectionViewSource _FilteredCountries = new CollectionViewSource();

    public ICollectionView FilteredCountries => _FilteredCountries.View;

    #endregion

    #region Countries : IList<Country> - Страны

    private IList<CountryInfo> _Countries;
    public IList<CountryInfo> Countries
    {
        get => _Countries;
        set
        {
            if(!SetField(ref _Countries, value)) return;
            CountryName = _Countries.Select(i => i.Name).ToArray();
            _FilteredCountries.Source = CountryName;
            FilteredCountries.Refresh();
            OnPropertyChanged(nameof(FilteredCountries));
        }
    }

    #endregion

    #region CountryName : string - Названия стран

    private IList<string> _CountryName = new List<string>();

    public IList<string> CountryName
    {
        get => _CountryName;
        set => SetField(ref _CountryName, value);
    }

    #endregion

    #region SelectedCountry : CountryInfo - Название выбранной страны

    private string _SelectedCountryName;

    public string SelectedCountryName
    {
        get => _SelectedCountryName;
        set
        {
            SetField(ref _SelectedCountryName, value);
            OnPropertyChanged(nameof(SelectedCountry));
        }
    }

    #endregion

    #region SelectedCountry : CountryInfo - Выбранная страна

    private CountryInfo _SelectedCountry = null;
    public CountryInfo? SelectedCountry
    {
        get
        {
            return Countries?.Where(c => c.Name == _SelectedCountryName)?.FirstOrDefault();
        }
        set
        {
            SetField(ref _SelectedCountry, value);
        }
    }

    #endregion

    #endregion

    #region Команды

    #region LoadData

    public ICommand LoadData { get; }

    private void OnLoadDataExecuted(object p)
    {
        Countries = _DataService.GetData().ToArray();
    }

    #endregion

    #endregion

    #region Методы

    private void OnFiltered(object sender, FilterEventArgs e)
    {
        if(!(e.Item is string countryName)) return;
        if (countryName.Contains(Filter)) return;
        e.Accepted = false;
    }

    #endregion


    private MainWindowViewModel()
    {
        LoadData = new LambdaCommand(OnLoadDataExecuted);

        _FilteredCountries.Source = CountryName;
        _FilteredCountries.Filter += OnFiltered;

    }


    public MainWindowViewModel(IDataService dataService) : this()
    {
        _DataService = dataService;
    }
    
}