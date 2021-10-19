using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class Category
    {    
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set;  }
        public string ProductName { get; set; }
        public string Designation { get; set;}  /// exv MC6S dvs insexskruv, MFX = maskinskruv försänkt för Philips stjärnmejsel
        public string ProductDescription { get; set; }   /// ytbehandling
        public float ProductLength { get; set; }         /// skaftets längd för skruv , höjd för en mutter
        public float ProductDimension  { get; set; }    /// gängstorlek
        public float ProductPrice { get; set; }       
        public Category Category { get; set;}            //// kategori: mutter tum, skruv tum, skruv mm, mutter mm
    }
}
