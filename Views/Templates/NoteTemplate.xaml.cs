using Notes.Database;
using Notes.Views;

namespace Notes.Views.Templates;

public partial class NoteTemplate : ContentView
{
	public NoteTemplate()
	{
		InitializeComponent();
	}
    private void OnClickEdit(object sender, EventArgs e)
    {
        string classId = btnEdit.ClassId;
        int id = int.Parse(classId);
        Navigation.PushAsync(new editNoteView(id));
    }
}