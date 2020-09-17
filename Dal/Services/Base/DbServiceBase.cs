using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using Dal.Interfaces.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Interfaces;

namespace Dal.Services.Base
{
    public class DbServiceBase<TEntity, TModel, TSaveModel, TId> : IDbServiceBase<TModel, TSaveModel, TId>
        where TModel : class, IHaveAnId<TId>
        where TEntity : class, IHaveAnId<TId>
        where TSaveModel : IHaveAnId<TId>
    {
        private readonly IContextFactory _contextFactory;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DbServiceBase(IContextFactory contextFactory, ILogger logger, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _logger = logger;
            _mapper = mapper;
        }


        public virtual async Task<TModel> Save(TSaveModel model)
        {
            await using var context = _contextFactory.CreateContext();

            var entity = await CreateOrUpdate(model, context);
            await context.SaveChangesAsync();


            return await Queryable.Where(GetEntityQueryable(context), x => x.Id.Equals(entity.Id))
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .SingleAsync();
        }

        protected async Task<TEntity> CreateOrUpdate(TSaveModel model, DbContext context)
        {
            var entity = await Queryable.Where(GetEntityQueryable(context), x => x.Id.Equals(model.Id)).SingleOrDefaultAsync();

            if (entity == null)
            {
                entity = _mapper.Map<TEntity>(model);
                context.Set<TEntity>().Add(entity);
                return entity;
            }

            entity = _mapper.Map(model, entity);
            return context.Set<TEntity>().Update(entity).Entity;
        }


        public virtual async Task<TModel> Delete(TId id)
        {
            await using var context = _contextFactory.CreateContext();

            var entity = await Queryable.Where(GetEntityQueryable(context), x => x.Id.Equals(id)).SingleOrDefaultAsync();
            context.Set<TEntity>().Remove(entity);

            var model = _mapper.Map<TModel>(entity);
            await context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TModel> Get(TId id)
        {
            await using var context = _contextFactory.CreateContext();

            return await Queryable.Where(GetEntityQueryable(context), x => x.Id.Equals(id))
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<TModel>> Get(Expression<Func<TModel, bool>> filter)
        {
            await using var context = _contextFactory.CreateContext();

            return await Task.Run(() => Queryable.Where(GetEntityQueryable(context)
                    .UseAsDataSource(_mapper.ConfigurationProvider)
                    .For<TModel>(), filter)
                .ToList());
        }

        public virtual async Task<IReadOnlyList<TModel>> GetAll()
        {
            await using var context = _contextFactory.CreateContext();

            return await Queryable.Where(GetEntityQueryable(context), x => true)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        protected virtual IQueryable<TEntity> GetEntityQueryable(DbContext context)
        {
            return context.Set<TEntity>();
        }
    }
}