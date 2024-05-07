using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoligBlik.MVC.Models;

public class CreateMemberViewModel : PageModel
{
    public string MemberId { get; set;}
    public string MemberName { get; set;}
    public string MemberLastName { get; set;}
    public string MemberRole { get; set;}
    public DateTime DateCreate { get; set; } = DateTime.Now;
}