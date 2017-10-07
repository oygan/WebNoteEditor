using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GoodNoteEditor.Domain.Abstract;
using GoodNoteEditor.Domain.Entities;
using GoodNoteEditor.WebUI.Models;

namespace GoodNoteEditor.WebUI.Controllers
{
    /// <summary>
    /// Notes web api controller
    /// </summary>
    public class NoteController : ApiController
    {
        const string TitlePlaceholder = "Enter title";
        const string TextPlaceholder = "Enter text";

        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/Note
        public IEnumerable<NoteTitle> Get()
        {
            var list = _noteRepository.Notes.Select(MakeNoteTitle).ToList();
            return list;
        }

        // GET: api/Note/5
        public NoteViewModel Get(int id)
        {
            if (id < -1)
                throw new ArgumentException($"Invalid note id {id} in {nameof(NoteController)}.{nameof(Get)}");

            Note entityNote = null;
            // Load by id
            if (id > 0)
                entityNote = _noteRepository.Notes.FirstOrDefault(t => t.NoteId == id);

            // Load last node
            if (id == -1)
            {
                entityNote = _noteRepository.Notes.LastOrDefault();
            }

            // for 0 or enemy id 
            if (entityNote == null)
            {
                // Create empty and save to starge
                entityNote = new Note()
                {
                    NoteId = id,
                    Title = TitlePlaceholder,
                    Text = TextPlaceholder,
                    UpdateDate = DateTime.Now,
                };
                _noteRepository.AddNote(entityNote);
            }

            // convert to view model
            NoteViewModel viewNote = MakeViewNote(entityNote);
            return viewNote;
        }

        // POST: api/Note
        public void Post(NoteViewModel value)
        {
            if (value == null)
                throw new ArgumentNullException($"Null note in {nameof(NoteController)}.{nameof(Post)}");

            // convert to entity model
            Note entity = new Note()
            {
                NoteId = value.Id,
                Title = value.Title,
                Text = value.Text,
                UpdateDate = DateTime.Now
            };

            // replace invalid data
            if (string.IsNullOrEmpty(entity.Title))
                entity.Title = TitlePlaceholder;
            if (string.IsNullOrEmpty(entity.Text))
                entity.Title = TextPlaceholder;

            _noteRepository.UpdateNote(entity);
        }

        // DELETE: api/Note/5
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Invalid note id {id} in {nameof(NoteController)}.{nameof(Delete)}");
            _noteRepository.DeleteProduct(id);
        }

        private static NoteViewModel MakeViewNote(Note entityNote)
        {
            return new NoteViewModel()
            {
                Id = entityNote.NoteId,
                Title = entityNote.Title,
                Text = entityNote.Text,
                CreateDate = entityNote.UpdateDate,
                IsEdit = true

            };
        }

        private NoteTitle MakeNoteTitle(Note arg)
        {
            return new NoteTitle()
            {
                Id = arg.NoteId,
                Title = arg.Title
            };
        }
    }
}
