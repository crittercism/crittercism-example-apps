using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CrittercismSDK;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Crittercism.Init("YOUR APP ID GOES HERE");
            try {
                Console.WriteLine("ConsoleApp Demo");
                Help();
                CommandLoop();
            } catch (Exception e) {
                // Log a Crash .
                Crittercism.LogUnhandledException(e);
            }
            Crittercism.Shutdown();
        }

        private static void CommandBreadcrumb(string arg) {
            if (arg.Length==0) {
                arg="My Breadcrumb";
            }
            Console.WriteLine("LeaveBreadcrumb: \""+arg+"\"");
            Crittercism.LeaveBreadcrumb(arg);
        }

        private static void CommandLogHandledException(string arg) {
            if (arg.Length==0) {
                arg="Deep Inner Exception";
            }
            Console.WriteLine("LogHandledException: \""+arg+"\"");
            try {
                ThrowException(arg);
            } catch (Exception e) {
                Crittercism.LogHandledException(e);
            }
        }

        private static void CommandSetUsername(string arg) {
            if (arg.Length==0) {
                arg="MrsCritter";
            }
            Console.WriteLine("SetUsername: \""+arg+"\"");
            Crittercism.SetUsername(arg);
        }

        private static void CommandCrash(string arg) {
            if (arg.Length==0) {
                arg="Deep Inner Exception";
            }
            Console.WriteLine("Crash: \""+arg+"\"");
            ThrowException(arg);
        }

        private static void Vote() {
            string username=Crittercism.Username();
            if (username==null) {
                username="User";
            }
            string response="";
            Console.WriteLine("Do you love Crittercism?");
            Console.Write(">");
            string result=Console.ReadLine();
            if (result.Length==0) {
                result="y";
            }
            switch (Char.ToLower(result[0])) {
                case 'n':
                    response="doesn't love Crittercism.";
                    break;
                default:
                    response="loves Crittercism.";
                    break;
            }
            string breadcrumb=username+" "+response;
            Console.WriteLine("LeaveBreadcrumb: \""+breadcrumb+"\"");
            Crittercism.LeaveBreadcrumb(breadcrumb);
        }

        private static void Help() {
            Console.WriteLine("Command Menu:");
            Console.WriteLine("  h == Help");
            Console.WriteLine("  u arg == SetUsername");
            Console.WriteLine("  b arg == LeaveBreadcrumb");
            Console.WriteLine("  e arg == LogHandledException");
            Console.WriteLine("  c arg == Crash");
            Console.WriteLine("  v == Do you love Crittercism?");
            Console.WriteLine("  q == Quit");
        }

        private static void CommandLoop() {
            bool quit=false;
            while (!quit) {
                Console.Write(">");
                string[] parse=ParseLine(Console.ReadLine());
                string fn=parse[0];
                string arg=parse[1];
                switch (Char.ToLower(fn[0])) {
                    case 'u':
                        CommandSetUsername(arg);
                        break;
                    case 'b':
                        CommandBreadcrumb(arg);
                        break;
                    case 'e':
                        CommandLogHandledException(arg);
                        break;
                    case 'c':
                        CommandCrash(arg);
                        break;
                    case 'v':
                        Vote();
                        break;
                    case 'q':
                        Console.WriteLine("Goodbye");
                        quit=true;
                        break;
                    default:
                        Help();
                        break;
                }
            }
        }

        private static string[] ParseLine(string line) {
            string fn="";
            string arg="";
            Regex regex=new Regex(@"\A\S+");
            Match match=regex.Match(line);
            if (match.Success) {
                fn=match.Value;
                if (fn.Length<line.Length) {
                    arg=line.Substring(fn.Length).Trim();
                }
            }
            if (fn.Length==0) {
                fn="h";
            }
            string[] answer= { fn,arg };
            return answer;
        }


        private static void DeepError(int n,string arg) {
            if (n==0) {
                throw new Exception(arg);
            } else {
                DeepError(n-1,arg);
            }
        }

        private static void ThrowException(string arg) {
            try {
                DeepError(4,arg);
            } catch (Exception ie) {
                throw new Exception("Outer Exception",ie);
            }
        }
    }
}
