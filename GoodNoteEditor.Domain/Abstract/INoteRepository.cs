using System.Collections.Generic;
using GoodNoteEditor.Domain.Entities;

namespace GoodNoteEditor.Domain.Abstract
{
    /// <summary>
    /// CRUD methods for note domain model
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// All Notes.
        /// </summary>
        IEnumerable<Note> Notes { get; }

        /// <summary>
        /// Save note
        /// </summary>
        /// <param name="note">note</param>
        void UpdateNote(Note note);

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>deleted note (founded by id). May be null.</returns>
        Note DeleteProduct(int noteId);

        /// <summary>
        /// Add note
        /// </summary>
        /// <param name="note">note</param>
        void AddNote(Note note);
    }
}
