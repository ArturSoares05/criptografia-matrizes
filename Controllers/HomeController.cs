using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Criptografia.Controllers
{
    public class HomeController : Controller
    {
        private static readonly int[,] chave =
{
    { 1, 2, 3 },
    { 0, 1, 4 },
    { 0, 0, 1 }
};

        private static readonly int[,] chaveInversa =
        {
    { 1, 254, 5 },
    { 0, 1, 252 },
    { 0, 0, 1 }
};

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criptografar(string texto)
        {
            var resultado = ProcessarTexto(texto, chave);
            ViewBag.Resultado = resultado;
            ViewBag.Texto = texto;
            return View("Index");
        }

        [HttpPost]
        public IActionResult Descriptografar(string texto)
        {
            var resultado = ProcessarTexto(texto, chaveInversa);
            ViewBag.Resultado = resultado;
            ViewBag.Texto = texto;
            return View("Index");
        }

        // ===== PIPELINE =====

        static string ProcessarTexto(string texto, int[,] matriz)
        {
            var blocos = TextoParaBlocos(texto);
            var resultado = new List<char>();

            foreach (var bloco in blocos)
            {
                var transformado = MultiplicarMod256(bloco, matriz);
                resultado.AddRange(MatrizParaTexto(transformado));
            }

            return new string(resultado.ToArray());
        }

        // ===== TEXTO → MATRIZ =====

        static List<int[,]> TextoParaBlocos(string texto)
        {
            var lista = new List<int[,]>();
            int total = (int)System.Math.Ceiling(texto.Length / 9.0);

            for (int b = 0; b < total; b++)
            {
                int[,] m = new int[3, 3];

                for (int i = 0; i < 9; i++)
                {
                    int idx = b * 9 + i;
                    m[i / 3, i % 3] = idx < texto.Length ? (byte)texto[idx] : (byte)' ';
                }

                lista.Add(m);
            }

            return lista;
        }

        // ===== MATRIZ → TEXTO =====

        static IEnumerable<char> MatrizParaTexto(int[,] m)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    yield return (char)m[i, j];
        }

        // ===== MULTIPLICAÇÃO MOD 256 =====

        static int[,] MultiplicarMod256(int[,] a, int[,] b)
        {
            int[,] r = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int soma = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        soma += a[i, k] * b[k, j];
                    }

                    r[i, j] = ((soma % 256) + 256) % 256;
                }
            }

            return r;
        }
    }
}