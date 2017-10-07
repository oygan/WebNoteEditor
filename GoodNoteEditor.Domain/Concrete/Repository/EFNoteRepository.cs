using System.Collections.Generic;
using System.Data.Entity;
using GoodNoteEditor.Domain.Abstract;
using GoodNoteEditor.Domain.Entities;

namespace GoodNoteEditor.Domain.Concrete.Repository
{
    /// <summary>
    /// This EF implementation of <see cref="INoteRepository"/> 
    /// </summary>
    public class EFNoteRepository : INoteRepository
    {
        /// <summary>
        /// EF context
        /// </summary>
        private readonly EFDbContext _context;

        public EFNoteRepository()
        {
            _context = new EFDbContext();
        }

        /// <summary>
        /// Notes
        /// </summary>
        public IEnumerable<Note> Notes
        {
            get { return _context.Notes; }
        }

        /// <summary>
        /// Add or update note.
        /// </summary>
        /// <param name="note">Note.</param>
        public void UpdateNote(Note note)
        {
            Note dbEntry = _context.Notes.Find(note.NoteId);
            if (dbEntry != null)
            {
                dbEntry.Text = note.Text;
                dbEntry.Title = note.Title;
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a note if it is founded
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public Note DeleteProduct(int noteId)
        {
            Note dbEntry = _context.Notes.Find(noteId);
            if (dbEntry != null)
            {
                _context.Notes.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        /// <summary>
        /// Add note
        /// </summary>
        /// <param name="note">note</param>
        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }
    }
}
