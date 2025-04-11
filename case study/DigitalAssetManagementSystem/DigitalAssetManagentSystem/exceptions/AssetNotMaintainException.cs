using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.exceptions
{
    public class AssetNotMaintainException : Exception
    {
        public AssetNotMaintainException(string message) : base(message)
        {
            
        }
    }
}
