using System;
namespace YelpApiServer.Services.IServices
{
	public interface IBaseRestService
	{
        Task<T> GetAsync<T>(string resource, int cacheDuration);

    }
}

