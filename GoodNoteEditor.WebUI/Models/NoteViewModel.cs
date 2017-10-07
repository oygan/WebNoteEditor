using System;

namespace GoodNoteEditor.WebUI.Models
{
    /// <summary>
    /// Note View Model.
    /// </summary>
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsEdit { get; set; }
        public DateTime CreateDate { get; set; }
    }
}