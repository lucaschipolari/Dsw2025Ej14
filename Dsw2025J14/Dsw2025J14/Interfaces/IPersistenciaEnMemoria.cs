using Dsw2025J14.Api.Dominio;

namespace Dsw2025J14.Api.Interfaces
{
    public interface IPersistenciaEnMemoria
    {
        Product GetProduct(string sku);
        IEnumerable<Product> GetProducts();
    }
}