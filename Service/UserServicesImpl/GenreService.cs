using AutoMapper;
using Contracts.Repositories;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class GenreService(IRepositoryManager _repository, IMapper _mapper) : IGenreService
{
    public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<GenreDto> GetGenreAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<GenreDto> CreateGenreAsync(GenreForCreationDto genre)
    {
        throw new NotImplementedException();
    }

    public async Task<GenreDto> UpdateGenreAsync(GenreForUpdateDto genre)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteGenreAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}