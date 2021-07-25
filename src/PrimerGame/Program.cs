using System;
using Core;

namespace PrimerGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new PrimerCoreGame();
            game.Run();
        }
    }
}
