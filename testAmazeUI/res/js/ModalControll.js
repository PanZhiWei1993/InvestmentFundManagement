var ProjectFileModalOpen = function (Id, ProID) {
    modal_ProjectFileModel = GetNewProjectFileModel();
    if (Id != "") {
        $.ajaxPost({
            url: '@Url.Content("~/Nitice/SleNoticeDocmentById")',
            data: { Id:Id },
            success: function (result) {
                modal_ProjectFileModel = $.extend(modal_ProjectFileModel, result);
            }
        });
        $('#selBtn_moP_PjTextType').val(modal_ProjectFileModel.FileTypeId);
        $('#selBtn_moP_PjRank').val(modal_ProjectFileModel.ProPhaseId);
        $('#inp_moP_FileDesc').val(modal_ProjectFileModel.FileDesc);
        $('#modal_addNoticeFile').modal({
            closeViaDimmer: false,
            onConfirm: function (options) {

            }
        });
    }
}

var SaveChangeUserModalInfo = function (uId) {
    debugger;
    var Mobile = $("#inp_mod_UserPhone").val();
    var Email = $("#inp_mod_UserEmail").val();
    var Utype = $("#sel_mod_UserRole1").val();
    var LMessage = $("#inp_mod_LMessage").val();
    $.ajaxPost({
        url: "/UserManege/UserChangeInfo",
        data: {
            Id: uId, "Mobile": Mobile, "Email": Email, "Utype": Utype
        },
        success: function (result) {
            window.location.reload();
        }
    })

};
var OpenChangeUserInfoModal = function (options) {
    debugger;
    var defValue = {
        uId: "",
        IsRole: true,
    };
    defValue = $.extend(defValue, options);
    if (defValue.IsRole) {
        $("#userRoleRow").show();
    }
    else {
        $("#userRoleRow").hide();
    }
    $.ajaxPost({
        url: "/UserManege/SelectUserInfoByuId",
        data: {
            Id: defValue.uId
        },
        success: function (result) {
            debugger;
            $("#inp_mod_UserPhone").val(result.Mobile);
            $("#inp_mod_UserEmail").val(result.Email);
            $("#sel_mod_UserRole1").val(result.Utype.toString());
            $("#inp_mod_LMessage").val("");
            $('#modal_ChangeUserInfo').modal({
                closeViaDimmer: false,
                onConfirm: function (options) {
                    SaveChangeUserModalInfo(defValue.uId);
                }
            });
        }
    });
   
};