using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    public interface ILanguage
    {
        /// <summary>
        /// 请勿修改主程序文件名
        /// </summary>
        string DO_NOT_RENAME { get; }
        /// <summary>
        /// 同时只允许一个进程运行！
        /// </summary>
        string ONLY_ALLOW_ONE_PROCESS { get; }
        /// <summary>
        /// 弹窗标题
        /// </summary>
        string TITLE { get; }
    }

    public class Language_CN : ILanguage
    {
        public string DO_NOT_RENAME => "请勿修改主程序文件名！";
        public string ONLY_ALLOW_ONE_PROCESS => "同时只允许一个进程运行！";
        public string TITLE => "Ultimate-Commander";
    }

    public class Language_EN : ILanguage
    {
        public string DO_NOT_RENAME => "Please do not rename main program file.";
        public string ONLY_ALLOW_ONE_PROCESS => "Only one process has be allowed to run!";
        public string TITLE => "Ultimate-Commander";
    }
}
