using BlazorApp.Moldels;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Services
{
    public class ProductsService
    {
        public ProductsService(HttpClient httpClient, IJSRuntime js)
        {
            HttpClient = httpClient;
            this.js = js;
        }

        public HttpClient HttpClient { get; }
        private readonly IJSRuntime js;
        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            //List<ProductDTO> datos = await js.GetFromLocalStorageAsync<List<ProductDTO>>("productos");
            List<ProductDTO> datos = await loadFromStorageAsync();



            if (datos == null || datos.Count == 0)
            {
                string url = "https://fakestoreapi.com/products";
                        var result = await HttpClient.GetFromJsonAsync<List<ProductDTO>>(url);



                if (result != null)
                {
                    datos = result;
                    await saveToStorageAsync(datos);
                    //js.SetInLocalStorageAsync("productos", datos);
                }
                else
                    datos = new List<ProductDTO>();
            }



            return datos;
        }


        private async Task<List<ProductDTO>> loadFromStorageAsync()
        {
            await Task.CompletedTask;
            var result = await js.InvokeAsync<string>("window.localStorage.getItem", "productos");
            if (!string.IsNullOrEmpty(result))
            {
                var datos = System.Text.Json.JsonSerializer.Deserialize<List<ProductDTO>>(result);
                return datos;
            }



            return null;
        }



        private async Task saveToStorageAsync(List<ProductDTO> datos)
        {
            await Task.CompletedTask;
            await js.InvokeVoidAsync(
            "eval",
      $@"window.sessionStorage.setItem('productos','{System.Text.Json.JsonSerializer.Serialize<List<ProductDTO>>(datos)}')"
            );
        }


    }
}
