using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secundNumber}")]
        public IActionResult Get(string firstnumber, string secundNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secundNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstnumber}/{secundNumber}")]
        public IActionResult GetSub(string firstnumber, string secundNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secundNumber))
            {
                var sub = ConvertToDecimal(firstnumber) - ConvertToDecimal(secundNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstnumber}/{secundNumber}")]
        public IActionResult GetDiv(string firstnumber, string secundNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secundNumber))
            {
                if (IsDivisivel(secundNumber))
                {
                    var div = ConvertToDecimal(firstnumber) / ConvertToDecimal(secundNumber);

                    return Ok(div.ToString());
                }
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstnumber}/{secundNumber}")]
        public IActionResult GetMult(string firstnumber, string secundNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secundNumber))
            {
                var media = (ConvertToDecimal(firstnumber) + ConvertToDecimal(secundNumber)) / 2;

                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsDivisivel(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(
                 strNumber,
                 System.Globalization.NumberStyles.Any,
                 System.Globalization.NumberFormatInfo.InvariantInfo,
                 out number);

            if (isNumber && number == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsNumeric(string strNumber)
        {

            double number;

            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return (int)decimalValue;
            }

            return 0;
        }


    }
}
