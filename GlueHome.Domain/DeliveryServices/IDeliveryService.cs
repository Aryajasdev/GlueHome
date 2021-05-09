using GlueHome.Model.Delivery;
using GlueHome.Model.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlueHome.Domain.DeliveryServices
{
    public interface IDeliveryService
    {
        Task<List<DeliveryView>> GetDeliveries();

        Task<DeliveryView> GetDelivery(int id);

        Task InsertDelivery(Delivery delivery);

        Task<Delivery> UpdateDelivery(int id, DeliveryStatus deliveryStatus);      
    }
}