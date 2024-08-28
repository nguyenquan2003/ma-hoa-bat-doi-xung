using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_RSA_STT
{
    class FunctionRSA
    {

        public FunctionRSA()
        {

        }

        public static string[] chuCai = {" ", "a", "b", "c", "d", "e", "f", "g","h", "i", "j", "k", "l", "m","n", "o", "p", "q", "r", "s", "t", "u", "v","w", "x", "y", "z" };

        public bool kiemTraSoNguyenTo(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public int resultN(int p, int q)
        {
            return p * q;
        }

        public int resultEulerN(int p, int q)
        {
            return (p - 1) * (q - 1);
        }

        public int resultD ( int e, int phiN)
            {
            int d = 1;
            while (true)
            {
                if ((d * e) % phiN == 1)
                    break;
                d++;
            }
            return d;
        }

       public int chuyenChuSangSo(char s)
        {
            List<int> lsBanRo = new List<int>();
            for (int i = 0; i < chuCai.Length; i++)
            {
                if (string.Compare(chuCai.GetValue(i).ToString(), s.ToString()) == 0)
                    return Array.IndexOf(chuCai, chuCai[i]);
            }
            return -1;
        }

        public List<string> chuyenSoSangChu(List<int> lsBanSo)
        {
            List<string> lsBanChu = new List<string>();
            foreach (int i in lsBanSo)
            {
               

                for (int j = 0; j < chuCai.Length;j++)
                {  
                        if (i == Array.IndexOf(chuCai, chuCai[j]))
                        {
                                lsBanChu.Add(chuCai[j]);
                            break;
                        }
                       
                }
            }
            return lsBanChu;
        }

        

        public List<int> maHoa (List<int> lsBanRo, int e, int n)
        {
            List<int> lsBanMa = new List<int>();
            foreach(int i in lsBanRo)
            {
                int kyTuSo = (int)(Math.Pow(i, e) % n);
               
                lsBanMa.Add(kyTuSo);
            }
            return lsBanMa;
        }

        public List<int> giaiMa(List<int> lsBanMa, int d, int n)
        {
            List<int> lsBanRo = new List<int>();
            foreach (int i in lsBanMa)
            {
                int kyTuSo = (int)Math.Pow(i, d) % n;
                lsBanRo.Add(kyTuSo);
            }
            return lsBanRo;
        }

    }
}
