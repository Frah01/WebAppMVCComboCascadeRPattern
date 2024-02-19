using CLCommon.Models;
using CLCommon.Repository;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLBuisnessLayer
{

    internal class ComuneService
    {
        //public readonly IRepositoryAsync<TRegione> _regioneRepAsync;
        //public readonly IRepositoryAsync<TProvincium> _provinciaRepAsync;
        public readonly IRepositoryAsync<TComune> _comuneRepAsync;
        
        public  ComuneService(IRepositoryAsync<TComune> comuneRepAsync)
        {
            _comuneRepAsync = comuneRepAsync;
        }
    }
}
