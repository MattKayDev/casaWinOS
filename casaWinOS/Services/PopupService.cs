using Microsoft.JSInterop;

namespace casaWinOS.Services
{
    public class PopupService
    {
        private readonly IJSRuntime jsRuntime;

        public PopupService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<bool> ConfirmDeleteApp(string appName)
        {
            return await this.jsRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {appName}");
        }

        public async Task<bool> DisplayError(string message)
        {
            return await this.jsRuntime.InvokeAsync<bool>("confirm",message);
        }

        public async Task<bool> ShowMessage(string message)
        {
            return await this.jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}