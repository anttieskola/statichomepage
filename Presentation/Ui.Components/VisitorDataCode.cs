using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PresentationModels.VisitorDataApplication;

namespace Ui.Components
{
    public class VisitorDataCode : ComponentBase, IAsyncDisposable
    {
        [Parameter]
        public bool ShowProgress { get; set; } = false;

        [Parameter]
        public string? QueryString { get; set; } = null;

        [Inject]
        IJSRuntime JS { get; set; } = default!;

        public string ProgressString { get; set; } = "Loading...";

        private Task<IJSObjectReference> _jsLoadingTask = default!;

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            if  (_jsLoadingTask == null)
            {
                _jsLoadingTask = JS.InvokeAsync<IJSObjectReference>("import", $"{Constants.CONTENT_BASE_PATH}/js/visitordata.js").AsTask();
            }
            await base.OnParametersSetAsync();
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its initial
        /// parameters from its parent in the render tree. Override this method if you will
        /// perform an asynchronous operation and want the component to refresh when that
        /// operation is completed.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered.
        ///
        /// Parameters:
        ///   firstRender:
        ///     Set to true if this is the first time Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///     has been invoked on this component instance; otherwise false.
        ///
        /// Remarks:
        ///     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
        ///     lifecycle methods are useful for performing interop, or interacting with values
        ///     received from @ref. Use the firstRender parameter to ensure that initialization
        ///     work is only performed once.
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GatherNavigatorProperties();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// // https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator
        /// </summary>
        /// <returns></returns>
        private async Task GatherNavigatorProperties()
        {
            if (!_jsLoadingTask.IsCompleted)
            {
                await _jsLoadingTask;
            }

            var module = _jsLoadingTask.Result;
            var appCodeName = await module.InvokeAsync<string>("getNavigatorProperty", "appCodeName");
            var appName = await module.InvokeAsync<string>("getNavigatorProperty", "appName");
            var appVersion = await module.InvokeAsync<string>("getNavigatorProperty", "appVersion");
            var platform = await module.InvokeAsync<string>("getNavigatorProperty", "platform");
            var product = await module.InvokeAsync<string>("getNavigatorProperty", "product");
            var productSub = await module.InvokeAsync<string>("getNavigatorProperty", "productSub");
            var userAgent = await module.InvokeAsync<string>("getNavigatorProperty", "userAgent");
            var vendor = await module.InvokeAsync<string>("getNavigatorProperty", "vendor");
            var vendorSub = await module.InvokeAsync<string>("getNavigatorProperty", "vendorSub");
            var language = await module.InvokeAsync<string>("getNavigatorProperty", "language");
            var languages = await module.InvokeAsync<string[]>("getNavigatorProperty", "languages");

            var navigatorProperties = new NavigatorProperties(
                appCodeName,
                appName,
                appVersion,
                platform,
                product,
                productSub,
                userAgent,
                vendor,
                vendorSub,
                language,
                languages);

            ProgressString = JsonSerializer.Serialize(navigatorProperties);
            base.StateHasChanged();
        }


        #region IDisposable
        public async ValueTask DisposeAsync()
        {
            // Perform async cleanup.
            await DisposeAsyncCore();

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            // Suppress finalization.
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (!_jsLoadingTask.IsCompleted)
            {
                _jsLoadingTask.Dispose();
            }
            else
            {
                await _jsLoadingTask.Result.DisposeAsync();
            }

            _jsLoadingTask = default!;
        }
        #endregion
    }
}
