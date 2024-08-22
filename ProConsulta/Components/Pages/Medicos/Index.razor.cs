using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
	public class IndexMedicoPage : ComponentBase
	{
		[Inject]
		public IMedicoRepository Repository { get; set; } = null!;

		[Inject]
		public IDialogService DialogService { get; set; } = null!;

		[Inject]
		public NavigationManager Navigation { get; set; } = null!;

		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;

		public List<Medico> Medicos { get; set; } = new();

		public async Task DeleteMedicoAsync(Medico medico)
		{
			try
			{
				var result = await DialogService.ShowMessageBox
				(
					"Atenção",
					$"Deseja excluir o médico {medico.Nome}?",
					yesText: "SIM",
					cancelText: "NÃO"
				);

				if (result is true)
				{
					await Repository.DeleteByIdAsync(medico.Id);
					Snackbar.Add("Médico excluído com sucesso!", Severity.Success);
					await OnInitializedAsync();
				}
			}
			catch (Exception ex)
			{
				Snackbar.Add(ex.Message, Severity.Error);
			}
		}

        public bool HideButtons { get; set; }

		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationState { get; set; }

        public void GoToUpdate(int id)
			=> Navigation.NavigateTo($"/medicos/update/{id}");

		protected override async Task OnInitializedAsync()
		{
			var auth = await AuthenticationState;

			HideButtons = !auth.User.IsInRole("Atendente");

            Medicos = await Repository.GetAllAsync();
		}
	}
}
