using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{

    public class AppSettings
    {
        private bool m_RememberMe;
        private string m_AccessToken;

        public AppSettings()
        {

        }

        public bool RememberMe { get; set; }

        public string AccesToken { get; set; }

        public void SaveToFile()
        {
            if (File.Exists("AppSettings.xml"))
            {
                using (Stream stream = new FileStream("AppSettings.xml", FileMode.Truncate))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stream, this);
                }
            }
            else
            {
                using (Stream stream = new FileStream("AppSettings.xml", FileMode.CreateNew))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stream, this);
                }
            }
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings appSettings = null;
            try
            {
                using (Stream stream = new FileStream("AppSettings.xml", FileMode.Open))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(AppSettings));
                    appSettings = deserializer.Deserialize(stream) as AppSettings;
                }
            }
            catch (Exception e)
            {
                appSettings = new AppSettings();
            }

            return appSettings;
        }

        public void deleteDetailsAndFile()
        {
            try
            {
                if (File.Exists("AppSettings.xml"))
                {
                    File.Delete("AppSettings.xml");
                }
            }
            catch (Exception generalException)
            {
                
            }
        }
    }
}
