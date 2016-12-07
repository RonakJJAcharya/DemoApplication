using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DemoApplication.Services.Interface;
using DemoApplication.Services.Service;
using DemoApplication.Core.Interface;
using DemoApplication.Core.Repository;

namespace DemoApplication.DependencyResolution
{
    public class DemoAppNinjectDependecyResolver: NinjectModule
    {
        public override void Load()
        {
            Bind<IIncomeCalculationService>().To<IncomeCalculationService>();
            Bind<IIncomeCalculationRepository>().To<EfIncomeCalculationRepository>();            
        }
    }
}
