using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace niyw.cotroller.AgentPools
{
    public interface IPoolAppService :
    ICrudAppService< //Defines CRUD methods
        PoolDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdatePoolDto> //Used to create/update a book
    {

    }
}
