using Microsoft.AspNetCore.Mvc;

namespace DrillingSupportWebApi.ExceptionsHandling
{
    public class ControllerExceptions
    {
        public static IActionResult Failure()
        {
            throw new Exception("Failed");
        }
    }
}
