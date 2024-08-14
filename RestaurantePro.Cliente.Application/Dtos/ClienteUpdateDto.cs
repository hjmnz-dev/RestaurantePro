namespace RestaurantePro.Cliente.Application.Dtos
{
    public class ClienteUpdateDto 
    {
        public int id { get; set; }

        public DateTime? modify_date { get; set; }

        public int? modify_user { get; set; }

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

    }
}
