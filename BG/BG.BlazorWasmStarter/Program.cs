using BG.BlazorWasmStarter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


/*
 * Blazor Web Assembly Standelone React, Angular, Vue gibi client-side frameworkler gibi çalýþýr.
 * wwwroot : Bu klasörde uygulamanýn statik dosyalarý bulunur. Bu dosyalar, uygulamanýn çalýþtýðý sunucu üzerinde doðrudan eriþilebilir. Public klasörüne benzer þekilde, bu dosyalarýn uygulamanýn kök dizininden eriþilebilir olmasý gerekir.
 * Program.cs : Bu dosya, uygulamanýn giriþ noktasýdýr. Uygulamanýn yapýlandýrýlmasýný ve çalýþtýrýlmasýný saðlar.
 * Pages : Bu klasörde, uygulamanýn sayfalarý bulunur. Sayfalar, uygulamanýn URL'sine karþýlýk gelen bileþenlerdir. Sayfalar, Razor bileþenleri olarak tanýmlanýr ve .razor uzantýsýna sahiptir.
 * Layouts : Bu klasörde, uygulamanýn düzenleri bulunur. Düzenler, uygulamanýn sayfalarýnýn nasýl görüneceðini belirler. Düzenler, Razor bileþenleri olarak tanýmlanýr ve .razor uzantýsýna sahiptir.
 * Component bir lego parçasý gibi düþünülebilir. Bir componenti baþka bir component içerisinde kullanabiliriz. Sayfalarýmýzý tek bir component yerine birden fazla component ile oluþturabiliriz. Bu sayede kod tekrarýný önlemiþ oluruz. Mesela Twitter'da Navbar, post button, timeline gibi componentler bir araya gelerek bir sayfa oluþturur.
 *
 * Projeyi Nasýl Çalýþtýrýrýz?
 * Önce proje dizinine gitmemiz gerekiyor. Ardýndan terminal ekranýna dotnet watch run yazarak projeyi çalýþtýrabiliriz.
 * dotnet watch run : Uygulamayý çalýþtýrýr ve deðiþiklikleri izler. Bir deðiþiklik algýlandýðýnda, uygulamayý yeniden derler ve çalýþtýrýr. Bu, uygulamanýn geliþtirme sürecinde kullanýþlýdýr.
 * Sayfa deðiþtiði zaman sadece deðiþen kýsmý yükler. Bu sayede sayfa geçiþleri daha hýzlý olur.
 *

 */