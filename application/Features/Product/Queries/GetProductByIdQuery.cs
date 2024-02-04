using application.Exceptions;
using application.Interfaces;
using application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace application.Features.Product.Queries
{
    public class GetProductByIdQuery : IRequest<ApiResponse<Domain.Entities.Product>>
    {
        public int Id { get; set; }
        internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<Domain.Entities.Product>>
        {
            private readonly IApplicationDbContext _dbContext;
            public GetProductByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ApiResponse<Domain.Entities.Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Products.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();
                if (result == null) {
                    throw new ApiExceptions("Product Not Found");
                }
                return new ApiResponse<Domain.Entities.Product>(result, "Data Fecthed Successfully");
            }
        }
    }

}
