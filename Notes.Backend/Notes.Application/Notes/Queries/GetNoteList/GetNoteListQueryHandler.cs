using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbContext;

        public GetNoteListQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
