using AutoMapper;
using Contracts.Repositories;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Services.UserServicesImpl;

public sealed class BookService(IRepositoryManager _repository, IMapper _mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<BookDto> GetBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDto> CreateBookAsync(BookForCreationDto book)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDto> UpdateBookAsync(BookForUpdateDto book)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}