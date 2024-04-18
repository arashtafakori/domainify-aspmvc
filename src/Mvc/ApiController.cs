using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;

namespace Domainify.AspMvc
{
    /// <summary>
    /// Base abstract class for API controllers, extending the functionality of the standard MVC Controller.
    /// </summary>
    public abstract class ApiController : Controller
    {
        /// <summary>
        /// Deserializes the query string parameters into an object of type TRequest.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request object to be deserialized.</typeparam>
        /// <returns>An instance of TRequest populated with values from the query string.</returns>
        [NonAction]
        public TRequest GetRequest<TRequest>()
        {
            var dict = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.ToString());
            string json = JsonConvert.SerializeObject(dict.Cast<string>()
                .ToDictionary(k => k, v => dict[v]));
            return JsonConvert.DeserializeObject<TRequest>(json)!;
        }
    }
}
