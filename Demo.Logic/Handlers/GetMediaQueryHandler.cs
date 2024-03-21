using Demo.Logic.Models.Entities;
using Demo.Logic.Queries;
using Demo.Logic.Repositories;
using Demo.Logic.Seedwork.Cqrs.QueryHandlers;
using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Handlers
{
    public class GetMediaQueryHandler : BaseQueryHandler<GetMediaQuery, IEnumerable<Media>>
    {
        private readonly IMediaRepository _repository;

        public GetMediaQueryHandler(IMediaRepository queueRepository)
        {
            _repository = queueRepository;
        }

        protected override async Task<IEnumerable<Media>> HandleInvoke(HttpContext context, GetMediaQuery query)
        {
            var media = query.SearchCriteria != null
                ? await _repository.GetMediaAsync(query.SearchCriteria)
                : await _repository.GetMediaAsync();

            return media;
        }
    }
}
