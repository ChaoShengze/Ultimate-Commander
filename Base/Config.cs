using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Ultimate_Commander
{
    class Config
    {
        #region 单例模式

        private static Config Instance;
        private readonly string configPath = Application.StartupPath + @"\Config.xml";
        private Dictionary<string, BaseFramework.CallBack> totalTable;
        private XmlDocument xmlDocument;
        private Config() { }
        public static Config GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Config();
                Instance.loadConfig();
            }
            return Instance;
        }

        #endregion

        /// <summary>
        /// 加载配置，包括快捷键等等
        /// </summary>
        private void loadConfig()
        {
            if (File.Exists(configPath))
            {
                try
                {
                    xmlDocument = new XmlDocument();
                    xmlDocument.Load(configPath);
                }
                catch (Exception e)
                {
                    Log.GetInstance().WriteLog(e.Message);
                    throw e;
                }
            }
            else
            {
                makeConfiguration();
            }
        }

        private void makeConfiguration()
        {
            // 根节点
            var xml = new XmlDocument();
            XmlElement settings = xml.CreateElement("Settings");
            xml.AppendChild(settings);

            // 热键
            XmlElement hotKey = xml.CreateElement("Hotkey");
            settings.AppendChild(hotKey);

            // 语言
            XmlElement lang = xml.CreateElement("Language");
            lang.InnerText = "CN";
            settings.AppendChild(lang);

            xml.Save(configPath);

            xmlDocument = xml;
        }

        /// <summary>
        /// 获取语言配置
        /// </summary>
        /// <returns>语言配置</returns>
        public string GetLangConfig()
        {
            return xmlDocument.GetElementsByTagName("Language")[0].InnerText;
        }
    }
}
