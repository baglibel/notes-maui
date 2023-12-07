using Notes.Models;
using Notes.Database;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Notes.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshNotes();
    }
    private void OnAddNote(object sender, EventArgs e)
    {
        Navigation.PushAsync(new addNoteView());
    }
    private async void RefreshNotes()
    {
        List<Note> eskiList = await new NotesDatabase().GetItemsAsync();
        List<NoteTemporary> list = new();
        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
        foreach (Note note in eskiList)
        {
            DateTime date = DateTime.Parse(note.Date);
            string dateS = $"{date.Day} {mfi.GetMonthName(date.Month)} {date.ToShortTimeString()}";
            list.Add(new NoteTemporary() { 
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                Color = Color.FromArgb(note.Color),
                Date = dateS
            });
        }
        collectionView.ItemsSource = new ObservableCollection<NoteTemporary>(list);
    }
    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Set("logged_in", false);
        App.Current.MainPage = new LoginView();
    }
}