using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonControllerr : ControllerBase
    {


        private readonly ILogger<PersonControllerr> _logger;

        public PersonControllerr(ILogger<PersonControllerr> logger)
        {
            _logger = logger;
        }
        #region GET

        [HttpGet("sum/{firstnumber}/{secundNumber}")]
        public IActionResult Get(string firstnumber, string secundNumber)
        {

            return BadRequest("Invalid Input");
        }

        

        #endregion

        #region POST

        #endregion
        #region PUT

        #endregion

        #region DELETE

        #endregion

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
