using MyPoSSystem.WholeBackend.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Sale.Hardware_Control
{
    public class Printer : Hardware
    {
        private static void PrintString(string text)
        {
            foreach (var character in text)
            {
                PrintCharacter(character);
            }
        }

        private static void PrintCharacter(char character)
        {
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
