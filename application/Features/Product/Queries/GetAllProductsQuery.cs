using application.Interfaces;
using application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<ApiResponse<IEnumerable<Domain.Entities.Product>>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<IEnumerable<Domain.Entities.Product>>>
        {
            private readonly IApplicationDbContext _dbContext;
            public GetAllProductsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ApiResponse<IEnumerable<Domain.Entities.Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Products.ToListAsync(cancellationToken);
                return new ApiResponse<IEnumerable<Domain.Entities.Product>>(result,"Data Fetched Successfully");
            }
        }
    }

}
