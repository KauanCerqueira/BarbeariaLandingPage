using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace BarbeariaLandingPage.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        [Required(ErrorMessage = "Por favor, insira seu nome.")]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Por favor, insira seu email.")]
        [EmailAddress(ErrorMessage = "Digite um email v�lido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Por favor, insira seu telefone.")]
        [Phone(ErrorMessage = "Digite um n�mero de telefone v�lido.")]
        [Display(Name = "Telefone / WhatsApp")]
        public string Telefone { get; set; }

        public string MensagemStatus { get; set; }

        public void OnGet()
        {
            // P�gina carregada - pode adicionar l�gica inicial se necess�rio
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                MensagemStatus = "Por favor, preencha todos os campos corretamente.";
                return Page();
            }

            // Aqui voc� pode salvar os dados em um banco ou enviar por email.
            _logger.LogInformation("Novo agendamento recebido:");
            _logger.LogInformation($"Nome: {Nome}");
            _logger.LogInformation($"Email: {Email}");
            _logger.LogInformation($"Telefone: {Telefone}");

            TempData["AgendamentoSucesso"] = "Agendamento realizado com sucesso! Em breve entraremos em contato.";
            return RedirectToPage("/ThankYou");
        }
    }
}
