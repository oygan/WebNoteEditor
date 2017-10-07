using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodNoteEditor.Domain.Entities
{
    /// <summary>
    /// Note model
    /// </summary>
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}
