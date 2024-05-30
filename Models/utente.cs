using System.ComponentModel.DataAnnotations;

public class Utente{
    public string? UserName {get;set;}
    
    [Required]
    [DataType(DataType.Password)]
    public string? UserPassword {get;set;}
}