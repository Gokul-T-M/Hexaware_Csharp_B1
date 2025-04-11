using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.exceptions
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException(string message) : base(message)
        {
            
        }
    }
}
