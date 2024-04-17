using Core.Interfaces;
using Core.Models;

namespace BL.Services
{
    public class CalcService : ICalcService
    {
        public ResultResponce GetResult(decimal? num1,decimal? num2,string operation)
        {
            ResultResponce resultResponce = new ResultResponce();
            switch (operation.ToLower())
            {
                case "add":
                    resultResponce.Result = num1 + num2;
                    break;
                case "subtract":
                    resultResponce.Result = num1 - num2;
                    break;
                case "multiply":
                    resultResponce.Result = num1 * num2;
                    break;
                case "divide":
                    if (num2 == 0)
                    {
                         resultResponce.Message = "Cannot divide by zero";
                    }
                    resultResponce.Result = num1 / num2;
                    break;
                default:
                    resultResponce.Message = "Invalid operation";
                    break;
            }
            return resultResponce;
        }
    }
}
