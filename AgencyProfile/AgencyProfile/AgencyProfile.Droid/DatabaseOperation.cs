using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;

namespace  AgencyProfile.Droid
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }

    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "ProposalNotification.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
           
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            conn.CreateTable<NotificationInfo>();
            // Return the database connection
            return conn;
        }


        public void insertNotificationData(string proposalNumber, string customerName)
        {
            SQLiteConnection db = GetConnection();
            NotificationInfo notify = new NotificationInfo();
            notify.proposalNumber = proposalNumber;

            Random rnd = new Random();
            int myRandomNo = rnd.Next(80000000, 99999999); // creates a 8 digit random no.
            string phoneNu = "98" + myRandomNo;
            notify.proposalText = customerName + " have seen proposal, would you like to talk. Please call on " + phoneNu;
            db.Insert(notify);
            db.Close();

        }

        public void Cleartable()
        {
            SQLiteConnection db = GetConnection();
            NotificationInfo notify = new NotificationInfo();
            db.BeginTransaction();
            try
            {
                // Order of deletions is important when foreign key relationships exist.
                db.Delete(notify);
               // db.Execute("delete from notify");

            }
            catch (Exception e)
            {

            }
            finally
            {
                db.Commit();
            }
            db.Close();
        }

        public IEnumerable<NotificationInfo> getNotificationData()
        {
            SQLiteConnection db = GetConnection();
            return db.Query<NotificationInfo>("select * from NotificationInfo order by ID desc");
        }
    }

    public class NotificationInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string proposalNumber { get; set; }
        public string proposalText { get; set; }

    }
}