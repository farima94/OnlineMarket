using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Application.Categories.Commands;

public class DeleteCategoryCommand : IRequest<string>
{
    public int CategoryId { get; set;}
}

public  class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =await _context.Categories.Where(w=>w.Id==request.CategoryId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (category==null)
        {
            throw new NotFoundException("Category Not found");
        }

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync(cancellationToken);

        return "Category deleted";
    }
}