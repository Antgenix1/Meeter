using System;
using System.Collections.ObjectModel;
using Meeter_gibb.Models;

namespace Meeter_gibb;

public partial class Overview : ContentPage
{
    public static ObservableCollection<ListenElement> meineListenElemente;
    public int _index = 0;

    public Overview()
    {
        InitializeComponent();

        meineListenElemente = new ObservableCollection<ListenElement>();

        
        ListenElement a = new()
        {
            Id = DateTime.Today,
            Titel = "Math Exam",
            Beschreibung = "Start studying for the Math Exam"
        };
        meineListenElemente.Add(a);

        ListenElement b = new()
        {
            Id = DateTime.Today,
            Titel = "Project",
            Beschreibung = "Finish my App Project."
        };
        meineListenElemente.Add(b);

        ListenElement c = new()
        {
            Id = DateTime.Today,
            Titel = "Cinema",
            Beschreibung = "Go watch a movie with friends."
        };
        meineListenElemente.Add(c);
        
        meineCollectionView.SetBinding(ItemsView.ItemsSourceProperty, "ListenElement");
        meineCollectionView.ItemsSource = meineListenElemente;
        meineCollectionView.SelectedItem = a;
    }

    private void OnAdd(object sender, EventArgs e)
    {
        ListenElement neu = new ListenElement
        {
            Id = DateTime.Today,
            Titel = "Neues Element",
            Beschreibung = "Beschreibung des neuen Elements."
        };
        meineListenElemente.Add(neu);
    }

    private void OnDelete(object sender, EventArgs e)
    {
        ListenElement le = (ListenElement)meineCollectionView.SelectedItem;
        if (le == null) { return; }
        meineListenElemente.Remove(le);
    }

    private async void OnChange(object sender, EventArgs e)
    {
        ListenElement le = (ListenElement)meineCollectionView.SelectedItem;
        if (le == null) { return; }
        int index = meineListenElemente.IndexOf(le);

        await Navigation.PushAsync(new DetailPage(index));
    }

     private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
     {
         ListenElement le = (ListenElement)meineCollectionView.SelectedItem;
         if (le == null) { return; }
         _index = meineListenElemente.IndexOf(le);
     }
    
}

