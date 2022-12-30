using System.Collections.Specialized;
using System.ComponentModel;
using Meeter_gibb.Models;

namespace Meeter_gibb;

public partial class DetailPage : ContentPage
{
    int _index = 0;
    public DetailPage(int index)
    {
        InitializeComponent();
        _index = index;

        ListenElement le = Overview.meineListenElemente[_index];

        Entry_Id.Date = le.Id;
        Entry_Beschreibung.Text = le.Beschreibung.ToString();
        Entry_Titel.Text = le.Titel.ToString();
    }


    private async void OnSave(object sender, EventArgs e)
    {
        Overview.meineListenElemente[_index].Id = Convert.ToDateTime(Entry_Id.Date);
        Overview.meineListenElemente[_index].Beschreibung = Entry_Beschreibung.Text;
        Overview.meineListenElemente[_index].Titel = Entry_Titel.Text;

        await Navigation.PopAsync();
    }
}