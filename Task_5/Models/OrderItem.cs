using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Task_5.Models;

public enum OrderStatus
{
    New,
    Paid,
    Cancelled
}

public partial class OrderItem : ObservableObject
{
    [ObservableProperty] private int _number;
    [ObservableProperty] private DateTime _date;
    [ObservableProperty] private int _amount;
    [ObservableProperty] private OrderStatus _status;

    public OrderItem(int? number, DateTime? date, int? amount, OrderStatus? status)
    {
        Number = number ?? 0;
        Date = date ?? DateTime.Today;
        Amount = amount ?? 0;
        Status = status ?? OrderStatus.New;
    }
}