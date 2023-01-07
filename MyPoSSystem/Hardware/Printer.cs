using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Hardware
{
    public class Printer : Hardware
    {
        private void PrintString(string text)
        {
            foreach (var character in text)
            {
                PrintCharacter(character);
            }
        }

        private void PrintCharacter(char character)
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
