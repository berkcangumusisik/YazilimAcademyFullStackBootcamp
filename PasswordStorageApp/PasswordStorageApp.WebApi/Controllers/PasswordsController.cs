using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PasswordStorageApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        [HttpGet] // Veriyi almak istediğimizi belirtiyoruz.
        public IActionResult GetAll()
        {
            var passwords = _passwords;
            return Ok(passwords);
        }

        [HttpGet("{passwordId}")] 
        public IActionResult GetById(string passwordId)
        {
            var password = _passwords.FirstOrDefault(x => x == passwordId);
            if (string.IsNullOrEmpty(password))
            {
                return NotFound();
            }
            return Ok(password);
        }

        [HttpDelete("{passwordId}")]
        public IActionResult Remove(string passwordId)
        {
            var password = _passwords.FirstOrDefault(x => x == passwordId);
            if (string.IsNullOrEmpty(password))
            {
                return NotFound();
            }
            _passwords.Remove(password);
            return NoContent();
        }


        private static readonly List<string> _passwords = new()
        {
            "123456",
            "password",
            "123456789",
            "12345678",
            "12345",
            "1234567",
            "1234567890",
            "qwerty",
            "abc123",
            "111111",
            "123123",
            "admin",
            "letmein",
            "welcome",
            "monkey",
            "password1",
            "1234",
            "password",
            "superman",
            "iloveyou",
            "123456a",
            "trustno1",
            "1234567",
            "sunshine",
            "master",
            "123123",
            "welcome",
            "shadow",
            "ashley",
            "football",
            "jesus",
            "michael",
            "ninja",
            "mustang",
            "password1",
            "p@ssw0rd",
            "hello",
            "charlie",
            "aa123456",
            "donald",
            "password",
            "qazwsx"
        };
    }
    
}

/*
Controller bir hastane resepsiyonu gibi düşünülebilir. Yani gelen istekleri karşılar ve ilgili işlemleri yapar.
GET isteği ile veri alınır.
POST isteği ile veri eklenir.
PUT isteği ile veri güncellenir.
DELETE isteği ile veri silinir.
PATCH isteği ile veri kısmen güncellenir. (Örneğin bir kullanıcının sadece ismi güncellenir.)

IActionResult: Bir işlem sonucunda geriye döndürülecek veriyi belirtir. Örneğin bir metot bir string döndürüyorsa IActionResult yerine string yazılabilir.

HTTPS Kodları: 
200 OK: İstek başarılı bir şekilde gerçekleşti.
201 Created: İstek başarılı bir şekilde gerçekleşti ve yeni bir kaynak oluşturuldu.
204 No Content: İstek başarılı bir şekilde gerçekleşti ancak geriye herhangi bir içerik döndürülmedi.
400 Bad Request: İstek hatalı.
401 Unauthorized: Kullanıcı kimlik doğrulaması gerekiyor.
403 Forbidden: Kullanıcı yetkili değil.
404 Not Found: İstek yapılan kaynak bulunamadı.
405 Method Not Allowed: İstek yapılan metot desteklenmiyor.
409 Conflict: İstek yapılan işlem ile ilgili bir çakışma var.
500 Internal Server Error: Sunucu hatası.


_ : private bir alanı belirtir. Bu alan sadece bu sınıf içerisinde kullanılabilir.

FirstOrDefault: Bir koleksiyon içerisinde belirtilen koşula uyan ilk elemanı getirir. Eğer koşula uyan bir eleman yoksa null döner.
 */
