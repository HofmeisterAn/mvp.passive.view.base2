using log4net;
using System;
using System.IO;
using System.Text;

namespace Mvp.Passive.View.Base2
{
    public class Log4NetTextWriter : TextWriter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        private StringBuilder sb { get; set; }

        public override Encoding Encoding
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Log4NetTextWriter()
            : this(null)
        {
        }

        public Log4NetTextWriter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
            this.sb = new StringBuilder();
        }

        protected override void Dispose(bool disposing)
        {
            this.Flush();
            base.Dispose(disposing);
        }

        public override void Flush()
        {
            if (this.sb != null && this.sb.Length > 0)
            {
                this.WriteLine();
            }
        }

        public override void Write(bool value)
        {
            this.sb.Append(value);
        }

        public override void Write(char value)
        {
            this.sb.Append(value);
        }

        public override void Write(char[] buffer)
        {
            this.sb.Append(buffer);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            this.sb.Append(buffer, index, count);
        }

        public override void Write(decimal value)
        {
            this.sb.Append(value);
        }

        public override void Write(double value)
        {
            this.sb.Append(value);
        }

        public override void Write(float value)
        {
            this.sb.Append(value);
        }

        public override void Write(int value)
        {
            this.sb.Append(value);
        }

        public override void Write(long value)
        {
            this.sb.Append(value);
        }

        public override void Write(object value)
        {
            this.sb.Append(value);
        }

        public override void Write(string format, object arg0)
        {
            this.sb.AppendFormat(this.FormatProvider, format, arg0);
        }

        public override void Write(string format, object arg0, object arg1)
        {
            this.sb.AppendFormat(this.FormatProvider, format, arg0, arg1);
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            this.sb.AppendFormat(this.FormatProvider, format, arg0, arg1, arg2);
        }

        public override void Write(string format, params object[] arg)
        {
            this.sb.AppendFormat(this.FormatProvider, format, arg);
        }

        public override void Write(string value)
        {
            this.sb.Append(value);
        }

        public override void Write(uint value)
        {
            this.sb.Append(value);
        }

        public override void Write(ulong value)
        {
            this.sb.Append(value);
        }

        public override void WriteLine()
        {
            var logMessage = this.sb.ToString();

            this.sb.Length = 0;
            Log.Info(logMessage);
        }

        public override void WriteLine(bool value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(char value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(char[] buffer)
        {
            this.Write(buffer);
            this.WriteLine();
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            this.Write(buffer, index, count);
            this.WriteLine();
        }

        public override void WriteLine(decimal value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(double value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(float value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(int value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(long value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(object value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(string format, object arg0)
        {
            this.Write(format, arg0);
            this.WriteLine();
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            this.Write(format, arg0, arg1);
            this.WriteLine();
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            this.Write(format, arg0, arg1, arg2);
            this.WriteLine();
        }

        public override void WriteLine(string format, params object[] arg)
        {
            this.Write(format, arg);
            this.WriteLine();
        }

        public override void WriteLine(string value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(uint value)
        {
            this.Write(value);
            this.WriteLine();
        }

        public override void WriteLine(ulong value)
        {
            this.Write(value);
            this.WriteLine();
        }
    }
}
