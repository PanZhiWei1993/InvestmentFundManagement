$(function () {
    //验证input框非空
    $('.ValidateNotEmpy').blur(function () {
        var myValue = $.trim($(this).val());
        if (myValue == "") {
            alert("输入不能为空！");
            this.focus();
        }
    });
    //验证输入数据长度
    $('.ValidateTxtLenght').blur(function () {
        var myValue = $.trim($(this).val());
        if (myValue.Lenght < 6) {
            alert("输入不小于六个字符");
            this.focus();
        }
    });
    debugger;
    //$('.am-form').validator({
    //    onValid: function (validity) {
    //        $(validity.field).closest('.am-form-group').find('.am-alert').hide();
    //    },
    //    onInValid: function (validity) {
    //        var $field = $(validity.field);
    //        //var $group = $field.closest('.am-form-group');
    //        var $group = $field.closest('div');
    //        var $alert = $group.find('.am-alert');
    //        // 使用自定义的提示信息 或 插件内置的提示信息
    //        var msg = $field.data('validationMessage') || this.getValidationMessage(validity);

    //        if (!$alert.length) {
    //            $alert = $('<div class="am-alert am-alert-danger"></div>').hide().
    //                appendTo($group);
    //        }
    //        $alert.html(msg).show();
    //    }
    //});
});
