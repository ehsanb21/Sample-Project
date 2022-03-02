using Microsoft.AspNetCore.Mvc.Filters;

namespace People.WebSite.Filter
{
    public class CustomExpetionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
