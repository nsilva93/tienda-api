using System.Text.Json.Serialization;

namespace TiendaApp.API.Models.Carrito
{
    public class AddToCartRequest
    {
        [JsonPropertyName("articuloId")]
        public int ArticuloId { get; set; }
    }
}
