using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "op/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string op, string firstNumber, string secondNumber)
        {
            
            if (op.Equals("soma"))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }
            if (op.Equals("sub"))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }
            if (op.Equals("div"))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }
            if (op.Equals("mult"))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }

            if (op.Equals("media"))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                    return Ok(sum.ToString());
                }
            }

            if (op.Equals("raiz"))
            {
                if (IsNumeric(firstNumber))
                {
                    var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                    return Ok(sum.ToString());
                }
            }
            return BadRequest("Invalid Input");
        }




        private bool IsNumeric(string strNumber)
        {
            double number;
            bool IsNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return IsNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        
    }
}