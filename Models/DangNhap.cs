using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3Last.Models
{
    [Table("dangnhap")]
    public class DangNhap
    {
        [Key]
        [StringLength(30)]
        public string username { get; set; }
        [StringLength(20)]
        public string matkhau { get; set; }
        [StringLength(10)]
        public string chucvu { get; set; }
        public DangNhap() { }
        public DangNhap(string Username, string Matkhau, string Chucvu)
        {
            this.username = Username;
            this.matkhau = Matkhau;
            this.chucvu = Chucvu;
        }
    }
}