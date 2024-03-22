using Swed64;
using System.Runtime.InteropServices;

Swed swed = new Swed("cs2");
IntPtr client = swed.GetModuleBase("client.dll");

IntPtr forceAttack = client + 0x1730020;
const int HOTKEY = 0xA4;

while (true)
{
    Console.Clear();

    IntPtr localPlayerPawn = swed.ReadPointer(client, 0x17371A8);
    int entIndex = swed.ReadInt(localPlayerPawn, 0x15A4);

    if (entIndex > 0)
    {
        swed.WriteInt(forceAttack, 65537);
    }
    if (entIndex < 0)
    {
        swed.WriteInt(forceAttack, 256);
    }
    Thread.Sleep(20);
}

[DllImport("user32.dll")]
static extern short GetAsyncKeyState(int vKey);