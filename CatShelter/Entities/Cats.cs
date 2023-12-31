//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CatShelter.Entities
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public partial class Cats
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cats()
        {
            this.Applications = new HashSet<Applications>();
        }
    
        public int CatID { get; set; }
        public string CatName { get; set; }
        public decimal Age { get; set; }
        public System.DateTime ReceiptDate { get; set; }
        public int Color { get; set; }
        public int Breed { get; set; }
        public int Character { get; set; }
        public int Gender { get; set; }
        public byte[] Image { get; set; }
        public byte[] CorrectImage
        {
            get
            {
                if (Image == null)
                    return File.ReadAllBytes("../../Resources/cat.png");
                else return Image;
            }
        }
        public string TextCharacter
        {
            get
            {
                return Characters.CharacterName.ToString();
            }
        }
        public string TextBreed
        {
            get
            {
                return Breeds.BreedName.ToString();
            }
        }
        public string TextColor
        {
            get
            {
                return Colors.ColorName.ToString();
            }
        }
        public string TextGender
        {
            get
            {
                return Genders.GenderName.ToString();
            }
        }
        public string AdminVisibility
        {
            get
            {
                if (App.CurrentUser == null)
                    return "Hidden";
                else if (App.CurrentUser.Role == 2)
                    return "Hidden";
                else return "Visible";
            }
        }
        public string UserVisibility
        {
            get
            {
                if (App.CurrentUser == null || App.CurrentUser.Role == 1)
                    return "Hidden";
                else return "Visible";
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }
        public virtual Breeds Breeds { get; set; }
        public virtual Characters Characters { get; set; }
        public virtual Colors Colors { get; set; }
        public virtual Genders Genders { get; set; }
    }
}
