using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Task_5.Models;
namespace Task_5.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasSelectedClient))]
    private ClientItem? _selectedClient;

    public bool HasSelectedClient => SelectedClient is not null;

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
}