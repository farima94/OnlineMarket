using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Application.Common.Dto.Categories;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Application.Categories.Queries;

public class GetAllCategoryListQuery : IRequest<List<CategoryDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAllCategoryListHandler : IRequestHandler<GetAllCategoryListQuery, List<CategoryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoryListQuery request, CancellationToken cancellationToken=default)
    {
        var queryable = _context.Categories.AsQueryable();

        var list = await queryable
            .OrderBy(o => o.Id)
            .Skip((request.PageNumber-1) * request.PageSize)
            .Take(request.PageSize)
            .Select(s => new CategoryDto()
            {
                CategoryId = s.Id,
                ImageUrl = s.ImageUrl,
                Description = s.Description,
                Name = s.Name
            }).ToListAsync(cancellationToken);

        return list;
    }
}