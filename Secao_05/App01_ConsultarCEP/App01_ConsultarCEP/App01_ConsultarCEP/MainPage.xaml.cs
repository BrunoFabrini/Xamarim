using App01_ConsultarCEP.Core;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BuscarButton.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            ResultadoLabel.Text = string.Empty;

            string cep = MaskTool.RemoveMask(CepEntry.Text);

            //Validar CEP inserido
            if (string.IsNullOrEmpty(cep) || cep.Length != 8 || !int.TryParse(cep, out int cepInt))
            {
                DisplayAlert("Alerta", "CEP informado é inválido!", "OK");
                return;
            }

            CepEntry.Text = MaskTool.RenderMask("#####-###", cep);

            //Busca CEP na internet
            Result result = ViaCEPService.BuscarEnderecoCep(cep, out Endereco endereco);
            if (!result.Sucess)
            {
                DisplayAlert("Erro", $"Ocorreu um erro na transação. Detalhes:\n{result.Message}", "OK");
                return;
            }

            //Exibe CEP na tela
            ResultadoLabel.Text = $"Cidade: {endereco.Localidade}\n" +
                $"UF: {endereco.Uf}\n" +
                $"Bairro: {endereco.Bairro}\n" +
                $"Rua: {endereco.Logradouro}\n" +
                $"Complemento: {endereco.Complemento}\n";
        }
    }
}
