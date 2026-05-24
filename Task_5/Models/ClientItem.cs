using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task_5.Models;

public partial class ClientItem : ObservableObject
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _phone = string.Empty;
    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private bool _isVip;

    public ObservableCollection<OrderItem> Orders { get; }

    public ClientItem(string name, string phone, string email, bool isVip, IEnumerable<OrderItem>? orders = null)
    {
        Name = name;
        Phone = phone;
        Email = email;
        IsVip = isVip;

        Orders = orders is null
            ? new ObservableCollection<OrderItem>()
            : new ObservableCollection<OrderItem>(orders);
    }
}