using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace Service.Contracts.UserServices;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();   // TODO add BookParameters
    Task<BookDto> GetBookAsync(Guid id);
    Task<BookDto> CreateBookAsync(BookForCreationDto book);
    Task<BookDto> UpdateBookAsync(Guid id, BookForUpdateDto bookForUpdate);
    Task DeleteBookAsync(Guid id);
}