using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Hardware
{
    public abstract class Hardware
    {
        protected bool _isEnabled;

        public void Enable()
        {
            if (!_isEnabled)
            {
                _isEnabled = true;
                EnableProcedure();
            }
        }

        public void Disable()
        {
            if (_isEnabled)
            {
                _isEnabled = false;
                DisableProcedure();
            }
        }

        protected abstract void EnableProcedure();
        protected abstract void DisableProcedure();
    }
}
