using System.ComponentModel.DataAnnotations;

namespace CozaStore.ViewModels.Account;

public class LoginVM
{
    [Display(Name = "Email ou Nome de Usuário", Prompt ="Informe seu Email ou Nome de usuario")]
    [Required(ErrorMessage = "Por Favor, informe seu email ou nome de usuario")]
    public string Email { get; set; }    

    [Display(Name ="Senha de acesso", Prompt ="************")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }  

    [Display(Name = "Manter Conectado?")]
    public bool Lembrar { get; set; }    
    public string UrlRetorno { get; set; }    
}
