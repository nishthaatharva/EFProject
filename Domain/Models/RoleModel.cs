using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }
    }
}
