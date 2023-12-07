using Notes.Database;
using Notes.Models;

namespace Notes.Views;

public partial class editNoteView : ContentPage
{
    private int _id;
    public editNoteView(int id)
    {
        this._id = id;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Note note = await new NotesDatabase().GetItemAsync(_id);
        txtContent.Text = note.Content;
        txtTitle.Text = note.Title;
        btnEditNote.Background = Color.FromArgb(note.Color);
        for (int i = 0; i < Constants.colors.Length; i++)
        {
            if (Constants.colors[i] == note.Color)
            {
                colorPicker.SelectedIndex = i;
                break;
            }
        }
    }
    private async void onEditNoteButtonClicked(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string content = txtContent.Text;
        if (string.IsNullOrEmpty(title)) { await DisplayAlert("Error", "Title can not be null", "ok"); return; }
        if (string.IsNullOrEmpty(content)) { await DisplayAlert("Error", "Content can not be null", "ok"); return; }
        int selectedIndex = colorPicker.SelectedIndex;
        await new NotesDatabase().EditItemAsync(new Note() { 
            Id = _id,
            Title = title,
            Content = content,
            Color = Constants.colors[selectedIndex],
            Date = DateTime.UtcNow.ToString()
        });
        await Navigation.PopAsync();
    }
    private void colorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEditNote.Background = Color.FromArgb(Constants.colors[((Picker)sender).SelectedIndex]);
    }
    private async void OnClickDelete(object sender, EventArgs e)
    {
        await new NotesDatabase().DeleteItemAsync(new Models.Note() { Id = _id });
        await Navigation.PopAsync();
    }
}