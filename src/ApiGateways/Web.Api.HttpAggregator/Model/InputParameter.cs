using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Model
{
   
    public class ApiInputModel //: IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ip address or domain is required.")]
        public string Address { get; set; }

        public List<string> Services { get; set; }
    }
}
