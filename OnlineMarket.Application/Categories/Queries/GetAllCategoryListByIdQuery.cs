using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Application.Common.Dto.Categories;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Application.Categories.Queries;

public class GetAllCategoryListByIdQuery : IRequest<CategoryDto>
{
    public int CategoryId { get; set; }


}

public class GetAllCategoryListByIdHndler : IRequestHandler<GetAllCategoryListByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryListByIdHndler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<CategoryDto> Handle(GetAllCategoryListByIdQuery request, CancellationToken cancellationToken=default)
    {
        var queryable = await _context.Categories.Where(w=>w.Id==request.CategoryId)
            .AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (queryable == null)
        {
            throw new NotFoundException("category not found");
        }
        
        var result = new CategoryDto()
        {
            CategoryId = queryable.Id,
            ImageUrl = queryable.ImageUrl,
            Name = queryable.Name,
            Description = queryable.Description

        };

        return result;
    }
}
