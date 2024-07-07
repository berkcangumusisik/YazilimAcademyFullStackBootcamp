using BG.BlazorWasmStarter;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


/*
 * Blazor Web Assembly Standelone React, Angular, Vue gibi client-side frameworkler gibi �al���r.
 * wwwroot : Bu klas�rde uygulaman�n statik dosyalar� bulunur. Bu dosyalar, uygulaman�n �al��t��� sunucu �zerinde do�rudan eri�ilebilir. Public klas�r�ne benzer �ekilde, bu dosyalar�n uygulaman�n k�k dizininden eri�ilebilir olmas� gerekir.
 * Program.cs : Bu dosya, uygulaman�n giri� noktas�d�r. Uygulaman�n yap�land�r�lmas�n� ve �al��t�r�lmas�n� sa�lar.
 * Pages : Bu klas�rde, uygulaman�n sayfalar� bulunur. Sayfalar, uygulaman�n URL'sine kar��l�k gelen bile�enlerdir. Sayfalar, Razor bile�enleri olarak tan�mlan�r ve .razor uzant�s�na sahiptir.
 * Layouts : Bu klas�rde, uygulaman�n d�zenleri bulunur. D�zenler, uygulaman�n sayfalar�n�n nas�l g�r�nece�ini belirler. D�zenler, Razor bile�enleri olarak tan�mlan�r ve .razor uzant�s�na sahiptir.
 * Component bir lego par�as� gibi d���n�lebilir. Bir componenti ba�ka bir component i�erisinde kullanabiliriz. Sayfalar�m�z� tek bir component yerine birden fazla component ile olu�turabiliriz. Bu sayede kod tekrar�n� �nlemi� oluruz. Mesela Twitter'da Navbar, post button, timeline gibi componentler bir araya gelerek bir sayfa olu�turur.
 *
 * Projeyi Nas�l �al��t�r�r�z?
 * �nce proje dizinine gitmemiz gerekiyor. Ard�ndan terminal ekran�na dotnet watch run yazarak projeyi �al��t�rabiliriz.
 * dotnet watch run : Uygulamay� �al��t�r�r ve de�i�iklikleri izler. Bir de�i�iklik alg�land���nda, uygulamay� yeniden derler ve �al��t�r�r. Bu, uygulaman�n geli�tirme s�recinde kullan��l�d�r.
 * Sayfa de�i�ti�i zaman sadece de�i�en k�sm� y�kler. Bu sayede sayfa ge�i�leri daha h�zl� olur.
 *

 */