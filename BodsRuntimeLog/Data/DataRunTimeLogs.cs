using BodsRuntimeLog.Entity;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BodsRuntimeLog.Data
{
    public static class DataRunTimeLogs
    {
        public static string RuntimeLogsConnectionString = "";
        //insert exception log
        public static async Task<int> Insert(RuntimeLog i_exception)
        {
            DynamicParameters _params = new DynamicParameters();

            _params.Add("@Time", i_exception.Time);
            _params.Add("@Exception", i_exception.Exception);
            _params.Add("@Log_level", i_exception.Log_level);
            _params.Add("@NLine", i_exception.NLine);
            _params.Add("@NColumn", i_exception.NColumn);
            _params.Add("@Method", i_exception.Method);
            _params.Add("@StackTrace", i_exception.StackTrace);
            _params.Add("@Custom1", i_exception.Custom1);
            _params.Add("@Custom2", i_exception.Custom2);
            _params.Add("@BuildVersion", i_exception.BuildVersion);

            string sql = " INSERT INTO " + bodsruntimelogs.bodsruntimelogs.Truntimelogs
                    + "    ("
                                      + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FTime.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FException.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FLog_level.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FNLine.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FNColumn.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FMethod.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FStackTrace.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FCustom1.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FCustom2.Cn
                            + "    ," + bodsruntimelogs.bodsruntimelogs.Truntimelogs.FBuildVersion.Cn
                            + ")"
                                      + " VALUES"
                                      + " (@Time,"
                                      + " @Exception,"
                                      + " @Log_level,"
                                      + " @NLine,"
                                      + " @NColumn,"
                                      + " @Method,"
                                      + " @StackTrace,"
                                      + " @Custom1,"
                                      + " @Custom2,"
                                      + " @BuildVersion"
                                      + ")";


            using (IDbConnection conn = new MySqlConnection(RuntimeLogsConnectionString))
            {
                return (await conn.ExecuteAsync(sql, _params));
            }

        }
    }
}
