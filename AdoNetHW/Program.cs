using System;
using System.Threading.Tasks;

namespace AdoNetHW
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AdoNetHwExample adoNetHwExample = new AdoNetHwExample();
            //await adoNetHwExample.GetBooks();

            //wait adoNetHwExample.AddBookInfo("In the sun", new DateTime(2012,6,14,12,0,0), "Gehir");
            await adoNetHwExample.AddBookInfo("In the sky", new DateTime(2013, 6, 14), "Cheshir");
            //await adoNetHwExample.DeleteBookInfo(11);
            //await adoNetHwExample.DeleteBookInfo(13);
            await adoNetHwExample.GetBooks();
        }
    }
}

