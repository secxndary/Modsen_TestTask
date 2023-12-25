using AutoMapper;
using Contracts.Repositories;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public class GenreService(IRepositoryManager _repository, IMapper _mapper) : IGenreService
{
    public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
    {
        var genres = await _repository.Genre.GetAllGenresAsync(trackChanges: false);
        var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);
        return genresDto;
    }

    public async Task<GenreDto> GetGenreAsync(Guid id)
    {
        var genre = await GetGenreAndCheckIfItExists(id, trackChanges: false);
        var genreDto = _mapper.Map<GenreDto>(genre);
        return genreDto;
    }

    public async Task<GenreDto> CreateGenreAsync(GenreForCreationDto genre)
    {
        var genreEntity = _mapper.Map<Genre>(genre);

        _repository.Genre.CreateGenre(genreEntity);
        await _repository.SaveAsync();

        var genreToReturn = _mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }

    public async Task<GenreDto> UpdateGenreAsync(Guid id, GenreForUpdateDto genreForUpdate)
    {
        var genreEntity = GetGenreAndCheckIfItExists(id, trackChanges: true);

        await _mapper.Map(genreForUpdate, genreEntity);
        await _repository.SaveAsync();

        var genreToReturn = _mapper.Map<GenreDto>(genreEntity);
        return genreToReturn;
    }

    public async Task DeleteGenreAsync(Guid id)
    {
        var genre = await GetGenreAndCheckIfItExists(id, trackChanges: false);
        _repository.Genre.DeleteGenre(genre);
        await _repository.SaveAsync();
    }
    
    
    private async Task<Genre> GetGenreAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var genre = await _repository.Genre.GetGenreAsync(id, trackChanges);
        if (genre is null)
            throw new GenreNotFoundException(id);
        return genre;
    }
}