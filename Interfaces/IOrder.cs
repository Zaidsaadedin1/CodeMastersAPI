using CodeMasters.Dtos.OrdersDtos;

namespace CodeMasters.Interfaces
{
    public interface IOrder
    {
        Task<int> CreateOrder(CreateOrderDto createOrderDto);
        Task<int> UpdateOrder(UpdateOrderDto updateOrderDto, int id);
        Task<int> DeleteOrder(int id);
        Task<GetOrderDto> GetOrderById(int id);
        Task<List<GetOrderDto>> GetAllOrders();
    }
}
