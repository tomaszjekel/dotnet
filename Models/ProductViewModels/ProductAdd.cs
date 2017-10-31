using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace to.mo.Models.ProductViewModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ProductAdd
    {
		public int ID { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string Title { get; set; }

		[Range(1, 5000)]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[StringLength(60, MinimumLength = 3)]
		public string Description { get; set; }

		[StringLength(60, MinimumLength = 3)]
		public string City { get; set; }

		[StringLength(60, MinimumLength = 3)]
		public string Cauntry { get; set; }

		[Phone]
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }

	}
}
