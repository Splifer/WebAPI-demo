using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_demo.Models.Entity;

[Table("Account")]
public partial class Account
{
    [Key]
    [Column("user_id")]
    [StringLength(30)]
    public string UserId { get; set; } = null!;

    [Column("gender_name")]
    [StringLength(100)]
    public string GenderName { get; set; } = null!;

    [Column("role_name")]
    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    [Column("user_name")]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [Column("login_id")]
    [Unicode(false)]
    public string LoginId { get; set; } = null!;

    [Column("password")]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("birth_date", TypeName = "date")]
    public DateTime? BirthDate { get; set; }

    [Column("mail_address")]
    [StringLength(30)]
    public string MailAddress { get; set; } = null!;

    [Column("tel_no")]
    public int TelNo { get; set; }

    [Column("address")]
    public string Address { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("GenderName")]
    [InverseProperty("Accounts")]
    public virtual Gender GenderNameNavigation { get; set; } = null!;

    [ForeignKey("RoleName")]
    [InverseProperty("Accounts")]
    public virtual Role RoleNameNavigation { get; set; } = null!;
}
