using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;

namespace CRM.Application.Services.Implementations
{
    public class SearchService : ISearchService

    {
        private readonly ISearchRepository repository;

        public SearchService(ISearchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GlobalSearchResults> GlobalSearch(string phrase, Guid userId)
        {
            var search = await repository.GlobalSearch(phrase, userId);

            return search;

        }
    }
}
