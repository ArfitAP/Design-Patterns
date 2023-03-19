namespace Facade
{
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return (customerId > 5);
        }
    }

    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            return (customerId > 8) ? 10 : 20;
        }
    }

    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            switch(DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    public class DoscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

        public double CalculateDiscountPercentage(int customerId) 
        {
            if(!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }
            else
            {
                return _customerDiscountBaseService.CalculateDiscountBase(customerId) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
            }
        }
    }
}
