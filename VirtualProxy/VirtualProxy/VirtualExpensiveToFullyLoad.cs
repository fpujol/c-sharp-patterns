using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualProxy
{
    public class VirtualExpensiveToFullyLoad : ExpensiveToFullyLoad
    {
        public override IEnumerable<ExpensiveEntity> AwayEntities
        {
            get
            {
                if (base.AwayEntities == null)
                {
                    Trace.WriteLine("Entrem aqui!");
                    base.AwayEntities = ExpensiveDataSource.GetEntities(this);
                }
                return base.AwayEntities;
            }
            protected set => base.AwayEntities = value;
        }

        public override IEnumerable<ExpensiveEntity> HomeEntities
        {
            get
            {
                if (base.HomeEntities == null)
                {
                    base.HomeEntities = ExpensiveDataSource.GetEntities(this);
                }
                return base.HomeEntities;
            }
            protected set => base.HomeEntities = value;
        }
    }
}
