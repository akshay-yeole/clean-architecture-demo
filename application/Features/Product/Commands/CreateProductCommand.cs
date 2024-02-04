using application.Interfaces;
using application.Wrappers;
using AutoMapper;
using MediatR;

namespace application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<ApiResponse<int>>
    {
        public string Name { get; set; }         
        public string Desription { get; set; }
        public decimal Rate { get; set; }

        internal class CreateProductCommandHanlder : IRequestHandler<CreateProductCommand, ApiResponse<int>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHanlder(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product =_mapper.Map<Domain.Entities.Product>(request);

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                
                return new ApiResponse<int>(product.Id, "Product created Successfully");
            }
        }
    }
}
