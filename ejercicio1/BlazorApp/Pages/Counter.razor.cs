using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Counter : ComponentBase
    {

        private int currentCount = 0;
        [Parameter] public int step { get; set; }
        [Parameter] public EventCallback<int> Onclick { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? parametrosExtra { get; set; }

        protected override void OnInitialized()
        {
            if (step < 1) step = 1;
        }

        private void IncrementCount()
        {

            currentCount = currentCount + step;
        }
        private void onDivClic()
        {
            if (Onclick.HasDelegate)
                Onclick.InvokeAsync(currentCount);
        }

    }
}
