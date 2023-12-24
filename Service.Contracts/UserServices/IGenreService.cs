using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Service.Contracts.UserServices;

public interface IGenreService
{
    Task<IEnumerable<GenreDto>> GetAllGenresAsync();   // TODO add GenreParameters
    Task<GenreDto> GetGenreAsync(Guid id);
    Task<GenreDto> CreateGenreAsync(GenreForCreationDto genre);
    Task<GenreDto> UpdateGenreAsync(GenreForUpdateDto genre);
    Task DeleteGenreAsync(Guid id);
}