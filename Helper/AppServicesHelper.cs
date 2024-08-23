using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Helper
{

	public static class AppServicesHelper
	{


		static IServiceProvider services = null;

		public static IServiceProvider Service
		{
			get
			{
				return services;
			}
			set
			{
				if (services != null)
				{
					throw new Exception("Cant set a value once a value is set");
				}
				services = value;
			}

		}


		public static HttpContext HttpContext_Current
		{
			get
			{
				IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
				return httpContextAccessor?.HttpContext;
			}
		}

		public static IHostingEnvironment HostingEnvironment
		{
			get
			{
				return services.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
			}
		}

	}
}