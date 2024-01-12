using Newtonsoft.Json;
using RESTfulReference.Dominio.Geral.Entidades;
using RESTfulReference.Dominio.Geral.Repositorios;
using System.Security.Cryptography;
using System.Text;

namespace RESTfulReference.Aplicacao.Geral
{
    public class ServicoComparadorEntidade<T> where T : EntidadeAbstrata
    {
        private readonly IRepositorioGeral<T> repositorio;

        public bool HouveMudanca(EntidadeAbstrata entidade)
        {
            var entidadeAntes = this.repositorio.Consultar(entidade.Id);
            if (entidadeAntes == null) return true;

            var hashEntidadeAntes = GerarHashEntidade(entidadeAntes);
            var hashEntidadeDepois = GerarHashEntidade(entidade);

            return hashEntidadeAntes != hashEntidadeDepois;
        }

        private static string GerarHashEntidade(EntidadeAbstrata entidade)
        {
            if (entidade == null) return "";

            var json = JsonConvert.SerializeObject(entidade);
            return Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(json)));
        }
    }
}
