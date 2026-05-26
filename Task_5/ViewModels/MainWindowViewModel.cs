using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task_5.Models;
namespace Task_5.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasSelectedClient))]
    [NotifyCanExecuteChangedFor(nameof(DeleteClientCommand))]
    [NotifyCanExecuteChangedFor(nameof(AddOrderCommand))]
    private ClientItem? _selectedClient;
    
    [ObservableProperty] private string _searchText = string.Empty;

    public bool HasSelectedClient => SelectedClient is not null;
    
    public ObservableCollection<ClientItem> FilteredClients { get; } = new();
    
    public ObservableCollection<ClientItem> Clients { get; } = new()
    {
        new ClientItem("Ivan Petrov", "+7 111 111-11-11", "ivan@mail.com", true),
        new ClientItem("Anna Smirnova", "+7 222 222-22-22", "anna@mail.com", false, new[]
        {
            new OrderItem(1, new DateTime(2026, 5, 24), 1000, OrderStatus.New),
            new OrderItem(2, new DateTime(2026, 5, 25), 2500, OrderStatus.Paid)
        }),
        new ClientItem("Oleg Ivanov", "+7 333 333-33-33", "oleg@mail.com", false, new[]
        {
            new OrderItem(1, new DateTime(2026, 5, 24), 1000, OrderStatus.New),
            new OrderItem(2, new DateTime(2026, 5, 25), 2500, OrderStatus.Paid),
            new OrderItem(3, new DateTime(2026, 5, 26), 200, OrderStatus.Cancelled)
        })
    };

    public MainWindowViewModel()
    {
        RefreshFilteredClients();
    }

    [RelayCommand]
    private void AddClient()
    {
        string name = (string.IsNullOrWhiteSpace(SearchText)) ? "New client" : SearchText;
        var client = new ClientItem(name, null, null, true);
        
        Clients.Add(client);
        RefreshFilteredClients();
        SelectedClient = client;
    }
    
    [RelayCommand(CanExecute = nameof(HasSelectedClient))]
    private void DeleteClient()
    {
        if (SelectedClient != null)
        {
            Clients.Remove(SelectedClient);
            SelectedClient = null;
            RefreshFilteredClients();
        }
    }

    [RelayCommand(CanExecute = nameof(HasSelectedClient))]
    private void AddOrder()
    {
        if (SelectedClient != null)
        {
            SelectedClient.Orders.Add(new OrderItem(SelectedClient.Orders.Count + 1, DateTime.Today, 0, OrderStatus.New));
        }
    }
    
    private void RefreshFilteredClients()
    {
        FilteredClients.Clear();

        foreach (var client in Clients)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredClients.Add(client);
            }
            else if (client.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            {
                FilteredClients.Add(client);
            }
        }
    }
    
    partial void OnSearchTextChanged(string value)
    {
        RefreshFilteredClients();
    }
}