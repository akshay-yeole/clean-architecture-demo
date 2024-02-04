using application.Exceptions;
using application.Interfaces;
using application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }

        internal class DeleteProductCommandHanlder : IRequestHandler<DeleteProductCommand, ApiResponse<int>>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductCommandHanlder(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ApiResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                if (product == null)
                {
                    throw new ApiExceptions("Product Not Found");

                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return new ApiResponse<int>(product.Id, "Product deleted Successfully");
            }
        }
    }
}