using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETLab11.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly string logPath;

        public LogActionFilter(string logFilePath)
        {
            this.logPath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string operation = context.ActionDescriptor.DisplayName;
            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string userId = context.HttpContext.Connection.Id.ToString();

            string logMessage = $"{date}: Operation '{operation}' by {userId}.";
            try
            {
                File.AppendAllText(logPath, logMessage + Environment.NewLine);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
