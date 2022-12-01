using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWin.Domain.Entity.BaseEntity;

namespace WinWin.Domain.Entity.User
{
    public class Users : BaseEntities
    {
        [Required]
        [StringLength(150)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(150)]
        public string? PassWord { get; set; }
        public string? DisplayName { get; set; }
        public DateTime LastDateLogin  { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
