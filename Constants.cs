public static class Constants
{
    public static string[] colors = { "#F6F8FA", "#ff6961", "#829460", "#89cff0", "#ca9bf7", "#e59400" };
    public const string DatabaseFilename = "NotesDatabase.db3";
    public const string userName = "admin";
    public const string passWord = "admin";
    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}