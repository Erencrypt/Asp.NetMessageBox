using System.Web.UI.WebControls;

namespace MessageBox
{
    public class Message
    {
        Literal Literal;
        int Timeout = 6000;
        int ExtendTimeout = 2000;
        bool EscapeHtml = true;
        bool ProcessBar = true;
        bool CloseButton = true;
        Language lng;

        public void Clear() { Literal.Text = ""; }

        public enum Language
        { turkish, english }

        public enum Position
        { topRight, bottomRight, topLeft, bottomLeft, topCenter, topFullWidth, bottomCenter, bottomFullWidth }

        public enum Type
        { info, warning, success, error }

        string Positioning(Position position)
        { string ret; switch (position) { case Position.topRight: ret = "toast-top-right"; break; case Position.bottomRight: ret = "toast-bottom-right"; break; case Position.topLeft: ret = "toast-top-left"; break; case Position.bottomLeft: ret = "toast-bottom-left"; break; case Position.topCenter: ret = "toast-top-center"; break; case Position.topFullWidth: ret = "toast-top-full-width"; break; case Position.bottomCenter: ret = "toast-bottom-center"; break; case Position.bottomFullWidth: ret = "toast-bottom-full-width"; break; default: ret = "toast-top-right"; break; } return ret; }

        string Heading(Type type)
        {
            string ret;
            switch (lng)
            {
                case Language.turkish: switch (type) { case Type.info: ret = "Bilgilendirme"; break; case Type.warning: ret = "Uyarı"; break; case Type.success: ret = "Başarılı"; break; case Type.error: ret = "Hata"; break; default: ret = "Bilgilendirme"; break; }
                    return ret;
                case Language.english: switch (type) { case Type.info: ret = "Information"; break; case Type.warning: ret = "Warning"; break; case Type.success: ret = "Success"; break; case Type.error: ret = "Error"; break; default: ret = "Information"; break; }
                    return ret;
                default: switch (type) { case Type.info: ret = "Information"; break; case Type.warning: ret = "Warning"; break; case Type.success: ret = "Success"; break; case Type.error: ret = "Error"; break; default: ret = "Information"; break; }
                    return ret;
            }
        }

        string BoleanToString(bool bolean)
        { string ret = ""; if (bolean == true) { ret = "true"; } else if (bolean == false) { ret = "false"; } return ret; }

        public void Settings(Language lang=Language.english, Literal literal = null, int timeout = 6000, int extendtimeout = 2000, bool escapehtml = true, bool processbar = true, bool closebutton = true)
        { if (literal != null) {Literal = literal; } lng = lang; Timeout = timeout; ExtendTimeout = extendtimeout; EscapeHtml = escapehtml; ProcessBar = processbar; CloseButton = closebutton; }

        public void Show(Type type, string message, string head = "", Position position = Position.topRight)
        {
            if (head == null || head == "") { head = Heading(type); }
            Literal.Text = "<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css'/><script src='https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js'></script><script src=<'https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js' integrity='sha512 -bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg==' crossorigin ='anonymous' ></script>"
            + "<script>toastr['" + type + "']('" + message + "','" + head + "',{debug:false,escapeHtml:" + BoleanToString(EscapeHtml) + ",progressBar:" + BoleanToString(ProcessBar) + ",closeButton:" + BoleanToString(CloseButton) + ",timeOut:" + Timeout + ",extendedTimeOut:" + ExtendTimeout + ",positionClass:'" + Positioning(position) + "'});</script>";
        }
    }
}
