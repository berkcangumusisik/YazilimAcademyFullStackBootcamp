// Gerekli kütüphanelerin içe aktarılması
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ChatGPTClone.WasmClient.AuthStateProviders;

// Özel JWT kimlik doğrulama durumu sağlayıcısı sınıfı
public class CustomJwtAuthStateProvider : AuthenticationStateProvider
{
  // Yerel depolama servisi ve HTTP istemcisi için özel alanlar
  private readonly ILocalStorageService _localStorage;
  private readonly HttpClient _httpClient;

  // Yapıcı metod
  public CustomJwtAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
  {
    _localStorage = localStorage;
    _httpClient = httpClient;
  }

  // Kimlik doğrulama durumunu alma metodu
  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    // Yerel depolamadan kullanıcı token'ını alma
    var token = await _localStorage.GetItemAsync<string>("user-token");

    // Token boş veya null ise
    if (string.IsNullOrEmpty(token))
    {
      // Anonim kullanıcı oluşturma
      var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

      // Kimlik doğrulama durumunun değiştiğini bildirme
      NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
      _httpClient.DefaultRequestHeaders.Authorization = null;

      // Anonim kullanıcıyı döndürme
      return new AuthenticationState(anonymousUser);
    }

    // Token'dan talepleri (claims) çözümleme
    var claims = ParseClaimsFromJwt(token);

    // Kimliği doğrulanmış kullanıcı oluşturma
    var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

    // Kimlik doğrulama durumunu oluşturma
    var authState = new AuthenticationState(authenticatedUser);

    // Kimlik doğrulama durumunun değiştiğini bildirme
    NotifyAuthenticationStateChanged(Task.FromResult(authState));

    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    // Kimlik doğrulama durumunu döndürme
    return authState;
  }

  // JWT'den talepleri (claims) çözümleme metodu
  private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
  {
    // JWT'nin payload kısmını alma
    var payload = jwt.Split('.')[1];
    // Base64 kodlamasını çözme
    var jsonBytes = ParseBase64WithoutPadding(payload);
    // JSON'ı sözlüğe dönüştürme
    var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

    // Sözlüğü Claim nesnelerine dönüştürme
    return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
  }

  // Base64 kodlamasını çözme metodu
  private static byte[] ParseBase64WithoutPadding(string base64)
  {
    // Base64 dizesinin uzunluğuna göre padding ekleme
    switch (base64.Length % 4)
    {
      case 2: base64 += "=="; break;
      case 3: base64 += "="; break;
    }
    // Base64 dizesini byte dizisine dönüştürme
    return Convert.FromBase64String(base64);
  }
}
