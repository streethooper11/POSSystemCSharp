using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.Sale.Hardware_Control
{
    public class CashBox : Hardware
    {
        private bool s_isOpen = false;

        public void OpenCashBox()
        {
            if (!s_isOpen)
            {
                s_isOpen = true;
            }
        }

        public void CloseCashBox()
        {
            if (s_isOpen)
            {
                s_isOpen = false;
            }
        }

        protected override void EnableProcedure()
        {
            throw new NotImplementedException();
        }

        protected override void DisableProcedure()
        {
            throw new NotImplementedException();
        }
    }
}
