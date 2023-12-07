using Microsoft.Maui.Controls;
using Notes.Database;
using Notes.Models;

namespace Notes.Views;

public partial class addNoteView : ContentPage
{
    public addNoteView()
	{
		InitializeComponent();
		colorPicker.SelectedIndex = 0;
	}
	private async void onAddNoteButtonClicked(object sender, EventArgs e)
	{
		string title = txtTitle.Text;
		string content = txtContent.Text;
        if (string.IsNullOrEmpty(title) ) { await DisplayAlert("Error", "Title can not be null","ok"); return; }
        if (string.IsNullOrEmpty(content) ) { await DisplayAlert("Error", "Content can not be null","ok"); return; }
        int selectedIndex = colorPicker.SelectedIndex;
		Note note = new() {
			Id = new Random().Next(0,2119999999),
			Title = title,
			Content = content,
			Color = Constants.colors[selectedIndex],
			Date = DateTime.UtcNow.ToString()
		};
		await new NotesDatabase().AddItemAsync(note);
		await Navigation.PopAsync();
    }
    private void colorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		btnAddNote.Background = Color.FromArgb(Constants.colors[((Picker)sender).SelectedIndex]);
    }
}