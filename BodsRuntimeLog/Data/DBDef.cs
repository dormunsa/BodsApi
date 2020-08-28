using System;
using System.Collections.Generic;
using System.Text;

namespace BodsRuntimeLog.Data
{
   

    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using System.Configuration;
    namespace bodsruntimelogs
    {

        public static class bodsruntimelogs
        {



            public static string ConnectionString;
            public static Runtimelogs Truntimelogs = new Runtimelogs();
            public class Runtimelogs
            {


                public static implicit operator string(Runtimelogs table_name)
                { return "runtimelogs"; }



                public string Cn
                {
                    get { return "bodsruntimelogs.runtimelogs"; }
                }

                // runtimelogs fields



                public Id FId = new Id();

                public Time FTime = new Time();

                public Exception FException = new Exception();

                public LogLevel FLog_level = new LogLevel();

                public FileName FFileName = new FileName();

                public NLine FNLine = new NLine();

                public NColumn FNColumn = new NColumn();

                public Method FMethod = new Method();

                public StackTrace FStackTrace = new StackTrace();

                public Custom1 FCustom1 = new Custom1();

                public Custom2 FCustom2 = new Custom2();

                public BuildVersion FBuildVersion = new BuildVersion();

                public class Id
                {

                    public static implicit operator string(Id field_name)
                    {
                        return "runtimelogs.Id";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Id"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Id"; }
                    }
                }

                public class Time
                {

                    public static implicit operator string(Time field_name)
                    {
                        return "runtimelogs.Time";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Time"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Time"; }
                    }
                }

                public class Exception
                {

                    public static implicit operator string(Exception field_name)
                    {
                        return "runtimelogs.Exception";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Exception"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Exception"; }
                    }
                }

                public class LogLevel
                {

                    public static implicit operator string(LogLevel field_name)
                    {
                        return "runtimelogs.Log_level";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Log_level"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Log_level"; }
                    }
                }

                public class FileName
                {

                    public static implicit operator string(FileName field_name)
                    {
                        return "runtimelogs.FileName";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.FileName"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "FileName"; }
                    }
                }

                public class NLine
                {

                    public static implicit operator string(NLine field_name)
                    {
                        return "runtimelogs.NLine";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.NLine"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "NLine"; }
                    }
                }

                public class NColumn
                {

                    public static implicit operator string(NColumn field_name)
                    {
                        return "runtimelogs.NColumn";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.NColumn"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "NColumn"; }
                    }
                }

                public class Method
                {

                    public static implicit operator string(Method field_name)
                    {
                        return "runtimelogs.Method";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Method"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Method"; }
                    }
                }

                public class StackTrace
                {

                    public static implicit operator string(StackTrace field_name)
                    {
                        return "runtimelogs.StackTrace";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.StackTrace"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "StackTrace"; }
                    }
                }

                public class Custom1
                {

                    public static implicit operator string(Custom1 field_name)
                    {
                        return "runtimelogs.Custom1";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Custom1"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Custom1"; }
                    }
                }

                public class Custom2
                {

                    public static implicit operator string(Custom2 field_name)
                    {
                        return "runtimelogs.Custom2";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.Custom2"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "Custom2"; }
                    }
                }

                public class BuildVersion
                {

                    public static implicit operator string(BuildVersion field_name)
                    {
                        return "runtimelogs.BuildVersion";
                    }

                    public string Cn
                    {
                        get { return "bodsruntimelogs.runtimelogs.BuildVersion"; }
                    }

                    public string OnlyColumnName
                    {
                        get { return "BuildVersion"; }
                    }
                }

                // runtimelogs indexes



                public IndexPRIMARY index_PRIMARY = new IndexPRIMARY();

                public class IndexPRIMARY
                {

                    public static implicit operator string(IndexPRIMARY index_name)
                    {
                        return "PRIMARY";
                    }
                }
            }
        } // end of class 

    } // namespace bodsruntimelogs


}
