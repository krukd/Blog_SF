﻿using API.Data.Models.Request.Tags;
using API.Data.Models.Response.Tags;

namespace API.Contracts.Services.IServices
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync(string? searchQuery = null,
            string? sortBy = null,
            string? sortDirection = null,
            int pageNumber = 1, int pageSize = 100);

        Task<Tag?> GetAsync(Guid id);

        Task<Tag> AddAsync(TagCreateRequest request);

        Task<Tag?> UpdateAsync(TagEditRequest request);

        Task<Tag?> DeleteAsync(Guid id);

        Task<int> CountAsync();
    }
}
