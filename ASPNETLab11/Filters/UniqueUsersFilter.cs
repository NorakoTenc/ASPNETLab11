using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETLab11.Filters
{
    public class UniqueUsersFilter : IAuthorizationFilter
    {
        private readonly string logPath;
        private HashSet<string> uniqueUsers = new HashSet<string>();
        public UniqueUsersFilter(string logPath)
        {
            this.logPath = logPath;
            try
            {
                if (File.Exists(this.logPath))
                {
                    string[] lines = File.ReadAllLines(logPath);

                    foreach (string line in lines)
                    {
                        uniqueUsers.Add(line.Replace("userId: ",""));
                    }
                }
                else
                {
                    File.Create(this.logPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userId = context.HttpContext.Connection.Id.ToString();
            if (!uniqueUsers.Contains(userId))
            {
                uniqueUsers.Add(userId);

                File.AppendAllText(logPath,$"userId: {userId}" + Environment.NewLine);
            }
        }
    }
}
