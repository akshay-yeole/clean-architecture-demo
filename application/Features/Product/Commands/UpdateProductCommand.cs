using application.Exceptions;
using application.Interfaces;
using application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace application.Features.Product.Commands
{
    public class UpdateProductCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        public decimal Rate { get; set; }

        internal class UpdateProductCommandHanlder : IRequestHandler<UpdateProductCommand, ApiResponse<int>>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHanlder(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ApiResponse<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                if (product == null)
                {
                    throw new ApiExceptions("Product Not Found");
                }

                product.Name = request.Name;
                product.Desription = request.Desription;
                product.Rate = request.Rate;
                await _context.SaveChangesAsync();
                return new ApiResponse<int>(product.Id, "Product created Successfully");
            }
        }
    }
}
