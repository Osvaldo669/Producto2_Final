using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    public interface IAnuncios
    {

        Task<ObservableCollection<AnucioRecibo>> ObtenerAnuncios();
    }
}
