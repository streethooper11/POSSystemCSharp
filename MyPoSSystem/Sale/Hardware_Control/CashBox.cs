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
        private static bool IsOpen = false;

        public static void OpenCashBox()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        public static void CloseCashBox()
        {
            if (IsOpen)
            {
                IsOpen = false;
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
