using Membership_Management_UI.Data;
using Membership_Management_UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Features;
using Tewr.Blazor.FileReader;

namespace Membership_Management_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddHttpClient<IMemberService, MemberService>(s =>
            {
                s.BaseAddress = new Uri(@"https://localhost:44349/");
            });

            builder.Services.AddHttpClient<IDocumentService, DocumentService>(s =>
            {
                s.BaseAddress = new Uri(@"https://localhost:44349/");
            });

            builder.Services.AddHttpClient<IFeeCollectionService, FeeCollectionService>(s =>
            {
                s.BaseAddress = new Uri(@"https://localhost:44349/");
            });

            builder.Services.AddHttpClient<IPackageService, PackageService>(s =>
            {
                s.BaseAddress = new Uri(@"https://localhost:44349/");
            });

            builder.Services.AddHttpClient<IMemberPackageService, MemberPackageService>(s =>
            {
                s.BaseAddress = new Uri(@"https://localhost:44349/");
            });



            builder.Services.AddFileReaderService();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
