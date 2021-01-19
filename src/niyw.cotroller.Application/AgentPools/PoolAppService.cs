using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace niyw.cotroller.AgentPools
{
    public class PoolAppService :
        CrudAppService<
            Pool, //The Book entity
            PoolDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdatePoolDto>, //Used to create/update a book
        IPoolAppService //implement the IBookAppService
    {
        public PoolAppService(IRepository<Pool, int> repository)
            : base(repository)
        {

        }
    }
}
