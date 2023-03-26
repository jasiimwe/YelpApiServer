using System;
namespace YelpApiServer.Core.Models
{
	public class ApiResponse<T>
	{
		public T Data { get; set; }
		public string Message { get; set; }
		public bool check { get; set; }


		public ApiResponse(T entity, string message)
		{
			check = true;
			Message = message;
			Data = entity;
		}

		public ApiResponse(string message)
		{
			check = false;
			Message = message;
			Data = default;
				
		}
	}
}

