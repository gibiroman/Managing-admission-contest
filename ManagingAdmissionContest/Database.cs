using System;
using System.IO;
using System.Diagnostics;

namespace ManagingAdmissionContest
{
    /// <summary>
    /// Manages the more general aspects of database connection for the applicant database.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Creates a database.
        /// </summary>
        /// <param name="databaseName">The name of the database</param>
        public static void CreateDatabase(string databaseName)
        {
            Directory.CreateDirectory(databaseName);
            Debug.Assert(Directory.Exists(databaseName));
        }

        /// <summary>
        /// Creates a table.
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        public static void CreateTable(string tableName)
        {
            try
            {
                FileStream fs = File.Create(tableName);
                fs.Close();
                Debug.Assert(File.Exists(tableName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a database.
        /// </summary>
        /// <param name="databaseName">The name of the database</param>
        public static void DeleteDatabase(string databaseName)
        {
            Directory.Delete(databaseName, true);
            Debug.Assert(!Directory.Exists(databaseName));
        }

        /// <summary>
        /// Deletes a table.
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        public static void DeleteTable(string tableName)
        {
            try
            {
                if (File.Exists(tableName))
                {
                    File.Delete(tableName);
                }
                else
                {
                    throw new FileNotFoundException("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            } 
            Debug.Assert(!File.Exists(tableName));
        }
    }
}
