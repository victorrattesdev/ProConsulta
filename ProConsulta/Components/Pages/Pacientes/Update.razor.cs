using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class UpdatePaciente : ComponentBase
    {
        [Parameter]
        public int PacienteId { get; set; }

        [Inject]
        public IPacienteRepository repository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public PacienteInputModel InputModel { get; set; } = new();
        private Paciente? CurrentPaciente { get; set; }
        public DateTime? DataNascimento { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentPaciente = await repository.GetByIdAsync(PacienteId);

            if (CurrentPaciente is null)
                return;

            InputModel = new PacienteInputModel
            {
                Id = CurrentPaciente.Id,
                Nome = CurrentPaciente.Nome,
                Celular = CurrentPaciente.Celular,
                DataNascimento = CurrentPaciente.DataNascimento,
                Email = CurrentPaciente.Email,
                Documento = CurrentPaciente.Documento,
            };

            DataNascimento = CurrentPaciente.DataNascimento;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(editContext.Model is PacienteInputModel model)
                {
                    CurrentPaciente.Nome = model.Nome;
                    CurrentPaciente.Documento = model.Documento.SomenteCaracteres();
                    CurrentPaciente.Celular = model.Celular.SomenteCaracteres();
                    CurrentPaciente.Email = model.Email;
                    CurrentPaciente.DataNascimento = DataNascimento.Value;

                    await repository.UpdateAsync(CurrentPaciente);

                    Snackbar.Add($"Paciente {CurrentPaciente.Nome} atualizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

    }
}
