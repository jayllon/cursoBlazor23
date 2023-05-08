
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UCLM.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {

        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js,
            DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }

        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("console.log", "example message");
            return await js.InvokeAsync<bool>("confirm", message);
        }

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>(
             "localStorage.setItem",
             key, content
             );

        public static void SetInLocalStorage<T>(this IJSRuntime js, string key, T content)
        {
            string json = JsonSerializer.Serialize(content);
            var r = js.InvokeAsync<object>("localStorage.setItem", key, json);
        }

        public async static void SetInLocalStorageAsync<T>(this IJSRuntime js, string key, T content)
        {
            string json = JsonSerializer.Serialize(content);
            var r = await js.InvokeAsync<object>("localStorage.setItem", key, json);
        }

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "localStorage.getItem",
                key
                );

        public static T GetFromLocalStorage<T>(this IJSRuntime js, string key)
        {
            T result = default(T);
            var json = js.InvokeAsync<string>("localStorage.getItem", key).Result;
            if (String.IsNullOrEmpty(json))
                return result;
            else
                return JsonSerializer.Deserialize<T>(json);
        }

        public async static ValueTask<T> GetFromLocalStorageAsync<T>(this IJSRuntime js, string key)
        {
            T result = default(T);
            var json = await js.InvokeAsync<string>("localStorage.getItem", key);
            if (String.IsNullOrEmpty(json))
                return result;
            else
                return JsonSerializer.Deserialize<T>(json);
        }

        public static ValueTask<object> RemoveItemFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "localStorage.removeItem",
                key);

        public static ValueTask<object> SetInSessionStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>(
                "sessionStorage.setItem",
                key, content
                );

        public async static void SetInSessionStorage<T>(this IJSRuntime js, string key, T content)
        {
            string json = JsonSerializer.Serialize(content);
            var r = await js.InvokeAsync<object>("sessionStorage.setItem", key, json);
        }

        public async static void SetInSessionStorageAsync<T>(this IJSRuntime js, string key, T content)
        {
            string json = JsonSerializer.Serialize(content);
            var r = await js.InvokeAsync<object>("sessionStorage.setItem", key, json);
        }

        public static ValueTask<string> GetFromSessionStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "sessionStorage.getItem",
                key
                );

        public static T GetFromSessionStorage<T>(this IJSRuntime js, string key)
        {
            T result = default(T);
            var json = js.InvokeAsync<string>("sessionStorage.getItem", key).Result;
            if (String.IsNullOrEmpty(json))
                return result;
            else
                return JsonSerializer.Deserialize<T>(json);
        }

        public async static ValueTask<T> GetFromSessionStorageAsync<T>(this IJSRuntime js, string key)
        {
            T result = default(T);
            var json = await js.InvokeAsync<string>("sessionStorage.getItem", key);
            if (String.IsNullOrEmpty(json))
                return result;
            else
                return JsonSerializer.Deserialize<T>(json);
        }

        public static ValueTask<object> RemoveItemFromSessionStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "sessionStorage.removeItem",
                key);

        public static void DownloadFile(this IJSRuntime js, string filename, string contentType, string base64Content)
        {
            js.InvokeVoidAsync("BlazorDownloadFile",
                        filename,
                        contentType,
                        base64Content
                        );
        }

    }
}
