using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Servico.Modelo
{
    public class Endereco
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Unidade { get; set; }

        public string Ibge { get; set; }

        public string Gia { get; set; }

        /// <summary>
        /// Retorna true se todas as propriedades forem nulas
        /// </summary>
        public bool NotPopulated
        {
            get
            {
                return string.IsNullOrEmpty(Cep)
                    && string.IsNullOrEmpty(Logradouro)
                    && string.IsNullOrEmpty(Complemento)
                    && string.IsNullOrEmpty(Bairro)
                    && string.IsNullOrEmpty(Localidade)
                    && string.IsNullOrEmpty(Uf)
                    && string.IsNullOrEmpty(Unidade)
                    && string.IsNullOrEmpty(Ibge)
                    && string.IsNullOrEmpty(Gia);
            }
        }
    }
}
