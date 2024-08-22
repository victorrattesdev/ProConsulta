using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class CreateAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

        [Inject]
        private IMedicoRepository MedicoRepository { get; set; } = null!;

        [Inject]
        private IPacienteRepository PacienteRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        public AgendamentoInputModel InputModel { get; set; } = new();
        public List<Medico> Medicos { get; set; } = new();
        public List<Paciente> Pacientes { get; set; } = new();

        public TimeSpan? time = new TimeSpan(09, 00, 00);
        public DateTime? date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento 
                    {
                        Observacao = model.Observacao,
                        PacienteId = model.PacienteId,
                        MedicoId = model.MedicoId,
                        HoraConsulta = time!.Value,
                        DataConsulta = date!.Value
                    };

                    await AgendamentoRepository.AddAsync(agendamento);
                    Snackbar.Add("Agendamento realizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/agendamentos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();
        }
    }
}
