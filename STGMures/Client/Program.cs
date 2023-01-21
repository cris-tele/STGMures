
using StgMures.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using MudBlazor.Services;
using StgMures.Client.Services.Categories;

namespace StgMures.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IAuthService, AuthService>();    // login si register

            builder.Services.AddScoped<ITreatmentCategoryService, TreatmentCategoryService>();
            builder.Services.AddScoped<IDiagnosticCategoryService, DiagnosticCategoryService>();
            builder.Services.AddScoped<IConsumableCategoryService, ConsumableCategoryService>();
            builder.Services.AddScoped<ISurgicalProcedureCategoryService, SurgicalProcedureCategoryService>();

            builder.Services.AddScoped<IPatientListService, PatientListService>();


            await builder.Build().RunAsync();
        }
    }
}

