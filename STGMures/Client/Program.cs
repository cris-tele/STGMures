
using StgMures.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using MudBlazor.Services;

namespace StgMures.Client
{
    public static class ActionState
    {
        public const int Read = 0;
        public const int Add = 1;   // Create
        public const int Edit = 2;   // Update
        public const int Delete = 3;
    };

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();    // login si register
            builder.Services.AddScoped<ISetAppMenuInfos, SetAppMenuInfos>();
            //categories
            builder.Services.AddScoped<ITreatmentCategoryService, TreatmentCategoryService>();
            builder.Services.AddScoped<IDiagnosticCategoryService, DiagnosticCategoryService>();
            builder.Services.AddScoped<IConsumableCategoryService, ConsumableCategoryService>();
            builder.Services.AddScoped<ISurgicalProcedureService, SurgicalProcedureService>();
            builder.Services.AddScoped<IConsumableCategoryService, ConsumableCategoryService>();
            
            //types
            builder.Services.AddScoped<IDiagnosticTypeService, DiagnosticTypeService>();
            builder.Services.AddScoped<ISurgeryTypeService, SurgeryTypeService>();
            builder.Services.AddScoped<ITreatmentTypeService, TreatmentTypeService>();
            builder.Services.AddScoped<IConsumableTypeService, ConsumableTypeService>();

            // action pages
            builder.Services.AddScoped<IPatientListService, PatientListService>();
            builder.Services.AddScoped<IPatientFileService, PatientFileService>();
            builder.Services.AddScoped<IPatientAssocDiseaseService, PatientAssocDiseaseService>();
            builder.Services.AddScoped<IPatientSurgeryService, PatientSurgeryService>();
            

            await builder.Build().RunAsync();
        }
    }
}

