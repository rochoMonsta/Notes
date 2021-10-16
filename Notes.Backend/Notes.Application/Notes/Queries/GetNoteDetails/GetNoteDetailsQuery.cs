using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailVm>
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }
    }
}
