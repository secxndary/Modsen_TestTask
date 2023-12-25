using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace BookLibrary;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Author, AuthorDto>()
            .ForMember
            (
                dest => dest.Name,
                opt => opt.MapFrom(src => string.Join(' ', src.FirstName, src.LastName))
            );
        CreateMap<Genre, GenreDto>();

        CreateMap<BookForCreationDto, Book>();
        CreateMap<AuthorForCreationDto, Author>();
        CreateMap<GenreForCreationDto, Genre>();

        CreateMap<BookForUpdateDto, Book>().ReverseMap();
        CreateMap<AuthorForUpdateDto, Author>().ReverseMap();
        CreateMap<GenreForUpdateDto, Genre>().ReverseMap();
    }
}