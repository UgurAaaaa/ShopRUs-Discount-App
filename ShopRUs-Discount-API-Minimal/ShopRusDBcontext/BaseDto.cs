using Microsoft.Extensions.Configuration;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public abstract class BaseDto
    {
        public ShopRUsDBcontext shopRUsDBcontext = new ShopRUsDBcontext();
    }
}
