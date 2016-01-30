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
        private static Random random = new Random();

        public static void Main(string[] args) {
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

        private static string[] urls = new string[] {
            "http://www.mrscritter.com",
            "http://www.babycritter.com",
            "http://www.faithfulcritter.com",
            "http://www.nextdoorcritter.com",
            "http://www.karokecritter.com",
            "http://www.yogacritter.com",
            "http://www.secretagentcritter.com",
            "http://www.critterwebservice.com",
            "http://www.crittersearchengine.com",
            "http://www.critterdatingservice.com",
            "http://www.crittergourmetfood.com",
            "http://www.critterworldnews.com",
            "http://www.crittermoviereviews.com",
            "http://www.critterburrowdecor.com"
        };
        private static string[] urlPaths = new string[] {
            "",
            "",
            "/?ilove=critters",
            "/nutlovers",
            "/nutsandberries.htm",
            "/summerfun",
            "/starring=mrscritter",
            "?doYouLoveCrittercism=YES"
        };
        private static string randomURLString() {
            return urls[random.Next(0,urls.Length)] + urlPaths[random.Next(0,urlPaths.Length)];
        }
        private static void CommandLogNetworkRequest(string arg) {
            Random random = new Random();
            string[] methods = new string[] { "GET","POST","HEAD","PUT" };
            string method = methods[random.Next(0,methods.Length)];
            string urlString = "";
            if (!arg.Equals("")) {
                urlString = urls[random.Next(0,urls.Length)] + "?arg=" + WebUtility.UrlEncode(arg);
            } else if (random.Next(0,2) == 1) {
                urlString = randomURLString();
            };
            // latency in milliseconds
            long latency = (long)Math.Floor(4000.0 * random.NextDouble());
            long bytesRead = random.Next(0,10000);
            long bytesSent = random.Next(0,10000);
            long responseCode = 200;
            if (random.Next(0,5) == 0) {
                // Some common response other than 200 == OK .
                long[] responseCodes = new long[] { 301,308,400,401,402,403,404,405,408,500,502,503 };
                responseCode = responseCodes[random.Next(0,responseCodes.Length)];
            };
            WebExceptionStatus exceptionStatus = WebExceptionStatus.Success;
            if (random.Next(0,5) == 0) {
                // Simulate a network WebException was encountered.
                WebExceptionStatus[] exceptionStatuses = new WebExceptionStatus[] {
                    WebExceptionStatus.NameResolutionFailure,
                    WebExceptionStatus.ConnectFailure,
                    WebExceptionStatus.ReceiveFailure,
                    WebExceptionStatus.SendFailure,
                    WebExceptionStatus.ConnectionClosed,
                    WebExceptionStatus.TrustFailure,
                    WebExceptionStatus.KeepAliveFailure,
                    WebExceptionStatus.Timeout
                };
                exceptionStatus = exceptionStatuses[random.Next(0,exceptionStatuses.Length)];
                // We didn't receive a simulated response, after all.
                responseCode = 0;
            };
            Crittercism.LogNetworkRequest(
                method,
                urlString,
                latency,
                bytesRead,
                bytesSent,
                (HttpStatusCode)responseCode,
                WebExceptionStatus.Success);
        }

        private static void CommandLogHandledException(string arg) {
            if (arg.Length==0) {
                arg="Deep Error";
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
                arg="Deep Error";
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
            Console.WriteLine("  n arg == LogNetworkRequest");
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
                    case 'n':
                        CommandLogNetworkRequest(arg);
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
