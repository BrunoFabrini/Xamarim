using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using App01_ConsultarCEP.Core;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPService
    {
        private static string Url = @"https://viacep.com.br/ws/{0}/json";

        /// <summary>
        /// Busca o endereço do CEP fornecido na API ViaCEP
        /// </summary>
        /// <param name="cep">Cep consultado</param>
        /// <param name="endereco">Enderço obtido na consulta</param>
        /// <returns>Objeto Result com resultado da operação</returns>
        public static Result BuscarEnderecoCep(string cep, out Endereco endereco)
        {
            Result result = new Result();
            endereco = null;

            try
            {
                string urlConsultaCep = string.Format(Url, cep);

                WebClient webClient = new WebClient();

                string resposta = webClient.DownloadString(urlConsultaCep);

                endereco = JsonConvert.DeserializeObject<Endereco>(resposta);

                if (endereco.NotPopulated)
                    return new Result($"Falha ao consultar. Endereço não encontrado para o CEP {MaskTool.RenderMask("#####-###", cep)}.");
            }
            catch (Exception ex)
            {
                result = new Result(ex);
            }

            return result;
        }
    }
}
