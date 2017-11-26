using EmercomDisp.BLL.Dependencies;
using EmercomDisp.Data.Dependencies;
using StructureMap;

namespace EmercomDisp.Composition
{
    public class CompositionRegistry : Registry
    {
        public CompositionRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(BLLRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}
