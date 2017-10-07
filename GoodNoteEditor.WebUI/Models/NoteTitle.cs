namespace GoodNoteEditor.WebUI.Models
{
    /// <summary>
    /// Note title view model. Use to reduce traffic.
    /// </summary>
    public class NoteTitle
    {
        /// <summary>
        /// Note Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Note Title.
        /// </summary>
        public string Title { get; set; }
    }
}