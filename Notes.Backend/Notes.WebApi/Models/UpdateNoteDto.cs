using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Models;

public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
{
    private Guid Id { get; set; }
    private string? Title { get; set; }
    private string? Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Id,
                opt => opt.MapFrom(noteDto => noteDto.Id))
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}