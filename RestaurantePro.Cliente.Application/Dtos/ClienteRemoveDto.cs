using RestauranteSol.Common.Data.Base;

namespace RestaurantePro.Cliente.Application.Dtos
{
    public class ClienteRemoveDto 
    {

        public  int id { get; set; }

        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }

        public bool? deleted { get; set; }
    }
}
