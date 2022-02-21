using SeriesWeb.Interfaces;
using SeriesWeb.Models;
using System.Linq;

namespace SeriesWeb.Repos
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
		private List<Serie> listaSerie = new List<Serie>();


		public void Atualiza(int id, Serie objeto)
		{
			int index = listaSerie.FindIndex(a => a.Id == id);

			listaSerie[index] = objeto;
		}

		public void Exclui(int id)
		{
			int index = listaSerie.FindIndex(a => a.Id == id);

			listaSerie[index].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			var proximoId = listaSerie.Count;
			if (proximoId == 0)
				return 1;

			return proximoId+1;
		}
		
		public Serie RetornaPorId(int id)
		{
			int index = listaSerie.FindIndex(a => a.Id == id);
			return listaSerie[index];
		}
	}
}
