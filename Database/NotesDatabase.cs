using Notes.Models;
using SQLite;

namespace Notes.Database
{
     class NotesDatabase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Note>();
        }
        public async Task<List<Note>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Note>().ToListAsync();
        }
        public async Task<Note> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Note>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> EditItemAsync(Note item)
        {
            await Init();
            return await Database.UpdateAsync(item);
        }
        public async Task<int> AddItemAsync(Note item)
        {
            await Init();
            return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Note item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async Task<int> GetNoteCount()
        {
            return await Database.Table<Note>().CountAsync();
        } 
    }
}
