using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATproj.Controllers
{
    [Route("api/ussd")]
    [ApiController]
    public class AmountController : ControllerBase
    {

        // GET: api/<AmountController>
        [HttpPost]
        public String PostAmount()
        {
            String sessionId = Request.Form["sessionId"];
            String serviceCode = Request.Form["serviceCode"];
            String phoneNumber = Request.Form["phoneNumber"];
            String text = Request.Form["text"];

            string responseString = null;

            if (string.IsNullOrEmpty(text))
            {
                // This is the first request. Note how we start the response with CON

                responseString = "CON What would you like to check\n1. My account\n2. My phone number";

            }
            else if (text.Equals("1"))
            {
                // Business logic for first level response

                responseString = "CON Choose account information you want to view\n1. Account number";

            }
            else if (text.Equals("2"))
            {
                // Business logic for first level response

                // This is a terminal request. Note how we start the response with END
                responseString = $"END Your phone number is {phoneNumber}";
               

            }
            else if (text.Equals("1*1"))
            {
                // This is a second level response where the user selected 1 in the first instance

                String accountNumber = "ACC100101";
                responseString = $"END Your account number is {accountNumber}"; // This is a terminal request. Note how we start the response with END               

            }
            return responseString;

        }

        
    }
}
