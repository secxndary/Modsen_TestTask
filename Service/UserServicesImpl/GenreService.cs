using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class GenreService(IRepositoryManager repository, IMapper mapper) : IGenreService
{
    public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
    {
        var genres = await repository.Genre.GetAllGenresAsync(trackChanges: false);
        var genresDto = mapper.Map<IEnumerable<GenreDto>>(genres);
        return genresDto;
    }

    public async Task<GenreDto> GetGenreAsync(Guid id)
    {
        var genre = await GetGenreAndCheckIfItExists(id, trackChanges: false);
        var genreDto = mapper.Map<GenreDto>(genre);
        return genreDto;
    }

    public async Task<GenreDto> CreateGenreAsync(GenreForCreationDto genre)
    {
        var genreEntity = mapper.Map<Genre>(genre);

        repository.Genre.CreateGenre(genreEntity);
        await repository.SaveAsync();

        var genreToReturn = mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }

    public async Task<GenreDto> UpdateGenreAsync(Guid id, GenreForUpdateDto genreForUpdate)
    {
        var genreEntity = GetGenreAndCheckIfItExists(id, trackChanges: true);

        await mapper.Map(genreForUpdate, genreEntity);
        await repository.SaveAsync();

        var genreToReturn = mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }

    public async Task DeleteGenreAsync(Guid id)
    {
        var genre = await GetGenreAndCheckIfItExists(id, trackChanges: false);
        repository.Genre.DeleteGenre(genre);
        await repository.SaveAsync();
    }
    
    
    private async Task<Genre> GetGenreAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var genre = await repository.Genre.GetGenreAsync(id, trackChanges);
        if (genre is null)
            throw new GenreNotFoundException(id);
        return genre;
    }
}