using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaruBatsuGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean gameset = false;
            Boolean full = false;
            String player1 = "";
            String player2 = "";


            while (player1.Equals(String.Empty))
            {
                sout("player1の名前を入力してください");
                player1 = Console.ReadLine();

            }

            while (player2.Equals(String.Empty))
            {
                sout("player2の名前を入力してください");
                player2 = Console.ReadLine();

            }

            String Spacer = ("-----");
            int[,] masu = new int[3,3] 
            {
                {0,0,0},
                {0,0,0},
                {0,0,0},

            };
            int cnt = 0;

            while (!gameset&&!full)
            {
                sout("while");
                
                sout(cnt+1 + "回目のターンです。");
                sout("===================");
            
                bool chk1 = false;
                bool chk2 = false;
                
                int[] input1;
                int[] input2;
                while (!chk1) //chk1がtrueになるまで、期待された入力がされるまで繰り返し。
                {
                   
                    sout(player1 + "の番です。座標を入力してください");
                    String preInput1 = Console.ReadLine(); //コンソール入力
                    chk1 = System.Text.RegularExpressions.Regex.IsMatch(preInput1, @"^[0-9]{1},[0-9]{1}$");//正規表現で数字とコンマと数字の組み合わせであるかをチェック
                    if (chk1)
                    {
                        input1 = Array.ConvertAll(preInput1.Split(','), int.Parse);//int型の配列に,を区切りにして入れる、Stringで渡されるためint型に変換
                        sout(input1[0] + " " + input1[1]);
                        if (input1[0] > 3 || input1[1] > 3)//3以上の場合は入力し直し
                        {
                            chk1 = false;
                            sout("値が大きすぎます。");
                            continue;
                        }else if (!(masu[input1[0]-1, input1[1]-1] == 0))//入力しようとした座標が0でない、即ちすでに入力されている場合は入力し直し
                        {
                            chk1 = false;
                            sout("すでに入力されています。");
                            continue;

                        }
                        masu[input1[0] - 1, input1[1] - 1] = 1;//書き込む
                        cnt++;
                    }
                    else
                    {
                        sout("書き方がちがうんだなぁ～");
                    }
                }

                    Console.WriteLine(masu[0, 0] + "|" + masu[0, 1] + "|" + masu[0, 2]);
                    Console.WriteLine(Spacer);
                    Console.WriteLine(masu[1, 0] + "|" + masu[1, 1] + "|" + masu[1, 2]);
                    Console.WriteLine(Spacer);
                    Console.WriteLine(masu[2, 0] + "|" + masu[2, 1] + "|" + masu[2, 2]);

                if (cnt > 7)
                {
                    full = true;
                    sout("もういっぱいよ！");
                    continue;
                }

                while (!chk2)
                {
                    sout(player2 + "の番です。座標を入力してください");
                    String preInput2 = Console.ReadLine();
                    chk2 = System.Text.RegularExpressions.Regex.IsMatch(preInput2, @"^[0-9]{1},[0-9]{1}$");
                    if (chk2)
                    {
                        input2 = Array.ConvertAll(preInput2.Split(','), int.Parse);
                        sout(input2[0] + " " + input2[1]);
                        if (input2[0] > 3 || input2[1] > 3)
                        {
                            chk1 = false;
                            sout("値が大きすぎます。");
                            continue;
                        }
                        else if (!(masu[input2[0]-1, input2[1]-1] == 0))
                        {
                            chk2 = false;
                            sout("すでに入力されています。");
                            continue;

                        }
                        masu[input2[0] - 1, input2[1] - 1] = 2;
                        cnt++;
                    }
                    else
                    {
                        sout("書き方がちがうんだなぁ～");
                    }
                }
                    Console.WriteLine(masu[0, 0] + "|" + masu[0, 1] + "|" + masu[0, 2]);
                    Console.WriteLine(Spacer);
                    Console.WriteLine(masu[1, 0] + "|" + masu[1, 1] + "|" + masu[1, 2]);
                    Console.WriteLine(Spacer);
                    Console.WriteLine(masu[2, 0] + "|" + masu[2, 1] + "|" + masu[2, 2]);
                
            }

            sout("GameSet");



            /*
            int foundedIndex = Array.IndexOf(masu, "1");
            while (foundedIndex <= 0)
            {
                Console.WriteLine(foundedIndex);
                if (foundedIndex + 1 < masu.Length)
                {
                    foundedIndex = Array.IndexOf(masu, "1", foundedIndex + 1);

                }
                else
                {
                    break;
                }
            }*/



        }

        


        static void sout(String moji)
        {
            Console.WriteLine(moji);
        }

    }
}
