using Core.Models;

namespace Core.Interfaces
{
    public interface ICalcService
    {
        public ResultResponce GetResult(decimal? num1, decimal? num2, string operation);
    }
}
