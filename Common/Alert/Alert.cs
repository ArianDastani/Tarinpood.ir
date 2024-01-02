using Microsoft.AspNetCore.Mvc;

namespace Common.Alert
{
    public class Alert : Controller
    {
        public enum notifyType
        {
            info,
            warning,
            success,
            error,
            question
        }

        public void notify(string Title, notifyType Type, string Descripton)
        {
            TempData["notify"] = $"$.notify({{title: '{Title}',message: '{Descripton}.'}},{{type: '{Type.ToString()}',allow_dismiss: true,newest_on_top: false,mouse_over: false,showProgressbar: false,spacing: 10,timer: 2000,placement: {{from: 'top',align: 'left'}},offset: {{x: 30,y: 30}},delay: 1000,z_index: 10000,animate: {{enter: 'animated bounce',exit: 'animated bounce'}}}});";
        }
    }
}
