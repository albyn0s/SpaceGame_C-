using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// проверка на исключительную ситуацию
    /// </summary>
    [Serializable]
    
    internal class myException : Exception
    {
        public int ErrorCode { get; set; }

        public myException(string Msg, ref int code)
        {
            ErrorCode = code;
            msg = Msg;
        }

        string msg;

        public override string Message => this.msg;

        static public bool CheckException(int Size, int Speed,ref int code, int Pos1) //проверка и вывод кода ошибки
        {
            if (Size <= 0 || Size >= 100)
            {
                code = 123456789;
                return true;
            }
            else if (Speed > 1000 || Speed < -1000)
            {
                code = 987654321;
                return true;
            }

            else if (Pos1 > 2000)
            {
                code = 10101010;
                return true;
            }
            return false;
        }

    }
}
