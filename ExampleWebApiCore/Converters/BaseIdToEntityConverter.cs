using AutoMapper;
using ExampleWebApiCore.Models.General;
using ExampleWebApiCore.Services.Interfaces;
using ExampleWebApiCore.Views.General;

namespace ExampleWebApiCore.Converters
{
    public class BaseIdToEntityConverter<TEntity> : ITypeConverter<BaseId, TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryService<TEntity> _repositoryService;

        public BaseIdToEntityConverter(IRepositoryService<TEntity> repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public TEntity Convert(BaseId source, TEntity destination, ResolutionContext context)
        {
            return _repositoryService.Find(source.Id);
        }
    }
}