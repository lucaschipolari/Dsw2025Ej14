using Dsw2025J14.Api.Dominio;
using Dsw2025J14.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Dsw2025J14.Api.Data
{
    public class PersistenciaEnMemoria : IPersistenciaEnMemoria
    {
        private List<Product> _products = [];

        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        public Product GetProduct(string sku)
        {
            var product = _products.FirstOrDefault(p => p.Sku == sku);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.Where(p => p.IsActive);
        }

        private void LoadProducts()
        {
            var json = File.ReadAllText("../../products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];

        }
    }

}
