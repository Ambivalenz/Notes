using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;
using Xunit;

namespace Notes.Tests.Notes.Queries;

[Collection("QueryCollection")]
public class GetNoteDetailsQueryHandlerTests
{
    private readonly NotesDbContext Context;
    private readonly IMapper Mapper;

    public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetNoteDetailsQueryHandler_Success()
    {
        // Arrange
        var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

        // Act
        var result = await handler.Handle(
            new GetNoteDetailsQuery
            {
                UserId = NotesContextFactory.UserBId,
                Id = Guid.Parse("255D2B7B-423C-424F-945D-289F07938C9E")
            },
            CancellationToken.None);

        // Assert
        result.ShouldBeOfType<NoteDetailsVm>();
        result.Title.ShouldBe("Title2");
        result.CreationDate.ShouldBe(DateTime.Today);
    }
}