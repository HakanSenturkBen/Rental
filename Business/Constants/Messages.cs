
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = " eklendi";
        public static string NameInvalid = " isim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Listed = "Listeleme tamamlandı";
        public static string NameAlreadyExists = "Bu isimde bir kayıt vardır";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string Deleted = " silindi";
        public static string Updated = " güncellendi";

        public static string UserRegistered = " Kullanıcı kaydı tamamlandı";
        public static string UserNotFound = " kullanıcı bunamadı";
        public static string PasswordError = " hatalı parola";
        public static string SuccessfulLogin = " giriş başarılı";
        public static string UserAlreadyExists = " bu kullanıcı kayıtlı. Parolanızı mı unuttunuz?";
        public static string AccessTokenCreated = " kullanıcı erişimi açıldı";
    }
}
