using System;

namespace EruMobileScooter.Data{

    public class User : BaseEntity, IEquatable<User> {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; } //TODO: Password Sifrelenmeli
        public string Identity { get; set; }    // Türkiye Cumhuriyeti kimlik Numarası
        public Gender Gender { get; set; }  // Cinsiyet
        public string Email { get; set; }   // Öğrenci veya Öğretmen mail adresi. 1031320314@erciyes.edu.tr
        public string Phone { get; set; }
        public string Faculty { get; set; } // Mensup oldugu Fakülte. Mühendislik Fakültesi
        public string Department { get; set; }  // Fakülte Bölümü. Enerji Sistemleri Mühendisligi
        public Role Role { get; set; }    // Öğretmen veya Öğrenci
        public bool isBanned { get; set; }  // Kullanıcının banlanıp banlanmadıgı 

        public bool Equals(User other)
        {
            return  this.Name == other.Name &&
                    this.Surname == other.Surname &&
                    this.Password == other.Password &&
                    this.Identity == other.Identity &&
                    this.Gender == other.Gender &&
                    this.Email == other.Email &&
                    this.Phone == other.Phone &&
                    this.Faculty == other.Faculty &&
                    this.Department == other.Department &&
                    this.Role == other.Role &&
                    this.isBanned == other.isBanned;
        }
    }


    public enum Gender {
        NONE = 0,   // Tanımlanmamıs
        MALE = 1,   // erkek
        FEMALE = 2, // kadın
        UNISEX = 3, // Eşcinsel
        DONT_WANT_TO = 4 // Belirtmek İstemiyorum
    }
    public enum Role {
        NONE = 0,
        TECHNICIAN = 1,
        TEACHER = 2,
        STUDENT = 3
    }
}