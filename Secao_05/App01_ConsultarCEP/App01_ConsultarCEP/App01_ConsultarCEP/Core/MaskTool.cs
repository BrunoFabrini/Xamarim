using System.Linq;

namespace App01_ConsultarCEP.Core
{
    public class MaskTool
    {
        /// <summary>
        /// Remove os caracteres especiais da string fornecida
        /// </summary>
        /// <param name="textToFormat"></param>
        /// <returns>string formatada</returns>
        public static string RemoveMask(string textToFormat)
        {
            string unmaskedText = textToFormat;

            string[] charactersToRemove = new string[] {@"\", @",", @".", @"-", @"/", @";" };
            foreach (string character in charactersToRemove)
                unmaskedText.Replace(character, string.Empty);

            return unmaskedText;
        }

        /// <summary>
        /// Renderiza a máscara fornecida na string fornecida
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="textToFormat"></param>
        /// <returns>string formatada</returns>
        public static string RenderMask(string mask, string textToFormat)
        {
            if (RemoveMask(mask).Length != textToFormat.Length)
                return string.Empty;

            string maskedText = string.Empty;
            int index = 0;

            char[] charactersToRender = new char[] { '\\', ',', '.', '-', '/', ';' };
            foreach(char character in mask)
            {
                if (charactersToRender.Contains(character))
                {
                    maskedText += character;
                    continue;
                }

                maskedText += textToFormat[index];
                index++;
            }

            return maskedText;
        }
    }
}
